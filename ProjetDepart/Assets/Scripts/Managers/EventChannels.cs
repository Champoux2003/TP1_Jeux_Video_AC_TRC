using UnityEngine;
using UnityEngine.Events;

public class EventChannels : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private UnityEvent onBulletHitAlien = new();
    [SerializeField] private UnityEvent onHealthPowerUp = new();
    [SerializeField] private UnityEvent onMissilePowerUp = new();

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
}
