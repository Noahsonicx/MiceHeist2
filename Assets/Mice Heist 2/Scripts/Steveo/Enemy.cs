using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private Transform target;
    
    [Header("Mouse Stats")]
    public int health = 100;
    public int value = 25;

    private NavMeshAgent agent;

    private void Start()
    {
        // Gets a random end point for the mouse
        Transform randomPoint = waypoint.points[Random.Range(0, waypoint.points.Length)];

        // Sets the random point as the target/destination.
        target = randomPoint;
        agent = transform.GetComponent<NavMeshAgent>();
        agent.SetDestination(target.position);
    }

    /// <summary>
    /// Damge function for damaging the mouse. Gets called from the bullet script
    /// </summary>
    /// <param name="amount">amount of damage to take</param>
    public void TakeDamage(int amount)
    {
        health -= amount;

        if (health <= 0)
        {
            // Calls die if health reaches 0
            Die();
        }
    }

    /// <summary>
    /// Die function Destroys mouse and adds value to bank.
    /// </summary>
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
            EndPath();
        }
        
    }
    
    /// <summary>
    /// Called when the mouse reaches the end point
    /// </summary>
    void EndPath()
    {
        // Reduces player lives and destroys the mouse
        PlayerStats.Lives--;
        Destroy(gameObject);
    }
}
