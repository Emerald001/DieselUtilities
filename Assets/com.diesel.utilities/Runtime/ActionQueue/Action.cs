public abstract class Action
{
    public abstract void OnEnter();
    public abstract void OnUpdate();
    public abstract void OnExit();

    public bool IsDone;
}