using UnityEngine;

public class DestoyObjectAction : Action {
    public DestoyObjectAction(GameObject gameObject) {
        this.gameObject = gameObject;
    }

    private readonly GameObject gameObject;

    public override void OnEnter() {
        Object.Destroy(gameObject);

        IsDone = true;
    }

    public override void OnExit() { }
    public override void OnUpdate() { }
}