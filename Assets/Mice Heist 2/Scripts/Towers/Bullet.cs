
using UnityEngine;

namespace Towers
{
    public class Bullet : MonoBehaviour
    {
        private Transform target;

        [Header("Bullet Attributes")]
        public GameObject bulletEffectPrefab;
        public float speed = 70f;
        public int damage = 50;
        public float explosionRadius = 0f;

        /// <summary>
        /// Sets the target to the Transform passed in
        /// </summary>
        /// <param name="_target">The target transform</param>
        public void Seek(Transform _target)
        {
            target = _target;
        }

        // Update is called once per frame
        void Update()
        {
            // Destroy if no target, and return.
            if (target == null)
            {
                Destroy(gameObject);
                return;
            }

            // Sets the variables for detecting the hit
            Vector3 dir = target.position - transform.position;
            float distanceThisFrame = speed * Time.deltaTime;

            // Detecting the hit if the distance to target is less than distance per frame
            if (dir.magnitude <= distanceThisFrame)
            {
                HitTarget();
                return;
            }

            // Moves the bullet towards the target and looks at it.
            transform.Translate(dir.normalized * distanceThisFrame, Space.World);
            transform.LookAt(target);

        }

        /// <summary>
        /// Handles the Hit of the bullet and calls Damage and Effects
        /// </summary>
        public void HitTarget()
        {
            GameObject effectIns = Instantiate(bulletEffectPrefab, transform.position, transform.rotation);
            Destroy(effectIns, 2f);     // Destoys the effect after 2 seconds
            if (explosionRadius > 0)    // If the bullet has an explosion radius, do it.
            {
                Explode();
            }
            else
            {
                Damage(target);         // Work out the damage for the hit target
            }


            Destroy(gameObject);        // Destroy the bullet
            Debug.Log("Hit something");
        }

        /// <summary>
        /// Handles the explosion damage by putting everything affected into an array and dealing damage to the enemies. 
        /// </summary>
        public void Explode()
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
            foreach (Collider collider in colliders)
            {
                if (collider.tag == "Enemy")
                {
                    Damage(collider.transform);
                }
            }
        }

        /// <summary>
        /// Gets the Enemy script from the hit target and calls the damage function on it, passing in the bullet damage.
        /// </summary>
        /// <param name="enemy">Transform of the hit enemy</param>
        void Damage(Transform enemy)
        {
            /*
            Enemy e = enemy.GetComponent<Enemy>();

            if (e != null)
            {
                e.TakeDamage(damage);
            }
            */
        }

        /// <summary>
        /// Draws the explosion radius for the bullet selected
        /// </summary>
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, explosionRadius);
        }
    }
}