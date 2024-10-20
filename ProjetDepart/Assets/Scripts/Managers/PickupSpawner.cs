using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    [Header("Spawning")]
    [SerializeField] private ObjectPool[] pickupPools;
    [SerializeField] private int spawningOdds = 20;
    private void OnEnable()
    {
        var eventChannels = Finder.EventChannels;
        eventChannels.OnAlienHitPlayer += SpawnPickup;
        eventChannels.OnPlayerHitAlien += SpawnPickup;
        eventChannels.OnBulletHitAlien += SpawnPickup;
    }

    private void SpawnPickup()
    {
        var rand = Random.Range(0, spawningOdds);

        if (rand == 0)
        {
            var rand2 = Random.Range(0, 3);
            var pickup = pickupPools[rand2].Get();
        }
    }
}
