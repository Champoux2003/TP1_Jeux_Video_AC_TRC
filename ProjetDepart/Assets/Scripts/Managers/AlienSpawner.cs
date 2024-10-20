using UnityEngine;
using System.Collections;

public class AlienSpawner : MonoBehaviour
{
    [Header("Spawning")]
    [SerializeField] private ObjectPool alienPool;
    [SerializeField, Tooltip("In seconds."), Min(0)] private float delay = 2f;
    [SerializeField] private Transform[] portals;

    private Awaitable routine;

    private void OnEnable()
    {
        routine = SpawningRoutine();
    }

    private void OnDisable()
    {
        routine.Cancel();
    }

    private async Awaitable SpawningRoutine()
    {
        while (isActiveAndEnabled)
        {
            var alien = alienPool.Get();
            if (alien != null)
            {
                var index = Random.Range(0, portals.Length);
                var position = portals[index].position;
                alien.transform.position = position;
                Finder.EventChannels.PublishAddAlienCount();
            }

            await Awaitable.WaitForSecondsAsync(delay);
        }
    }
}
