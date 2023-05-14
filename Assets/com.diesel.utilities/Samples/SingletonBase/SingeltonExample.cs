public class SingeltonExample : Singleton<SingeltonExample>
{
    private void Awake() {
        Init(this);
    }
}
