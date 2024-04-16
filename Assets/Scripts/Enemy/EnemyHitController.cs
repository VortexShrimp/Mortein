using UnityEngine;

/// <summary>
/// Handles collisions made to enemies.
/// </summary>
public class EnemyHitController : MonoBehaviour
{
    public delegate void EnemyDeathHandler();
    public static event EnemyDeathHandler onEnemyDeath;

    [SerializeField] private int maxHealth;
    private int _currentHealth;


    [Tooltip("The prefab to spawn when an enemy dies.")]
    [SerializeField] private GameObject soulPrefab;
    [Tooltip("How long should the soul linger on the map?")]
    [SerializeField] private float soulExpireTime;

    private void Start()
    {
        _currentHealth = maxHealth;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            _currentHealth -= 1;

            if (_currentHealth <= 0)
            {
                Destroy(gameObject);
                Destroy(Instantiate(soulPrefab, transform.position, Quaternion.identity), soulExpireTime);

                onEnemyDeath?.Invoke();
            }

            // Destroy the bullet.
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("ShotgunBullet"))
        {
            _currentHealth -= 5;

            if (_currentHealth <= 0)
            {
                Destroy(gameObject);
                Destroy(Instantiate(soulPrefab, transform.position, Quaternion.identity), soulExpireTime);

                onEnemyDeath?.Invoke();
            }
        }
    }
}
