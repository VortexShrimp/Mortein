using UnityEngine;

public class EnemyHitController : MonoBehaviour
{
    public delegate void EnemyHitHandler();
    public static event EnemyHitHandler onEnemyHit;


    [SerializeField] private GameObject enemyDropPrefab;
    [SerializeField] private float dropExpireTime;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            // Destroy the enemy.
            Destroy(gameObject);
            onEnemyHit?.Invoke();

            // Destroy the bullet.
            Destroy(other.gameObject);

            var enemyDrop = Instantiate(enemyDropPrefab, transform.position, Quaternion.identity);
            Destroy(enemyDrop, dropExpireTime);
        }

        if (other.CompareTag("ShotgunBullet"))
        {
            // Destroy the enemy.
            Destroy(gameObject);
            onEnemyHit?.Invoke();

            // Destroy the bullet.
            

            var enemyDrop = Instantiate(enemyDropPrefab, transform.position, Quaternion.identity);
            Destroy(enemyDrop, dropExpireTime);
        }
    }
}
