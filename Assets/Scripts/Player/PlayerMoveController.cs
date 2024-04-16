using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMoveController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        var moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * Time.fixedDeltaTime;
        var desiredPos = _rigidbody.position + moveInput * moveSpeed;

        GameManager.Instance.playerPos = desiredPos;

        transform.position = desiredPos;

        //_rigidbody.MovePosition(desiredPos);
    }
}
