using UnityEngine;

public class StatManager : MonoBehaviour
{

    [Header("Health")]
    [SerializeField] private int health = 5;

    [Header("Missile")]
    [SerializeField] private int missile = 0;

    public int Health => health;

    public int Missile => missile;

    public float Ammo => powerUpTimer;

    public string LoseMessage => loseMessage;
    public string WinMessage => winMessage;

    [SerializeField]private int nbOfPortals = 8;
    [SerializeField] private float powerUpDuration = 10f;
    [SerializeField]private string winMessage = "You Win!";
    [SerializeField] private string loseMessage = "You Lose!";
    private float powerUpTimer = 0f;
    private int nbAliens = 0;


    public void Awake()
    {
        var eventChannels = Finder.EventChannels;
        eventChannels.OnAlienHitPlayer += LoseHealth;
        eventChannels.OnHealthPowerUp += GainHealth;
        eventChannels.OnMissilePowerUp += GainMissiles;
        eventChannels.OnMissileFired += LoseMissile;
        eventChannels.OnBulletPowerUp += GainFireRate;
        eventChannels.NbPortalDestroy += BreakPortal;
        eventChannels.AddAlienCount += SpawnAlien;
        eventChannels.RemoveAlienCount += KillAlien;

    }

    private void Update()
    {
        powerUpTimer -= Time.deltaTime;
        if(powerUpTimer <= 0)
        {
            powerUpTimer = 0;
            Finder.EventChannels.PublishNoMoreBulletPowerUp();
        }

        if(nbOfPortals == 0 && nbAliens == 0)
        {
            Finder.EventChannels.PublishPlayerWin();
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
        if(health <= 0)
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

    private void BreakPortal()
    {
        nbOfPortals -= 1;
    }
    private void SpawnAlien()
    {
        nbAliens += 1;
    }
    private void KillAlien()
    { 
        nbAliens -= 1;
    }

}
