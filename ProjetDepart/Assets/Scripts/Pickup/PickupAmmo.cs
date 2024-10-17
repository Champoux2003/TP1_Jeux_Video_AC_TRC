using UnityEngine;

public class PickupAmmo : MonoBehaviour
{
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.GetComponent<Player>() is not null)
        {
            Finder.EventChannels.PublishBulletPowerUp();
        }
    }
}
