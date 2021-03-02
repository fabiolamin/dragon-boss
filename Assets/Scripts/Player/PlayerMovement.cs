using System.Collections;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    private PlayerInput _playerInput;
    private PlayerAttack _playerAttack;
    private Transform _waypoint;
    private Animator _animator;
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _movementTime = 0.6f;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _playerAttack = GetComponent<PlayerAttack>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        CheckRaycast();
        MoveToWaypoint();
    }

    private void CheckRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, _playerInput.SwipeDirection, out hit, 5f))
        {
            if (hit.collider.CompareTag("Waypoint"))
            {
                _waypoint = hit.transform;
                StartCoroutine(SetMovementAnimation());
            }
        }
    }

    private IEnumerator SetMovementAnimation()
    {
        _playerAttack.CanAttack = false;
        transform.forward = _playerInput.SwipeDirection;
        _animator.SetTrigger("Move");
        yield return new WaitForSeconds(_movementTime);
        _playerAttack.CanAttack = true;
    }

    private void MoveToWaypoint()
    {
        if (_waypoint != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(
                _waypoint.position.x,
                transform.position.y,
                _waypoint.position.z), _speed * Time.deltaTime);
        }
    }
}
