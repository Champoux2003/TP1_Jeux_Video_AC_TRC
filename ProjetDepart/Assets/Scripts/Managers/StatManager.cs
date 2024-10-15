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

    }

    private void LoseHealth()
    {
        if(health > 0)
        {
            health -= 1;
        }

    }

    private void manageMissile()
    {

    }
}
