using UnityEngine;
using UnityEngine.AI;

public class Alien : MonoBehaviour
{
    private NavMeshAgent navAgent;

    private ObjectPool alienPool;

    private PickupSpawner pickupSpawner;

    private GameObject target;

    private void Awake()
    {
        navAgent = GetComponent<NavMeshAgent>();
        alienPool = Finder.AlienObjectPool;
        pickupSpawner = Finder.PickupSpawner;
        target = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        navAgent.destination = target.transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.GetComponent<Player>() is not null)
        {
            alienPool.Release(gameObject);
            handleDeath();
            return;
        }
        if (collision.transform.GetComponent<Bullet>() is not null)
        {
            alienPool.Release(gameObject);
            handleDeath();
            Finder.EventChannels.PublishBulletHitAlien();
            Finder.EventChannels.PublishRemoveAlienCount();
            return;
        }
        if (collision.transform.GetComponent<Missile>() is not null)
        {
            alienPool.Release(gameObject);
            handleDeath();
            Finder.EventChannels.PublishBulletHitAlien();
            Finder.EventChannels.PublishRemoveAlienCount();
            return;
        }
    }

    private void handleDeath()
    {
        var pickup = pickupSpawner.SpawnPickup();

        if (pickup != null)
        {
            pickup.transform.position = gameObject.transform.position;
        }
    }
}
