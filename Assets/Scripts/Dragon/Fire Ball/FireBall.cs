using UnityEngine;

public class FireBall : MonoBehaviour
{
    private Rigidbody _fireBallRb;
    [SerializeField] private float _speed = 10f;

    private void Awake()
    {
        _fireBallRb = GetComponent<Rigidbody>();
        _fireBallRb.velocity = -transform.forward * _speed;
    }
}
