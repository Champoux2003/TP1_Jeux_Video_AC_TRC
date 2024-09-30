using UnityEngine;

public class Finder : MonoBehaviour
{
    private static ObjectPool bulletObjectPool;
    private static EventChannels eventChannels;

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
