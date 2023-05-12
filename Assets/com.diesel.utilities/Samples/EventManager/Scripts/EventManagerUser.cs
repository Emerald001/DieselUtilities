using UnityEngine;

public class EventManagerUser : MonoBehaviour
{
    private readonly Vector3[] positions = {
        new Vector3(2, 0, 2),
        new Vector3(2, 0, -2),
        new Vector3(-2, 0, -2),
        new Vector3(-2, 0, 2)
    };

    private GameObject obj;
    private ActionQueue actionQueue;
    
    private bool canInvoke = true;

    private void Awake() {
        actionQueue = new(() => canInvoke = true);
    }

    private void OnEnable() {
        EventManager<EventType>.Subscribe(EventType.SPAWNOBJECT, SpawnObject);
        EventManager<EventType>.Subscribe(EventType.DELETEOBJECT, DeleteObject);
        EventManager<EventType>.Subscribe(EventType.MOVEOBJECT, MoveObject);
    }

    private void OnDisable() {
        EventManager<EventType>.Unsubscribe(EventType.SPAWNOBJECT, SpawnObject);
        EventManager<EventType>.Unsubscribe(EventType.DELETEOBJECT, DeleteObject);
        EventManager<EventType>.Unsubscribe(EventType.MOVEOBJECT, MoveObject);
    }

    private void Update() {
        actionQueue.OnUpdate();

        if (Input.GetKeyDown(KeyCode.Alpha1))
            EventManager<EventType>.Invoke(EventType.SPAWNOBJECT);

        if (Input.GetKeyDown(KeyCode.Alpha2))
            EventManager<EventType>.Invoke(EventType.DELETEOBJECT);

        if (Input.GetKeyDown(KeyCode.Alpha3))
            EventManager<EventType>.Invoke(EventType.MOVEOBJECT);
    }

    private void SpawnObject() {
        if (!canInvoke || obj != null)
            return;

        obj = GameObject.CreatePrimitive(PrimitiveType.Sphere);
    }

    private void DeleteObject() {
        if (obj == null)
            return;

        actionQueue.Clear();
        canInvoke = true;
        Destroy(obj);
        obj = null;
    }

    private void MoveObject() {
        if (!canInvoke || obj == null)
            return;

        canInvoke = false;
        actionQueue.Enqueue(new MoveObjectAction(obj, 2, positions[Random.Range(0, positions.Length)]));
    }
}

public enum EventType {
    MOVEOBJECT = 0,
    DELETEOBJECT = 1,
    SPAWNOBJECT = 2
}