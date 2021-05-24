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

        public Transform partToRatoate;

        public float turnSpeed = 10f;

        [Header("Unity Setup Fields")]
        public string enemytag = "Enemy";

        public GameObject bulletPrefab;
        public Transform firePoint;




        private void Start()
        {
            InvokeRepeating("UpdateTarget", 0f, 0.5f);
        }

        void UpdateTarget()
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemytag);
            float shortestDistance = Mathf.Infinity;
            GameObject nearestEnemy = null;

            foreach (GameObject enemy in enemies)
            {
                float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
                if (distanceToEnemy < shortestDistance)
                {
                    shortestDistance = distanceToEnemy;
                    nearestEnemy = enemy;
                }
            }

            if (nearestEnemy != null && shortestDistance <= range)
            {
                target = nearestEnemy.transform;
            }
            else
                target = null;
        }


        private void Update()
        {
            if (target == null)
                return;
            // target lock on
            Vector3 dir = target.position - transform.position;
            Quaternion lookRoatation = Quaternion.LookRotation(dir);
            Vector3 rotation = Quaternion.Lerp(partToRatoate.rotation, lookRoatation, Time.deltaTime * turnSpeed).eulerAngles;
            partToRatoate.rotation = Quaternion.Euler(0, rotation.y, 0);


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
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, range);
        }
    }


}