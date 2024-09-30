using UnityEngine;
using UnityEngine.Events;

public class EventChannels : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private UnityEvent onBulletHitAlien = new();

    public event UnityAction OnBulletHitAlien
    {
        add => onBulletHitAlien.AddListener(value);
        remove => onBulletHitAlien.RemoveListener(value);
    }

    public void PublishBulletHitAlien()
    {
        onBulletHitAlien.Invoke();
    }
}
