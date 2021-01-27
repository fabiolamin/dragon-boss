using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Vector2 _firstTouchPosition;
    private Vector2 _lastTouchPosition;
    private float _dragDistance = 5f;

    [SerializeField]
    [Tooltip("%")]
    private int _minimumOfScreen = 15;

    public Vector3 SwipeDirection { get; private set; } = Vector3.zero;

    private void Awake()
    {
        _dragDistance = Screen.height * _minimumOfScreen / 100;
    }

    private void Update()
    {
        CheckInput();
    }

    private void CheckInput()
    {
        SwipeDirection = Vector3.zero;

        if (Input.touchCount == 1)
        {
            GetTouchInput();
            SetSwipeDirection();
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

    private void SetSwipeDirection()
    {
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
            SwipeDirection = new Vector3(1, 0, 0);
        }
        else if (_lastTouchPosition.x < _firstTouchPosition.x)
        {
            SwipeDirection = new Vector3(-1, 0, 0);
        }
    }

    private void SetVerticalDirection()
    {
        if (_lastTouchPosition.y > _firstTouchPosition.y)
        {
            SwipeDirection = new Vector3(0, 0, 1);
        }
        else if (_lastTouchPosition.y < _firstTouchPosition.y)
        {
            SwipeDirection = new Vector3(0, 0, -1);
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
}
