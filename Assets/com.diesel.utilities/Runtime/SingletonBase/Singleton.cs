using UnityEngine;

public class Singleton<T> : MonoBehaviour
{
    public static T Instance;

    public void Init(T instance) => Instance = instance;
}
