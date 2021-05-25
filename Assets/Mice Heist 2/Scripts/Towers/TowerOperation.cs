using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Towers
{
    public class TowerOperation : MonoBehaviour
    {
        private Transform target;

        [Header("Attributes")]
        public float range = 15f;
        public float fireRate = 1f;
        private float fireCountdown = 0f;

        [Header("Turning")]
        [Tooltip("The Part of the Model that needs to rotate")]
        public Transform partToRatoate;
        public float turnSpeed = 10f;

        [Header("Unity Setup Fields")]
        public string enemytag = "Enemy";

        [Header("Shooting")]
        public GameObject bulletPrefab;
        public Transform firePoint;




        private void Start()
        {
            // This calls the Update Target Method every 0.5 seconds
            InvokeRepeating("UpdateTarget", 0f, 0.5f);
        }

        void UpdateTarget()
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemytag);     //Finds all enemies and puts them in an array
            float shortestDistance = Mathf.Infinity;                                // Sets shortest distance for the dist check.
            GameObject nearestEnemy = null;                                         // Sets nearest enemy

            foreach (GameObject enemy in enemies)                                   // Cycles through all enemies and finds nearest enemy
            {
                float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
                if (distanceToEnemy < shortestDistance)
                {
                    shortestDistance = distanceToEnemy;
                    nearestEnemy = enemy;
                }
            }

            if (nearestEnemy != null && shortestDistance <= range)                  // Sets nearest enemy within range as the target
            {
                target = nearestEnemy.transform;
            }
            else
                target = null;
        }


        private void Update()
        {
            // If there is no target, return.
            if (target == null)
                return;

            // Target lock on and tower rotation
            Vector3 dir = target.position - transform.position;
            Quaternion lookRoatation = Quaternion.LookRotation(dir);
            Vector3 rotation = Quaternion.Lerp(partToRatoate.rotation, lookRoatation, Time.deltaTime * turnSpeed).eulerAngles;
            partToRatoate.rotation = Quaternion.Euler(0, rotation.y, 0);

            // Timer for Shooting based on set fire rate
            if (fireCountdown <= 0)
            {
                //Shoot();
                fireCountdown = 1f / fireRate;
            }

            fireCountdown -= Time.deltaTime;
        }
        /*
            void Shoot()
            {


                GameObject bulletGo = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                Bullet bullet = bulletGo.GetComponent<Bullet>();
                if (bullet != null)
                {
                    bullet.Seek(target);
                }
                Debug.Log("Shoot");
            }
        */

        /// <summary>
        /// Draws the range of the selected tower
        /// </summary>
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, range);
        }
    }


}