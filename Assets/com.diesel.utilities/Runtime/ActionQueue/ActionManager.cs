using System.Collections.Generic;

public class ActionManager
{
    private Action CurrentAction;
    private Queue<Action> CurrentQueue = new();
    private readonly System.Action OnEmptyQueue;
    
    public ActionManager(System.Action OnEmptyQueue = null) {
        this.OnEmptyQueue = OnEmptyQueue;
    }

    public void OnUpdate() {
        if (CurrentAction == null) {
            if (CurrentQueue.Count > 0)
                NextAction();
            return;
        }

        CurrentAction.OnUpdate();

        if (CurrentAction.IsDone)
            NextAction();
    }

    private void NextAction() {
        CurrentAction?.OnExit();

        if (CurrentQueue.Count > 0) {
            CurrentAction = CurrentQueue.Dequeue();
            CurrentAction.OnEnter();

            if (CurrentAction.IsDone)
                NextAction();
        }
        else {
            CurrentAction = null;
            OnEmptyQueue.Invoke();
        }
    }

    public void Inject(int index, Action action) {
        List<Action> tmp = new(CurrentQueue);

        tmp.Insert(index, action);

        CurrentQueue = new(tmp);
    }

    public void Enqueue(Action action) => CurrentQueue.Enqueue(action);
    public void Clear() => CurrentQueue.Clear();
}