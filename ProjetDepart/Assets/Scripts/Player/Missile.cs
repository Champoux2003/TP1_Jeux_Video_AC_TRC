using UnityEngine;
using System.Collections;

public class Missile : MonoBehaviour
{
    [Header("Missile Settings")]
    [SerializeField] private float speed = 50f;

    [Header("Explosion Settings")]
    [SerializeField] private float explosionRadius = 5f;
    [SerializeField] private float explosionForce = 50f;
    [SerializeField] private GameObject explosionPrefab;

    private ObjectPool missileObjectPool;

    private float timeSinceSpawned = 0;

    private void Awake()
    {
        missileObjectPool = Finder.MissileObjectPool;
    }   

    private void onEnable()
    {
        timeSinceSpawned = 0;
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        timeSinceSpawned += Time.deltaTime;
        if (timeSinceSpawned > 5)
        {
            missileObjectPool.Release(gameObject);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        Explode();
    }

    private void Explode()
    {
        if(explosionPrefab != null)
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        }

        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

        for(int i = 0; i < colliders.Length; i++)
        {
            Collider collider = colliders[i];
            RaycastHit hit;
            if(Physics.SphereCast(transform.position, explosionRadius, collider.transform.position - transform.position, out hit))
            {
                if(hit.rigidbody != null)
                {
                    hit.rigidbody.AddExplosionForce(explosionForce, transform.position, explosionRadius);
                }
                Finder.EventChannels.PublishBulletHitAlien();//Peut etre changer pour missile
            }
        }
        missileObjectPool.Release(gameObject);
    }


}
