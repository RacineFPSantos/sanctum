using UnityEngine;
using UnityEngine.InputSystem;

namespace Santum
{
    public class SpawnManager : MonoBehaviour
    {
        private const float ZONE_ANGLE = 72.0f;
        private const float SPAWN_DISTANCE = 20.0f;
        private const int ZONE_COUNT = 5;

        public GameObject[] enemyPrefabs;

        [Header("Spawn")]
        [SerializeField] private LayerMask groundMask = ~0;
        [SerializeField] private float spawnHeightOffset = 0f;

        private int zoneIndex;

        private void Update()
        {
            if (Keyboard.current != null && Keyboard.current.pKey.wasPressedThisFrame)
            {
                SpawnEnemy(0, zoneIndex);
            }
        }

        public void SpawnEnemy(int prefabIndex, int zoneId)
        {
            if (enemyPrefabs == null || prefabIndex < 0 || prefabIndex >= enemyPrefabs.Length)
            {
                Debug.LogError($"{name}: SpawnEnemy called with invalid prefab index {prefabIndex}.", this);
                return;
            }

            GameObject prefab = enemyPrefabs[prefabIndex];
            if (prefab == null)
            {
                Debug.LogError($"{name}: enemyPrefabs[{prefabIndex}] is not assigned.", this);
                return;
            }

            float zonePosition = Random.Range(0f, ZONE_ANGLE) + zoneId * ZONE_ANGLE;
            Vector3 offset = Quaternion.Euler(0f, zonePosition, 0f) * (Vector3.forward * SPAWN_DISTANCE);
            Vector3 center = TheTower.Instance != null ? TheTower.Instance.transform.position : Vector3.zero;
            Vector3 spawnPos = center + offset;

            // Flat terrain — a single downward ray is enough to sit the enemy on the ground.
            if (Physics.Raycast(spawnPos + Vector3.up * 50f, Vector3.down, out RaycastHit ground, 100f, groundMask))
            {
                spawnPos = ground.point;
            }
            spawnPos.y += spawnHeightOffset;

            GameObject spawned = Instantiate(prefab, spawnPos, Quaternion.identity);

            if (spawned.TryGetComponent(out Enemy enemy))
            {
                enemy.LaunchEnemy();
            }
            else
            {
                Debug.LogError($"{name}: spawned prefab '{prefab.name}' has no Enemy component.", spawned);
            }

            zoneIndex++;
            if (zoneIndex >= ZONE_COUNT)
            {
                zoneIndex = 0;
            }
        }
    }
}
