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

    [SerializeField] private GameObject hitMarkerPrefab;
    [SerializeField] private GameObject soulPrefab;
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

            Destroy(Instantiate(hitMarkerPrefab, other.transform.position, Quaternion.identity), 0.2f);
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

            Destroy(Instantiate(hitMarkerPrefab, other.transform.position, Quaternion.identity), 0.2f);
        }
    }
}
