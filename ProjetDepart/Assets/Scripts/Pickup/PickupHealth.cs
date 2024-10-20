using UnityEngine;

public class PickupHealth : MonoBehaviour
{
    [SerializeField] private float lifeTime = 15;
    private ObjectPool pickupHealthObjectPool;

    private float timeSinceSpawned = 0;

    private void Awake()
    {
        pickupHealthObjectPool = Finder.PickupHealthObjectPool;
    }

    private void Update()
    {
        timeSinceSpawned += Time.deltaTime;
        if (timeSinceSpawned > lifeTime)
        {
            pickupHealthObjectPool.Release(gameObject);
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
            pickupHealthObjectPool.Release(gameObject);
            Finder.EventChannels.PublishHealthPowerUp();
            return;
        }
    }
}
