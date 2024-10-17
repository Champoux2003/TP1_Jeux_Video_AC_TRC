using UnityEngine;
using UnityEngine.InputSystem;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private Transform canon;
    [SerializeField] private InputActionReference fireBulletAction;
    [SerializeField] private InputActionReference fireMissileAction;
    [SerializeField] private ObjectPool bulletObjectPool;
    [SerializeField] private ObjectPool missileObjectPool;

    [Header("Fire Settings")]
    [SerializeField] private float fireRate = 0.05f;
    private float nextFire = 0.0f;
    private bool isFire = false;

    private bool canFireMissile = false;

    private void Awake()
    {
        var eventChannels = Finder.EventChannels;
        eventChannels.NoMoreMissiles += DisableMissiles;
    }

    private void OnEnable()
    {
        Finder.EventChannels.OnMissilePowerUp += EnableMissile;
        fireBulletAction.action.started += onFireBullet;
        fireBulletAction.action.canceled += StopFireBullet;
    }

    private void onDisable()
    {
        Finder.EventChannels.OnMissilePowerUp -= EnableMissile;
        fireBulletAction.action.started -= onFireBullet;
        fireBulletAction.action.canceled -= StopFireBullet;
    }


    private void Update()
    {
        if (isFire && Time.time >= nextFire)
        {
            FireBullet();
            Finder.EventChannels.PublishFireBullet();
            nextFire = Time.time + fireRate;
        }

        if (fireMissileAction.action.triggered && canFireMissile)
        {
            FireMissile();
            Finder.EventChannels.PublishFireMissile();
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

    private void onFireBullet(InputAction.CallbackContext context)
    {
        isFire = true;
    }
    private void StopFireBullet(InputAction.CallbackContext context)
    {
        isFire = false;
    }

    private void DisableMissiles()
    {
        canFireMissile = false;
    }

}
