using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMover : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform endpoint;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
 
    }
    private void Start()
    {
        
        endpoint = GameObject.FindGameObjectWithTag("EndPoint").transform;
        agent.destination = endpoint.position;
    }
    private void Update()
    {
        if (Vector3.Distance(transform.position, endpoint.position) < 0.1f)
        {
            Destroy(gameObject);
        }
    }
}
