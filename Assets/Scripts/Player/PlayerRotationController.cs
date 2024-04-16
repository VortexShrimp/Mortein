using UnityEngine;

public class PlayerRotationController : MonoBehaviour
{
    private void FixedUpdate()
    {
        var mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var direction = new Vector2(
            mouseWorldPos.x - transform.position.x,
            mouseWorldPos.y - transform.position.y
        );

        transform.up = direction;
    }
}
