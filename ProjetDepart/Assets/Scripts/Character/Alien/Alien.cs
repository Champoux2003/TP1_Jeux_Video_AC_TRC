using UnityEngine;
using UnityEngine.AI;

public class Alien : MonoBehaviour
{
    private NavMeshAgent navAgent;

    private void Awake()
    {
        navAgent = GetComponent<NavMeshAgent>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            //fdhfhgdfgdgfdgfdgfd
        }
    }
}
