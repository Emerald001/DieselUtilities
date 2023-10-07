using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitForCallAction<Enum> : Action {
    public WaitForCallAction(Enum eventType) {
        this.eventType = eventType;
    }

    private Enum eventType;

    public override void OnEnter() {
        EventManager<Enum>.Subscribe(eventType, Listening);
    }

    public override void OnExit() {
        EventManager<Enum>.Unsubscribe(eventType, Listening);
    }

    public override void OnUpdate() {

    }

    public void Listening() {
        IsDone = true;
    }
}