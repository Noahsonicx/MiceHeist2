using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AlternateEnemy : MonoBehaviour
{
    public float speed = 10f;

    public int health = 20;

    public int value = 5;

    public GameObject deathEffect;
    public GameObject damageEffect;

    private Transform target;
    private int alternateWaypointIndex = 0;

    void Start()
    {
        target = AlternateWaypoints.alternateWaypoints[0];
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        GameObject effect = Instantiate(damageEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        PlayerStats.Money += value;

        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);

        Destroy(gameObject);
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }

        Vector3 relativePos = target.position - transform.position;
        transform.rotation = Quaternion.LookRotation(relativePos);
    }

    void GetNextWaypoint()
    {
        if (alternateWaypointIndex >= AlternateWaypoints.alternateWaypoints.Length - 1)
        {
            EndPath();
            return;
        }
        alternateWaypointIndex++;
        target = AlternateWaypoints.alternateWaypoints[alternateWaypointIndex];
    }

    void EndPath()
    {
        PlayerStats.Lives--;
        Destroy(gameObject);
    }

}
