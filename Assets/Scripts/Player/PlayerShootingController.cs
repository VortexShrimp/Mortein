using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class PlayerShootingController : MonoBehaviour
{
    [SerializeField] private float rangeSeconds;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float timeBetweenShots;

    // Keep track of time.
    private float _time;

    private float _shots;

    private void FixedUpdate()
    {
        _time += Time.fixedDeltaTime;

        if (Input.GetKey(KeyCode.Mouse0) && _time >= timeBetweenShots)
        {
            if (GameManager.Instance.currentPlayer.name.CompareTo("Mortein SMG(Clone)") == 0)
            {
                _shots++;

                if (_shots <= 0)
                {
                    _time = 0;
                    return;
                }

                // Amount to shoot.
                if (_shots > 3)
                {
                    // Amount to skip.
                    _shots = -10;
                    _time = 0;
                    return;
                }

            }
            
                                        // Create a bullet.
                var bulletObject = Instantiate(bulletPrefab, transform.position, transform.rotation);

                // Set it to expire on a timer.
                Destroy(bulletObject, rangeSeconds);

            _time = 0;
        }
    }
}
