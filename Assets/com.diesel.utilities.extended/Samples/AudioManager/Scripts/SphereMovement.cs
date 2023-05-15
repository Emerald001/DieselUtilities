using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereMovement : MonoBehaviour
{
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private float speed;
    
    private ActionQueue queue;

    void Start()
    {
        audioManager.PlayLoopedAudio("Music", true);
        queue = new(SetQueue);

        SetQueue();
    }

    private void Update() {
        queue.OnUpdate();
    }

    private void SetQueue() {
        queue.Enqueue(new MoveObjectAction(gameObject, speed, new Vector3(20, 0, 20)));
        queue.Enqueue(new MoveObjectAction(gameObject, speed, new Vector3(-20, 0, 20)));
        queue.Enqueue(new MoveObjectAction(gameObject, speed, new Vector3(-20, 0, -20)));
        queue.Enqueue(new MoveObjectAction(gameObject, speed, new Vector3(20, 0, -20)));
    }
}
