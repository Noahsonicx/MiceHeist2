using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private Transform target;
    private int wavePointIndex = 0;

    [Header("Mouse Stats")]
    public int health = 100;
    public int value = 25;

    private NavMeshAgent agent;

    private void Start()
    {
        Transform randomPoint = waypoint.points[Random.Range(0, waypoint.points.Length)];

        target = randomPoint;
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