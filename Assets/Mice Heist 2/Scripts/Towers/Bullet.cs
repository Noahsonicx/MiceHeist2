
using UnityEngine;

namespace Towers
{
    public class Bullet : MonoBehaviour
    {
        private Transform target;

        public GameObject bulletEffectPrefab;

        public float speed = 70f;
        public int damage = 50;

        public float explosionRadius = 0f;

        public void Seek(Transform _target)
        {
            target = _target;
        }

        // Update is called once per frame
        void Update()
        {
            if (target == null)
            {
                Destroy(gameObject);
                return;
            }

            Vector3 dir = target.position - transform.position;
            float distanceThisFrame = speed * Time.deltaTime;

            if (dir.magnitude <= distanceThisFrame)
            {
                HitTarget();
                return;
            }

            transform.Translate(dir.normalized * distanceThisFrame, Space.World);
            transform.LookAt(target);

        }

        void HitTarget()
        {
            GameObject effectIns = Instantiate(bulletEffectPrefab, transform.position, transform.rotation);
            Destroy(effectIns, 2f);
            if (explosionRadius > 0)
            {
                Explode();
            }
            else
            {
                Damage(target);
            }


            Destroy(gameObject);
            Debug.Log("Hit something");
        }

        void Explode()
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

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, explosionRadius);
        }
    }
}