using System.Collections;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    private Player _player;
    private PlayerInput _playerInput;
    private PlayerAttack _playerAttack;
    private PlayerHealth _playerHealth;
    private Transform _waypoint;
    private HeroController _heroController;

    [SerializeField] private AudioClip _movementClip;
    [SerializeField] private SoundPlayer _soundPlayer;

    private void Start()
    {
        _player = GetComponent<Player>();
        _playerInput = GetComponent<PlayerInput>();
        _playerAttack = GetComponent<PlayerAttack>();
        _playerHealth = GetComponent<PlayerHealth>();
        _heroController = GetComponent<HeroController>();
    }

    private void Update()
    {
        if (_playerHealth.IsHealthy())
        {
            CheckMovement();
            Move();
        }
    }

    private void CheckMovement()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, _playerInput.SwipeDirection, out hit, 5f))
        {
            if (hit.collider.CompareTag("Waypoint"))
            {
                _waypoint = hit.transform;
                _soundPlayer.PlaySound(_movementClip);
                StartCoroutine(SetMovementAnimation());
            }
        }
    }

    private void Move()
    {
        if (_waypoint != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(
                _waypoint.position.x,
                transform.position.y,
                _waypoint.position.z), _player.PlayerData.Speed * Time.deltaTime);
        }
    }

    private IEnumerator SetMovementAnimation()
    {
        _playerAttack.CanAttack = false;
        transform.forward = _playerInput.SwipeDirection;
        _heroController.HeroAnimator.SetTrigger("Move");
        yield return new WaitForSeconds(_player.PlayerData.MovementTime);
        _playerAttack.CanAttack = true;
    }
}