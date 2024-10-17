using UnityEngine;
using UnityEngine.Events;

public class EventChannels : MonoBehaviour
{
    [SerializeField] private UnityEvent onBulletHitAlien = new();
    [SerializeField] private UnityEvent onHealthPowerUp = new();
    [SerializeField] private UnityEvent onMissilePowerUp = new();
    [SerializeField] private UnityEvent onAlienHitPlayer = new();
    [SerializeField] private UnityEvent onPlayerHitAlien = new();
    [SerializeField] private UnityEvent onPlayerHurt = new();
    [SerializeField] private UnityEvent onPlayerDead = new();
    [SerializeField] private UnityEvent onFireBullet = new();
    [SerializeField] private UnityEvent onFireMissile = new();



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
}
