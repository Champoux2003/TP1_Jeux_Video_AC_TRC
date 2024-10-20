using UnityEngine;

public class Finder : MonoBehaviour
{
    private static ObjectPool bulletObjectPool;
    private static ObjectPool missileObjectPool;
    private static ObjectPool alienObjectPool;
    private static ObjectPool pickupHealthObjectPool;
    private static ObjectPool pickupMissileObjectPool;
    private static ObjectPool pickupBulletObjectPool;
    private static EventChannels eventChannels;
    private static StatManager statManager;
    private static PickupSpawner pickupSpawner;


    public static StatManager StatManager
    {
        get
        {
            if (statManager == null)
            {
                statManager = GameObject.FindWithTag("GameController").GetComponent<StatManager>();
            }
            return statManager;
        }
    }

    public static PickupSpawner PickupSpawner
    {
        get
        {
            if (pickupSpawner == null)
            {
                pickupSpawner = GameObject.Find("PickupSpawner").GetComponent<PickupSpawner>();
            }
            return pickupSpawner;
        }
    }

    public static ObjectPool BulletObjectPool
    {
        get
        {
            if (bulletObjectPool == null)
            {
                bulletObjectPool = GameObject.Find("BulletObjectPool").GetComponent<ObjectPool>();
            }
            return bulletObjectPool;
        }
    }

    public static ObjectPool AlienObjectPool
    {
        get
        {
            if (alienObjectPool == null)
            {
                alienObjectPool = GameObject.Find("AlienPool").GetComponent<ObjectPool>();
            }
            return alienObjectPool;
        }
    }

    public static ObjectPool MissileObjectPool
    {
        get
        {
            if (missileObjectPool == null)
            {
                missileObjectPool = GameObject.Find("MissileObjectPool").GetComponent<ObjectPool>();
            }
            return missileObjectPool;
        }
    }

    public static ObjectPool PickupMissileObjectPool
    {
        get
        {
            if (pickupMissileObjectPool == null)
            {
                pickupMissileObjectPool = GameObject.Find("PickupArmorPool").GetComponent<ObjectPool>();
            }
            return pickupMissileObjectPool;
        }
    }

    public static ObjectPool PickupHealthObjectPool
    {
        get
        {
            if (pickupHealthObjectPool == null)
            {
                pickupHealthObjectPool = GameObject.Find("PickupHealthPool").GetComponent<ObjectPool>();
            }
            return pickupHealthObjectPool;
        }
    }

    public static ObjectPool PickupBulletObjectPool
    {
        get
        {
            if (pickupBulletObjectPool == null)
            {
                pickupBulletObjectPool = GameObject.Find("PickupBulletPool").GetComponent<ObjectPool>();
            }
            return pickupBulletObjectPool;
        }
    }

    public static EventChannels EventChannels
    {
        get
        {
            if (eventChannels == null)
            {
                eventChannels = GameObject.FindWithTag("GameController").GetComponent<EventChannels>();
            }
            return eventChannels;
        }
    }

    

}
