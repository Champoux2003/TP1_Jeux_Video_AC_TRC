using UnityEngine;
using UnityEngine.AI;

public class Alien : MonoBehaviour
{
    private NavMeshAgent navAgent;

    private ObjectPool alienPool;

    private GameObject target;

    private void Awake()
    {
        navAgent = GetComponent<NavMeshAgent>();
        alienPool = Finder.AlienObjectPool;
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
            Finder.EventChannels.PublishAlienHitPlayer();
            return;
        }
        if (collision.transform.GetComponent<Bullet>() is not null)
        {
            alienPool.Release(gameObject);
            Finder.EventChannels.PublishBulletHitAlien();
            return;
        }
    }
}
