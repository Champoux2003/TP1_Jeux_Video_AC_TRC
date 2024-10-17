using UnityEngine;
using UnityEngine.Events;

public class EventChannels : MonoBehaviour
{
    [SerializeField] private UnityEvent onBulletHitAlien = new();
    [SerializeField] private UnityEvent onHealthPowerUp = new();
    [SerializeField] private UnityEvent onMissilePowerUp = new();
    [SerializeField] private UnityEvent onAlienHitPlayer = new();
    [SerializeField] private UnityEvent onPlayerHitAlien = new();
    [SerializeField] private UnityEvent onMissileFired = new();
    [SerializeField] private UnityEvent noMoreMissiles = new();


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

    public void PublishOnMissileFired()
    {
        onMissileFired.Invoke();
    }

    public void PublishNoMoreMissiles()
    {
        noMoreMissiles.Invoke();
    }
}
