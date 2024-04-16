using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public delegate void HealthPickedUpHandler(int amount);
    public static HealthPickedUpHandler onHealthPickedUp;

    [SerializeField] private int healthAmount;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            onHealthPickedUp?.Invoke(healthAmount);
        }
    }
}
