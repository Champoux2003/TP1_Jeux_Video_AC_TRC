using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private int health = 10;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.GetComponent<Bullet>() is not null)
        {
            health -= 1;
        }

        if(health <= 0)
        {
            gameObject.SetActive(false);
            Finder.EventChannels.PublishNbPortalDestroy();
        }
    }
}
