using UnityEngine;

public class StatManager : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private int health = 0;

    [Header("Missile")]
    [SerializeField] private int missile = 0;

    public int Health => health;

    public int Missile => missile;


    public void Awake()
    {
        var eventChannels = Finder.EventChannels;

    }

    private void manageHealth()
    {

    }

    private void manageMissile()
    {

    }
}
