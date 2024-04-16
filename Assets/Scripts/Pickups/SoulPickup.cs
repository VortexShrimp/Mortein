using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulPickup : MonoBehaviour
{
    public delegate void SoulPickedUpHandler();
    public static SoulPickedUpHandler onSoulPickedUp;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.playerSoulCount++;
            Destroy(gameObject);

            onSoulPickedUp?.Invoke();
        }
    }
}
