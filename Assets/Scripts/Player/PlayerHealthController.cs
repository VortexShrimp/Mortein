using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthController : MonoBehaviour
{
    public delegate void PlayerHealthDecreaseHandler(int amount);
    public static event PlayerHealthDecreaseHandler onPlayerHealthDecrease;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ArrowBullet"))
        {
            GameManager.Instance.playerHealth -= 1;
            onPlayerHealthDecrease?.Invoke(1);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("DemonBullet"))
        {
            GameManager.Instance.playerHealth -= 5;
            onPlayerHealthDecrease?.Invoke(5);
            Destroy(other.gameObject);
        }

        if (GameManager.Instance.playerHealth <= 0)
        {
            SceneManager.LoadSceneAsync("End", LoadSceneMode.Single);
        }
    }
}
