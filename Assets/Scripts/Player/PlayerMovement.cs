using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    private PlayerInput _playerInput;
    private PlayerAttack _playerAttack;
    private PlayerHealth _playerHealth;
    private PlayerAnimation _playerAnimation;
    private Transform _waypoint;
    private Animator _animator;
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _delayToDefaultForward = 0.6f;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _playerAttack = GetComponent<PlayerAttack>();
        _playerHealth = GetComponent<PlayerHealth>();
        _playerAnimation = GetComponent<PlayerAnimation>();
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
                _playerAttack.CanAttack = false;
                StartCoroutine(_playerAnimation.SetMovementAnimation());
            }
        }
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
