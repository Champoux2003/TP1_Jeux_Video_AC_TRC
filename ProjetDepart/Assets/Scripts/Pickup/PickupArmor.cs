using UnityEngine;

public class PickupArmor : MonoBehaviour
{
    [SerializeField] private float lifeTime = 15;
    private ObjectPool pickupArmorObjectPool;

    private float timeSinceSpawned = 0;

    private void Awake()
    {
        pickupArmorObjectPool = Finder.PickupMissileObjectPool;
    }

    private void Update()
    {
        timeSinceSpawned += Time.deltaTime;
        if (timeSinceSpawned > lifeTime)
        {
            pickupArmorObjectPool.Release(gameObject);
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
            Debug.Log("Nig2");
            pickupArmorObjectPool.Release(gameObject);
            Finder.EventChannels.PublishMissilePowerUp();
            return;
        }
    }
}
