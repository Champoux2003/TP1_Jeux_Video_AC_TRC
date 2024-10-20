using UnityEngine;
using UnityEngine.Events;

public class EventChannels : MonoBehaviour
{
    [Header("Collision Events")]
    [SerializeField] private UnityEvent onBulletHitAlien = new();
    [SerializeField] private UnityEvent onAlienHitPlayer = new();
    [SerializeField] private UnityEvent onPlayerHitAlien = new();
    [SerializeField] private UnityEvent onPlayerHurt = new();
    [SerializeField] private UnityEvent onPlayerDead = new();

    [Header("Projectile Events")]
    [SerializeField] private UnityEvent onFireMissile = new();
    [SerializeField] private UnityEvent onMissileFired = new();
    [SerializeField] private UnityEvent noMoreMissiles = new();
    [SerializeField] private UnityEvent onFireBullet = new();

    [Header("Power Up Events")]
    [SerializeField] private UnityEvent onPowerUpSpawn = new();
    [SerializeField] private UnityEvent onHealthPowerUp = new();
    [SerializeField] private UnityEvent onMissilePowerUp = new();
    [SerializeField] private UnityEvent onBulletPowerUp = new();
    [SerializeField] private UnityEvent noMoreBulletPowerUp = new();

    [Header("EndGame Events")]
    [SerializeField] private UnityEvent addAlienCount = new();
    [SerializeField] private UnityEvent removeAlienCount = new();
    [SerializeField] private UnityEvent nbPortalDestroy = new();
    [SerializeField] private UnityEvent onPlayerWin = new();


    public event UnityAction OnPlayerWin
    {
        add => onPlayerWin.AddListener(value);
        remove => onPlayerWin.RemoveListener(value);
    }

    public event UnityAction OnFireMissile
    {
        add => onFireMissile.AddListener(value);
        remove => onFireMissile.RemoveListener(value);
    }

    public event UnityAction OnFireBullet
    {
        add => onFireBullet.AddListener(value);
        remove => onFireBullet.RemoveListener(value);
    }

    public event UnityAction OnPlayerHitAlien
    {
        add => onPlayerHitAlien.AddListener(value);
        remove => onPlayerHitAlien.RemoveListener(value);
    }

    public event UnityAction OnBulletHitAlien
    {
        add => onBulletHitAlien.AddListener(value);
        remove => onBulletHitAlien.RemoveListener(value);
    }

    public event UnityAction OnHealthPowerUp
    {
        add => onHealthPowerUp.AddListener(value);
        remove => onHealthPowerUp.RemoveListener(value);
    }

    public event UnityAction OnMissilePowerUp
    {
        add => onMissilePowerUp.AddListener(value);
        remove => onMissilePowerUp.RemoveListener(value);
    }

    public event UnityAction OnBulletPowerUp
    {
        add => onBulletPowerUp.AddListener(value);
        remove => onBulletPowerUp.RemoveListener(value);
    }

    public event UnityAction OnMissileFired
    {
        add => onMissileFired.AddListener(value);
        remove => onMissileFired.RemoveListener(value);
    }

    public event UnityAction NoMoreMissiles
    {
        add => noMoreMissiles.AddListener(value);
        remove => noMoreMissiles.RemoveListener(value);
    }

    public event UnityAction OnAlienHitPlayer
    {
        add => onAlienHitPlayer.AddListener(value);
        remove => onAlienHitPlayer.RemoveListener(value);
    }

    public event UnityAction OnPlayerHurt
    {
        add => onPlayerHurt.AddListener(value);
        remove => onPlayerHurt.RemoveListener(value);
    }

    public event UnityAction OnPlayerDead
    {
        add => onPlayerDead.AddListener(value);
        remove => onPlayerDead.RemoveListener(value);
    }

    public event UnityAction OnPowerUpSpawn
    {
        add => onPowerUpSpawn.AddListener(value);
        remove => onPowerUpSpawn.RemoveListener(value);
    }

    public event UnityAction NoMoreBulletPowerUp
    {
        add => noMoreBulletPowerUp.AddListener(value);
        remove => noMoreBulletPowerUp.RemoveListener(value);
    }

    public event UnityAction AddAlienCount
    {
        add => addAlienCount.AddListener(value);
        remove => addAlienCount.RemoveListener(value);
    }

    public event UnityAction RemoveAlienCount
    {
        add => removeAlienCount.AddListener(value);
        remove => removeAlienCount.RemoveListener(value);
    }

    public event UnityAction NbPortalDestroy
    {
        add => nbPortalDestroy.AddListener(value);
        remove => nbPortalDestroy.RemoveListener(value);
    }


    public void PublishAddAlienCount()
    {
        addAlienCount.Invoke();
    }

    public void PublishRemoveAlienCount()
    {
        removeAlienCount.Invoke();
    }

    public void PublishNbPortalDestroy()
    {
        nbPortalDestroy.Invoke();
    }

    public void PublishPlayerHitAlien()
    {
        onPlayerHitAlien.Invoke();
    }

    public void PublishAlienHitPlayer()
    {
        onAlienHitPlayer.Invoke();
    }

    public void PublishBulletHitAlien()
    {
        onBulletHitAlien.Invoke();
    }

    public void PublishHealthPowerUp()
    {
        onHealthPowerUp.Invoke();
    }

    public void PublishMissilePowerUp()
    {
        onMissilePowerUp.Invoke();
    }

    public void PublishPlayerHurt()
    {
        onPlayerHurt.Invoke();
    }

    public void PublishPlayerDead()
    {
        onPlayerDead.Invoke();
    }

    public void PublishFireBullet()
    {
        onFireBullet.Invoke();
    }

    public void PublishFireMissile()
    {
        onFireMissile.Invoke();
    }

    public void PublishBulletPowerUp()
    {
        onBulletPowerUp.Invoke();
    }

    public void PublishOnMissileFired()
    {
        onMissileFired.Invoke();
    }

    public void PublishNoMoreMissiles()
    {
        noMoreMissiles.Invoke();
    }

    public void PublishPowerUpSpawn()
    {
        onPowerUpSpawn.Invoke();
    }

    public void PublishNoMoreBulletPowerUp()
    {
        noMoreBulletPowerUp.Invoke();
    }

    public void PublishPlayerWin()
    {
        onPlayerWin.Invoke();
    }

}
