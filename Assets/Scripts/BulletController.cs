using UnityEngine;

public class BulletController : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    [SerializeField] private float bulletSpeed;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = transform.up * bulletSpeed * Time.fixedDeltaTime;
    }
};
