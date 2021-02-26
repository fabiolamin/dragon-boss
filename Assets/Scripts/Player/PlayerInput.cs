using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private PlayerAttack _playerAttack;
    private PlayerHealth _playerHealth;
    private Vector2 _firstTouchPosition;
    private Vector2 _lastTouchPosition;
    private float _swipeDistance;
    private float _tapDistance;
    private bool _hasTouched = false;

    [SerializeField] private float _minOfScreen = 15;
    [SerializeField] private float _minValueTap = 0.5f;

    public Vector3 SwipeDirection { get; private set; } = Vector3.zero;

    private void Awake()
    {
        _playerAttack = GetComponent<PlayerAttack>();
        _playerHealth = GetComponent<PlayerHealth>();
        _swipeDistance = Screen.height * _minOfScreen / 100;
        _tapDistance = Screen.height * _minValueTap / 100;
    }

    private void Update()
    {
        if (_playerHealth.IsAlive && !_playerHealth.WasHit)
            CheckInput();
    }

    private void CheckInput()
    {
        SwipeDirection = Vector3.zero;

        if (Input.touchCount == 1)
        {
            GetTouchInput();
            CheckTouch();
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
                _hasTouched = true;
                _firstTouchPosition = touch.position;
                _lastTouchPosition = touch.position;
                break;
            case TouchPhase.Ended:
                _lastTouchPosition = touch.position;
                _hasTouched = false;
                break;
        }
    }

    private void CheckTouch()
    {
        if (IsSwiping())
        {
            SetSwipeDirection();
        }
        else if (IsOneSingleTap())
        {
            SetTap();
        }
    }

    private void SetSwipeDirection()
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

    private bool IsSwiping()
    {
        return (GetHorizontalDelta() > _swipeDistance ||
            GetVerticalDelta() > _swipeDistance);
    }

    private float GetVerticalDelta()
    {
        return Mathf.Abs(_lastTouchPosition.y - _firstTouchPosition.y);
    }

    private float GetHorizontalDelta()
    {
        return Mathf.Abs(_lastTouchPosition.x - _firstTouchPosition.x);
    }

    private bool IsOneSingleTap()
    {
        return GetHorizontalDelta() < _tapDistance &&
        GetVerticalDelta() < _tapDistance && !_hasTouched;
    }

    private void SetTap()
    {
        _playerAttack.CastSpell();
    }
}
