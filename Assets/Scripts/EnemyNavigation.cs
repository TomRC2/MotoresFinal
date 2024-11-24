using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavigation : MonoBehaviour
{
    public Transform player;
    public NavMeshAgent agent;
    public float delay;
    public float interval;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        InvokeRepeating("SetDestination", delay, interval);
    }

    public void SetDestination()
    {
        agent.destination = player.position;
    }
}
