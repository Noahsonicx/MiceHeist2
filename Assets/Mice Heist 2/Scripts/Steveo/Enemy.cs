using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float speed = 10;

    private Transform target;
    private int wavePointIndex = 0;

    public int health = 100;

    public int value = 50;

    private NavMeshAgent agent;

    private void Start()
    {
        target = waypoint.points[0];
        agent = transform.GetComponent<NavMeshAgent>();
        agent.SetDestination(target.position);
    }

    public void TakeDamage(int amount)
    {
        health -= amount;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        PlayerStats.Money += value;

        Destroy(gameObject);
    }

    private void Update()
    {

        //Has the agent reached its position?
        if (!agent.pathPending && agent.remainingDistance < 0.1f)
        {
            GetNextWaypoint();
        }
        
    }

    void GetNextWaypoint()
    {
        if (wavePointIndex >= waypoint.points.Length - 1)
        {
            EndPath();
            return;
        }

        wavePointIndex++;
        target = waypoint.points[wavePointIndex];
    }

    void EndPath()
    {
        PlayerStats.Lives--;
        Destroy(gameObject);
    }
}
