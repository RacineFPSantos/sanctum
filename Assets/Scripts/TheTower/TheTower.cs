using System;
using UnityEngine;

namespace Santum
{
    public enum Stat
    {
        Damage = 0,
        Range,
        Speed,
        Hitpoints,
        Regen,
        CritChance,
        CritDamage,
        Luck
    }

    public class TheTower : MonoBehaviour
    {
        public static TheTower Instance { get; private set; }

        public int[] TowerStats { get; private set; }

        [Header("Combat")]
        [SerializeField] private GameObject projectilePrefab;
        [Tooltip("Where projectiles spawn from. Falls back to the top of the tower if unset.")]
        [SerializeField] private Transform firePoint;
        [SerializeField] private float rangeRadiusOffset = 5f;

        [Header("Dimensions")]
        [Tooltip("Authored to match the 3D model; used for camera framing and enemy stop distance.")]
        [SerializeField] private float towerHeight = 3f;
        [SerializeField] private float towerRadius = 1f;

        [Header("UI")]
        [SerializeField] private GameObject recapMenu;

        private float lastAttack;

        private int enemyLayerMask;
        private readonly Collider[] enemyBuffer = new Collider[64];

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;

            enemyLayerMask = LayerMask.GetMask("Enemy");
            if (enemyLayerMask == 0)
            {
                Debug.LogWarning("TheTower: 'Enemy' layer is not defined — the tower will never detect enemies.");
            }

            LoadLocal();

            if (recapMenu != null)
            {
                recapMenu.SetActive(false);
            }
        }

        private void OnDestroy()
        {
            if (Instance == this)
            {
                Instance = null;
            }
        }

        private void Update()
        {
            if (TowerStats == null)
            {
                return;
            }

            // Speed stat is attacks per second, so the gap between attacks is its inverse
            float attackInterval = 1f / Mathf.Max(1, TowerStats[(int)Stat.Speed]);
            if (Time.time - lastAttack < attackInterval)
            {
                return;
            }

            // Consume the cooldown now so the scan runs at the attack rate, not every frame
            lastAttack = Time.time;

            float attackRange = TowerStats[(int)Stat.Range] + rangeRadiusOffset;
            int hitCount = Physics.OverlapSphereNonAlloc(transform.position, attackRange, enemyBuffer, enemyLayerMask);

            if (hitCount == 0)
            {
                return;
            }

            // Find the closest one
            int closestIndex = 0;
            float closestDistance = (enemyBuffer[closestIndex].transform.position - transform.position).sqrMagnitude;

            for (int i = 1; i < hitCount; i++)
            {
                float distance = (enemyBuffer[i].transform.position - transform.position).sqrMagnitude;
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestIndex = i;
                }
            }

            // Shoot the closest Enemy
            ShootEnemy(enemyBuffer[closestIndex].transform);
        }

        private void ShootEnemy(Transform target)
        {
            if (projectilePrefab == null)
            {
                Debug.LogError("TheTower: projectilePrefab is not assigned.", this);
                return;
            }

            Vector3 spawn = firePoint != null ? firePoint.position : transform.position + Vector3.up * towerHeight;
            GameObject go = Instantiate(projectilePrefab, spawn, Quaternion.identity);

            if (go.TryGetComponent(out Projectile p))
            {
                p.LaunchProjectile(target, TowerStats[(int)Stat.Damage]);
            }
            else
            {
                Debug.LogError($"TheTower: '{projectilePrefab.name}' prefab has no Projectile component.", go);
                Destroy(go);
            }
        }

        public void TakeDamage(float amount)
        {
            if (TowerStats == null)
            {
                return;
            }

            TowerStats[(int)Stat.Hitpoints] -= (int)amount;

            if (TowerStats[(int)Stat.Hitpoints] < 0)
            {
                TowerStats[(int)Stat.Hitpoints] = 10;

                if (recapMenu != null)
                {
                    recapMenu.SetActive(true);
                }
            }
        }

        public void Upgrade(Stat stat, int amount = 1)
        {
            if (TowerStats == null)
            {
                return;
            }

            TowerStats[(int)stat] = Mathf.Max(1, TowerStats[(int)stat] + amount);
            SaveLocal();
        }

        public float GetTowerHeight() => towerHeight;

        public float GetTowerWidth() => towerRadius;

        private void LoadLocal()
        {
            TowerStats = new int[Enum.GetNames(typeof(Stat)).Length];

            TowerStats[(int)Stat.Damage] = PlayerPrefs.GetInt("StatDamage");
            TowerStats[(int)Stat.Range] = PlayerPrefs.GetInt("StatRange");
            TowerStats[(int)Stat.Speed] = PlayerPrefs.GetInt("StatSpeed");
            TowerStats[(int)Stat.Hitpoints] = PlayerPrefs.GetInt("StatHitpoints");
            TowerStats[(int)Stat.Regen] = PlayerPrefs.GetInt("StatRegen");
            TowerStats[(int)Stat.CritChance] = PlayerPrefs.GetInt("StatCritChance");
            TowerStats[(int)Stat.CritDamage] = PlayerPrefs.GetInt("StatCritDamage");
            TowerStats[(int)Stat.Luck] = PlayerPrefs.GetInt("StatLuck");

            for (int i = 0; i < TowerStats.Length; i++)
            {
                if (TowerStats[i] == 0)
                {
                    TowerStats[i] = 1;
                }
            }
        }

        private void SaveLocal()
        {
            if (TowerStats == null)
            {
                return;
            }

            PlayerPrefs.SetInt("StatDamage", TowerStats[(int)Stat.Damage]);
            PlayerPrefs.SetInt("StatRange", TowerStats[(int)Stat.Range]);
            PlayerPrefs.SetInt("StatSpeed", TowerStats[(int)Stat.Speed]);
            PlayerPrefs.SetInt("StatHitpoints", TowerStats[(int)Stat.Hitpoints]);
            PlayerPrefs.SetInt("StatRegen", TowerStats[(int)Stat.Regen]);
            PlayerPrefs.SetInt("StatCritChance", TowerStats[(int)Stat.CritChance]);
            PlayerPrefs.SetInt("StatCritDamage", TowerStats[(int)Stat.CritDamage]);
            PlayerPrefs.SetInt("StatLuck", TowerStats[(int)Stat.Luck]);
            PlayerPrefs.Save();
        }

        private void LoadCloud() { }

        private void SaveCloud() { }

        private void OnApplicationQuit()
        {
            SaveLocal();
        }

        // FOR DEVELOPER ONLY
        private void OnDrawGizmos()
        {
            if (TowerStats == null || TowerStats.Length <= (int)Stat.Range)
            {
                return;
            }

            Gizmos.color = new Color(1f, 0f, 0f, 0.4f);
            float currentRadius = TowerStats[(int)Stat.Range] + rangeRadiusOffset;
            Gizmos.DrawWireSphere(transform.position, currentRadius);
        }
    }
}
