using UnityEngine;

public class ValueEditor : MonoBehaviour
{
    [SerializeField] private float PlayerHealth;
    [SerializeField] private float PlayerLevel;
    [SerializeField] private float PlayerMoney;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V)) {
            ExampleDebugScreen.varHolder.PlayerHealth = PlayerHealth;
            ExampleDebugScreen.varHolder.PlayerLevel = PlayerLevel;
            ExampleDebugScreen.varHolder.PlayerMoney = PlayerMoney;
        }

        ExampleDebugScreen.varHolder.FPS = (int)(1.0f / Time.smoothDeltaTime);
    }
}
