using UnityEngine;

public class ActionQueueUser : MonoBehaviour
{
    private ActionQueue actionQueue;
    private bool canInvoke = true;

    private GameObject tmpObj;

    void Start() {
        actionQueue = new(() => canInvoke = true);
    }

    void Update() {
        actionQueue.OnUpdate();

        if (Input.GetKeyDown(KeyCode.S) && canInvoke)
            SpawnAndMoveObject();

        if (Input.GetKeyDown(KeyCode.W))
            InjectInCurrentQueue();
    }

    private void SpawnAndMoveObject() {
        canInvoke = false;

        tmpObj = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        actionQueue.Enqueue(new DoMethodAction(() => tmpObj.transform.position = new Vector3(2, 0, 2)));
        actionQueue.Enqueue(new MoveObjectAction(tmpObj, 2, new Vector3(2, 0, -2)));
        actionQueue.Enqueue(new MoveObjectAction(tmpObj, 2, new Vector3(-2, 0, -2)));
        actionQueue.Enqueue(new MoveObjectAction(tmpObj, 2, new Vector3(-2, 0, 2)));
        actionQueue.Enqueue(new MoveObjectAction(tmpObj, 2, new Vector3(2, 0, 2)));
        actionQueue.Enqueue(new MoveObjectAction(tmpObj, 2, new Vector3(0, 0, 0)));
        actionQueue.Enqueue(new WaitAction(2f));
        actionQueue.Enqueue(new DestoyObjectAction(tmpObj));
        actionQueue.Enqueue(new DoMethodAction(() => tmpObj = null));
    }

    private void InjectInCurrentQueue() {
        if (actionQueue.HasActions)
            actionQueue.Inject(new MoveObjectAction(tmpObj, 2, new Vector3(0, 2, 0)));
    }
}
