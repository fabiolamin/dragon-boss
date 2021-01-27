using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 _firstTouchPosition;
    private Vector2 _lastTouchPosition;
    private float _dragDistance = 5f;
    private Vector3 _direction = Vector3.zero;

    [SerializeField]
    [Tooltip("%")]
    private int _minimumOfScreen = 15;


    private void Awake()
    {
        _dragDistance = Screen.height * _minimumOfScreen / 100;
    }

    private void Update()
    {
        Move();

        Debug.Log(_direction);
    }

    private void Move()
    {
        if (Input.touchCount == 1)
        {
            GetTouchInput();
            SetDirection();
            MoveToWaypoint();
        }
    }

    private void GetTouchInput()
    {
        Touch touch = Input.GetTouch(0);
        SetTouchDeltaPosition(touch);
    }

    private void SetTouchDeltaPosition(Touch touch)
    {
        switch (touch.phase)
        {
            case TouchPhase.Began:
                _firstTouchPosition = touch.position;
                _lastTouchPosition = touch.position;
                break;
            case TouchPhase.Ended:
                _lastTouchPosition = touch.position;
                break;
        }
    }

    private void SetDirection()
    {
        _direction = Vector3.zero;

        if (IsDragging())
        {
            if (GetHorizontalDelta() > GetVerticalDelta())
            {
                SetHorizontalDirection();
            }
            else if (GetVerticalDelta() > GetHorizontalDelta())
            {
                SetVerticalDirection();
            }
        }
    }

    private void SetHorizontalDirection()
    {
        if (_lastTouchPosition.x > _firstTouchPosition.x)
        {
            _direction = new Vector3(1, 0, 0);
        }
        else if (_lastTouchPosition.x < _firstTouchPosition.x)
        {
            _direction = new Vector3(-1, 0, 0);
        }
    }

    private void SetVerticalDirection()
    {
        if (_lastTouchPosition.y > _firstTouchPosition.y)
        {
            _direction = new Vector3(0, 0, 1);
        }
        else if (_lastTouchPosition.y < _firstTouchPosition.y)
        {
            _direction = new Vector3(0, 0, -1);
        }
    }

    private bool IsDragging()
    {
        return (GetHorizontalDelta() > _dragDistance ||
            GetVerticalDelta() > _dragDistance);
    }

    private float GetVerticalDelta()
    {
        return Mathf.Abs(_lastTouchPosition.y - _firstTouchPosition.y);
    }

    private float GetHorizontalDelta()
    {
        return Mathf.Abs(_lastTouchPosition.x - _firstTouchPosition.x);
    }

    private void MoveToWaypoint()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, _direction, out hit, 5f))
        {
            if (hit.collider.CompareTag("Waypoint"))
            {
                transform.position = new Vector3(
                hit.transform.position.x,
                transform.position.y,
                hit.transform.position.z);
            }
        }
    }
}
