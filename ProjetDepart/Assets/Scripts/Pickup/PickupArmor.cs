using UnityEngine;

public class PickupArmor : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.GetComponent<Player>() is not null)
        {
            Finder.EventChannels.PublishMissilePowerUp();
        }
    }
}
