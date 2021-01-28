using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private Transform _waypoint;
    [SerializeField] private float _speed = 10f;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
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
