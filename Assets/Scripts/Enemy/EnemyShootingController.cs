using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootingController : MonoBehaviour
{
    [SerializeField] private float rangeSeconds;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float timeBetweenShots;

    // Keep track of time.
    private float _time; 

    private void FixedUpdate()
    {
        _time += Time.fixedDeltaTime;

        if (_time >= timeBetweenShots)
        {
        // Create a bullet.
        var bulletObject = Instantiate(bulletPrefab, transform.position, transform.rotation);

        // Set it to expire on a timer.
        Destroy(bulletObject, rangeSeconds);

        _time = 0;
        }
    }
}
