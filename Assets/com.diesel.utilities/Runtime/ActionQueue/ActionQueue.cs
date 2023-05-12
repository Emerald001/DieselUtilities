using System.Collections.Generic;

public class ActionQueue
{
    public bool HasActions { get => CurrentQueue.Count > 0; }

    private Action CurrentAction;
    private Queue<Action> CurrentQueue = new();

    private readonly System.Action OnEmptyQueue;
    
    public ActionQueue(System.Action OnEmptyQueue = null) {
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
            OnEmptyQueue?.Invoke();
        }
    }

    public void Inject(Action action, int index = 0) {
        List<Action> tmp = new(CurrentQueue);

        tmp.Insert(index, action);

        CurrentQueue = new(tmp);
    }

    public void Enqueue(Action action) {
        CurrentQueue.Enqueue(action);

        if (CurrentAction == null)
            NextAction();
    }

    public void Clear(bool finishAction = false) {
        if (!finishAction)
            CurrentAction = null;

        CurrentQueue.Clear();
        OnEmptyQueue?.Invoke();
    }
}