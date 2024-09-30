using UnityEngine;

public class Ball : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private ObjectPool bulletObjectPool;

   private void Awake()
    {
        bulletObjectPool = Finder.BulletObjectPool;
    }

    private void OnCollisionEnter(Collision other)
    {
        
        Finder.EventChannels.PublishBulletHitAlien();
    }

}
