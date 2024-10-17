using UnityEngine;
using UnityEngine.InputSystem;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private Transform canon;
    [SerializeField] private InputActionReference fireBulletAction;
    [SerializeField] private InputActionReference fireMissileAction;
    [SerializeField] private ObjectPool bulletObjectPool;
    [SerializeField] private ObjectPool missileObjectPool;

    private bool canFireMissile = false;

    private void Awake()
    {
        var eventChannels = Finder.EventChannels;
        eventChannels.NoMoreMissiles += DisableMissiles;
    }

    private void OnEnable()
    {
        Finder.EventChannels.OnMissilePowerUp += EnableMissile;
    }

    private void Update()
    {
        if (fireBulletAction.action.triggered)
        {
            FireBullet();
        }

        if (fireMissileAction.action.triggered && canFireMissile)
        {
            FireMissile();
        }
    }

    private void FireBullet()
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

    private void FireMissile()
    {
        var missile = missileObjectPool.Get();

        if (missile != null)
        {
            missile.transform.position = canon.position;
            missile.transform.rotation = canon.rotation;

            var missileRigidbody = missile.GetComponent<Rigidbody>();

            if (missileRigidbody != null)
            {
                missileRigidbody.linearVelocity = canon.forward;
            }
        }
    }

    private void EnableMissile()
    {
        canFireMissile = true;
    }

    private void DisableMissiles()
    {
        canFireMissile = false;
    }

}
