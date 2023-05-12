public class ExampleDebugScreen : DebugScreenBase<DebugVariables> 
{
    private void Awake() {
        Init(new DebugVariables());
    }
}