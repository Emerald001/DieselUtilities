public class DoMethodAction : Action {
    public DoMethodAction(System.Action action) {
        this.action = action;
    }

    private readonly System.Action action;

    public override void OnEnter() {
        action.Invoke();

        IsDone = true;
    }

    public override void OnExit() { }
    public override void OnUpdate() { }
}

public class DoMethodAction<T> : Action
{
    public DoMethodAction(System.Action<T> action, T arg) {
        this.action = action;
        this.arg = arg;
    }

    private readonly System.Action<T> action;
    private readonly T arg;

    public override void OnEnter() {
        action.Invoke(arg);

        IsDone = true;
    }

    public override void OnExit() { }
    public override void OnUpdate() { }
}

public class DoMethodAction<T1, T2> : Action {
    public DoMethodAction(System.Action<T1, T2> action, T1 arg1, T2 arg2) {
        this.action = action;
        this.arg1 = arg1;
        this.arg2 = arg2;
    }

    private readonly System.Action<T1, T2> action;
    private readonly T1 arg1;
    private readonly T2 arg2;

    public override void OnEnter() {
        action.Invoke(arg1, arg2);

        IsDone = true;
    }

    public override void OnExit() { }
    public override void OnUpdate() { }
}

public class DoMethodAction<T1, T2, T3> : Action {
    public DoMethodAction(System.Action<T1, T2, T3> action, T1 arg1, T2 arg2, T3 arg3) {
        this.action = action;
        this.arg1 = arg1;
        this.arg2 = arg2;
        this.arg3 = arg3;
    }

    private readonly System.Action<T1, T2, T3> action;
    private readonly T1 arg1;
    private readonly T2 arg2;
    private readonly T3 arg3;

    public override void OnEnter() {
        action.Invoke(arg1, arg2, arg3);

        IsDone = true;
    }

    public override void OnExit() { }
    public override void OnUpdate() { }
}