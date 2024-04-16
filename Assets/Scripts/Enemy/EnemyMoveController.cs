using UnityEngine;

/// <summary>
/// Responsible for moving enemies.
/// Currently just moves them towards the player.
/// </summary>
public class EnemyMoveController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    // Update is called once per frame.
    void FixedUpdate()
    {
       transform.position = Vector2.MoveTowards(transform.position, GameManager.Instance.playerPos, moveSpeed * Time.fixedDeltaTime);
    }
}
