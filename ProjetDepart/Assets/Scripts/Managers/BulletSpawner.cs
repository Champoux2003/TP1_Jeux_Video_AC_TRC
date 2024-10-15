using UnityEngine;
using UnityEngine.InputSystem;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private Transform canon;
    [SerializeField] private InputActionReference fireAction;
    [SerializeField] private ObjectPool bulletObjectPool;

    private void Update()
    {
        if (fireAction.action.triggered)
        {
            Fire();
        }
    }

    private void Fire()
    {
        var bullet = bulletObjectPool.Get();

        if (bullet != null)
        {
            bullet.transform.position = canon.position;
            bullet.transform.rotation = canon.rotation;

            var bulletRigidbody = bullet.GetComponent<Rigidbody>();

            if (bulletRigidbody != null)
            {
                bulletRigidbody.linearVelocity = canon.forward;
            }
        }
    }
}
