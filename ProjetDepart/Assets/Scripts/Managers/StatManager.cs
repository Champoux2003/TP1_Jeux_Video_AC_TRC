using UnityEngine;

public class StatManager : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private int health = 5;

    [Header("Missile")]
    [SerializeField] private int missile = 0;

    public int Health => health;

    public int Missile => missile;


    public void Awake()
    {
        var eventChannels = Finder.EventChannels;
        eventChannels.OnAlienHitPlayer += LoseHealth;
        eventChannels.OnHealthPowerUp += GainHealth;
        eventChannels.OnMissilePowerUp += GainMissiles;
        eventChannels.OnMissileFired += LoseMissile;

    }

    private void LoseHealth()
    {
        if(health > 0)
        {
            health -= 1;
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
}
