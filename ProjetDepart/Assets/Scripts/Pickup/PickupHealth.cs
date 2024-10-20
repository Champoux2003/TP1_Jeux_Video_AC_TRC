using UnityEngine;

public class PickupHealth : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.GetComponent<Player>() is not null)
        {
            Finder.EventChannels.PublishHealthPowerUp();
        }
    }
}
