using UnityEngine;

public class PickupAmmo : MonoBehaviour
{
    [SerializeField] private float lifeTime = 15;
    private ObjectPool pickupBulletObjectPool;

    private float timeSinceSpawned = 0;

    private void Awake()
    {
        pickupBulletObjectPool = Finder.PickupBulletObjectPool;
    }

    private void Update()
    {
        timeSinceSpawned += Time.deltaTime;
        if (timeSinceSpawned > lifeTime)
        {
            pickupBulletObjectPool.Release(gameObject);
        }
    }

    private void OnEnable()
    {
        timeSinceSpawned = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Nig");
        if (other.transform.GetComponent<Player>() is not null)
        {
            Finder.EventChannels.PublishBulletPowerUp();
            Debug.Log("Nig2");
            pickupBulletObjectPool.Release(gameObject);
            Finder.EventChannels.PublishBulletPowerUp();
            return;
        }
    }
}
