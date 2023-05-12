using UnityEngine;

public class WaitAction : Action {
    public WaitAction(float waitTimeInSeconds) {
        waitTime = waitTimeInSeconds;
    }
    
    private float waitTime;

    public override void OnEnter() { }
    public override void OnExit() { }

    public override void OnUpdate() {
        waitTime -= Time.deltaTime;

        if (waitTime <= 0)
            IsDone = true;
    }
}