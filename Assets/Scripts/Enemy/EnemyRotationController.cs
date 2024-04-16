using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyRotationController : MonoBehaviour
{
    private void Update()
    {
        var playerWorldPos = GameManager.Instance.playerPos;
        var direction = new Vector2(
            playerWorldPos.x - transform.position.x,
            playerWorldPos.y - transform.position.y
        );

        transform.up = direction;
    }
}
