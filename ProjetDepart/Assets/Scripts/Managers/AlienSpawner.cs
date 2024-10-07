using UnityEngine;
using System.Collections;

public class AlienSpawner : MonoBehaviour
{
    [Header("Spawning")]
    [SerializeField] private ObjectPool alienPool;
    [SerializeField, Tooltip("In seconds."), Min(0)] private float delay = 2f;

    [Header("Limits")]
    [SerializeField] private Transform start;
    [SerializeField] private Transform end;

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
                var start = this.start.position;
                var end = this.end.position;
                var position = Vector3.Lerp(start, end, Random.value);

                alien.transform.position = position;
            }

            await Awaitable.WaitForSecondsAsync(delay);
        }
    }
}
