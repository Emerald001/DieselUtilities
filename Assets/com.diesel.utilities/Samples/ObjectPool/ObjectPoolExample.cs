using UnityEngine;

public class ObjectPoolExample : MonoBehaviour
{
    private ObjectPool<Bullet> pool;

    private void Start()
    {
        pool = new(10);
    }

    private void Update()
    {
        Vector3 dir = Camera.main.transform.forward;

        // use this instead of spawning a new object
        Bullet bullet = pool.GetObjectFromPool();
        bullet.Rigidbody.AddForce(dir, ForceMode.Impulse);
    }
}

public class Bullet : MonoBehaviour, IPoolable {
    public Rigidbody Rigidbody { get; private set; }
    private GameObject visuals;

    public bool Active { get; set; }

    public void Init() {
        visuals = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        visuals.transform.localScale = new Vector3(.1f, .1f, .1f);
    }

    public void OnDisableObject() {
        visuals.SetActive(false);
    }

    public void OnEnableObject() {
        visuals.SetActive(true);
    }
}