using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public float speed = 10f;

    public float health = 20;

    public int value = 5;

    public GameObject deathEffect;
    public GameObject damageEffect;
  
    private Transform target;
    public int waypointIndex = 0;

    void Start ()
    {
        target = Waypoints.waypoints[0];

    }
    private void OnTriggerStay(Collider other)
    {
       if(other.gameObject.CompareTag("TimeD"))
        {
            health -= Time.deltaTime * 5;
        }

       
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

    void Update ()
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
        if (waypointIndex >= Waypoints.waypoints.Length - 1)
        {
            EndPath();
            return;
        }
        waypointIndex++;
        target = Waypoints.waypoints[waypointIndex];
    }

    void EndPath()
    {
        PlayerStats.Lives--;
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        //StartCo
    }
    //have damage IE
}
