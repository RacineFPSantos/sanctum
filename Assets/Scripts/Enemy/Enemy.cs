using UnityEngine;

namespace Santum
{
    public enum EnemyType
    {
        Tiny = 1,
        Fast = 2,
        Thought = 3,
    }

    public class Enemy : MonoBehaviour
    {
        public EnemyType type;
        public float hitpoint = 1;
        public float attackPerSecond = 1.5f;
        public float damage = 1.0f;
        public float timeToTower = 7.5f;

        private Vector3 startPosition;
        private Vector3 endPosition;
        private float transition;

        private readonly float towerDistanceOffset = 0.3f;

        private bool isAlive = false;
        private float lastHit;
        private bool hasReachedTower = false;

        private void Update()
        {
            // Guard clause: se estiver morto, interrompe totalmente a execução
            if (!isAlive) return;

            if (!hasReachedTower)
            {
                MoveToTower();
                return;
            }

            // Só é executado se estiver vivo E já tiver chegado na torre
            TryAttack();
        }

        private void MoveToTower()
        {
            transition += timeToTower > 0f ? Time.deltaTime / timeToTower : 1f;
            transition = Mathf.Clamp01(transition);
            transform.position = Vector3.Lerp(startPosition, endPosition, transition);

            if (transition >= 1f)
            {
                hasReachedTower = true;
            }
        }

        private void TryAttack()
        {
            if(Time.time - lastHit > 1f / attackPerSecond)
            {
                // Executa o ataque
                lastHit = Time.time; // Lembre-se de atualizar o timer aqui!
                TheTower.Instance.TakeDamage(damage);
            }
        }

        public void LaunchEnemy()
        {
            Vector3 towerCenter = TheTower.Instance != null ? TheTower.Instance.transform.position : Vector3.zero;
            float towerRadius = TheTower.Instance != null ? TheTower.Instance.GetTowerWidth() : 0.5f;

            if (TheTower.Instance == null)
            {
                Debug.LogWarning("TheTower.Instance missing — using fallback tower position/radius. Start from the bootstrap scene.");
            }

            startPosition = transform.position;

            // Head straight for the tower, stopping just outside its radius
            Vector3 fromTower = startPosition - towerCenter;
            fromTower.y = 0f;
            Vector3 direction = fromTower.sqrMagnitude > 0.0001f ? fromTower.normalized : transform.forward;

            endPosition = towerCenter + direction * (towerRadius + towerDistanceOffset);
            endPosition.y = startPosition.y;

            // Face the direction of travel (toward the tower)
            Vector3 travel = endPosition - startPosition;
            if (travel.sqrMagnitude > 0.0001f)
            {
                transform.rotation = Quaternion.LookRotation(travel);
            }

            transition = 0f;
            isAlive = true;
            gameObject.SetActive(true);
        }

        public void RemoveEnemy()
        {
            transition = 0f;
            isAlive = false;
            gameObject.SetActive(false);
        }

        public void TakeDamage(float amount)
        {
            hitpoint -= amount;

            if (hitpoint < 0)
            {
                hitpoint = 0;
                RemoveEnemy();
            }
        }       
    }
}
