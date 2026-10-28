using UnityEngine;

namespace Santum
{
    public class Projectile : MonoBehaviour
    {
        private float damage;
        private Transform target;
        private bool isLaunched = false;

        private float moveSpeed = 12.5f;

        public void LaunchProjectile(Transform target, float damage)
        {
            this.target = target;
            this.damage = damage;
            isLaunched = true;
        }

        private void Update()
        {
            if (!isLaunched)
            {
                return;
            }

            // Target was destroyed or removed (disabled) before we reached it
            if (target == null || !target.gameObject.activeInHierarchy)
            {
                Destroy(gameObject);
                return;
            }

            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            transform.LookAt(target);

            if (Vector3.Distance(transform.position, target.position) < 1f)
            {
                OnArrival();
            }
        }

        private void OnArrival()
        {
            if (target != null && target.TryGetComponent(out Enemy enemy))
            {
                enemy.TakeDamage(damage);
            }

            Destroy(gameObject);
        }
    }
}
