using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemySkeletonPrefab;
    [SerializeField] private GameObject enemyDemonPrefab;

    [SerializeField] private GameObject[] pickupPrefabs;

    private void OnEnable()
    {
        GameManager.onNewRound += OnNewRound;
    }

    private void OnDisable()
    {
        GameManager.onNewRound -= OnNewRound;
    }

    private void Start()
    {
        SpawnEnemiesAndPickups();
    }

    private void SpawnEnemiesAndPickups()
    {
        for (int i = 0; i < GameManager.Instance.maxEnemies; ++i)
        {
            int flip = CoinFlip();

            if (flip == 0)
            {
                Vector2 randomPos = RandomPos(10f, 10f);
                Instantiate(enemyDemonPrefab, randomPos, Quaternion.identity);
            }
            else
            {
                Vector2 randomPos = RandomPos(20f, 20f);
                Instantiate(enemySkeletonPrefab, randomPos, Quaternion.identity);
            }

            // Store the amount of enemies.
            GameManager.Instance.currentEnemies += 1;
        }

        for (int i = 0; i < GameManager.Instance.maxPickups; ++i)
        {
            var randomPos = RandomPos(20f, 20f);
            var randomIndex = Random.Range(0, pickupPrefabs.Length);
            Instantiate(pickupPrefabs[randomIndex], randomPos, Quaternion.identity);
        }
    }

    private void OnNewRound()
    {
        Debug.Log("New round needed.");

        SpawnEnemiesAndPickups();
    }

    // 0 or 1
    private static int CoinFlip()
    {
        return Random.Range(0, 2);
    }

    private Vector2 RandomPos(float x, float y)
    {
        return new Vector2(Random.Range(-x, x), Random.Range(-y, y));
    }
}
