using UnityEngine;

public class StatManager : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private int health = 5;

    [Header("Missile")]
    [SerializeField] private int missile = 0;

    [Header("Ammo")]
    [SerializeField] private int ammo = 0;

    public int Health => health;

    public int Missile => missile;

    public int Ammo => ammo;

    
    private float powerUpTimer = 0f;
    [SerializeField] private float powerUpDuration = 10f;

    public void Awake()
    {
        var eventChannels = Finder.EventChannels;
        eventChannels.OnAlienHitPlayer += LoseHealth;
        eventChannels.OnHealthPowerUp += GainHealth;
        eventChannels.OnMissilePowerUp += GainMissiles;
        eventChannels.OnMissileFired += LoseMissile;
        eventChannels.OnBulletPowerUp += GainFireRate;

    }

    private void Update()
    {
        powerUpTimer -= Time.deltaTime;
        if(powerUpTimer <= 0)
        {
            Finder.EventChannels.PublishNoMoreBulletPowerUp();
        }
    }

    private void LoseHealth()
    {
        if (health > 0)
        {
            health -= 1;
            
        }
        if(health > 0)
        {
            Finder.EventChannels.PublishPlayerHurt();
        }
        else
        {
            Finder.EventChannels.PublishPlayerDead();
        }

    }

    private void GainHealth()
    {
        if (health > 0)
        {
            health += 1;
        }
    }

    private void GainMissiles()
    {
        missile += 5;
    }

    private void LoseMissile()
    {
        missile -= 1;
        if (missile <= 0)
        {
            Finder.EventChannels.PublishNoMoreMissiles();
        }
    }

    private void GainFireRate()
    {
        powerUpTimer += powerUpDuration;
    }


}
