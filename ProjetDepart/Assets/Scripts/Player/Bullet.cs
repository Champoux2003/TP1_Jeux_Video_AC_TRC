using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]private float speed = 50f;
    [SerializeField]private float maxLifeTime = 5f;
    private ObjectPool bulletObjectPool;

    private float timeSinceSpawned = 0;

    

    private void Awake()
    {
        bulletObjectPool = Finder.BulletObjectPool;
    }

    private void OnEnable()
    {
        timeSinceSpawned = 0;
    }
    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        timeSinceSpawned += Time.deltaTime;
        if (timeSinceSpawned > maxLifeTime)
        {
            bulletObjectPool.Release(gameObject);
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        
        bulletObjectPool.Release(gameObject);
    }

}
