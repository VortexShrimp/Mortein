using UnityEngine;

public class EnemyMoveController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private Rigidbody2D _rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       transform.position = Vector2.MoveTowards(transform.position, GameManager.Instance.playerPos, moveSpeed * Time.fixedDeltaTime);
    }
}
