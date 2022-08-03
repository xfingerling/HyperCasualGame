using System;
using UnityEngine;

public class SwipeDetector : MonoBehaviour
{
    public event Action<Direction> OnSwipeEvent;

    private bool _isStarted;
    private Vector2 _startPosition;

    private void Update()
    {
#if UNITY_EDITOR
        CheckKeyboard();
#else
        CheckTouch();
#endif
    }

    private void CheckKeyboard()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            OnSwipeEvent?.Invoke(Direction.Up);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            OnSwipeEvent?.Invoke(Direction.Right);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            OnSwipeEvent?.Invoke(Direction.Down);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            OnSwipeEvent?.Invoke(Direction.Left);
        }
    }

    private void CheckTouch()
    {
        if (Input.touchCount <= 0)
            return;

        var touch = Input.GetTouch(0);

        switch (touch.phase)
        {
            case TouchPhase.Began:
                _isStarted = true;
                _startPosition = touch.position;
                break;
            case TouchPhase.Moved:
                if (!_isStarted)
                    return;

                var direction = (touch.position - _startPosition).normalized;

                if (Mathf.Abs(direction.y) > Mathf.Abs(direction.x))
                {
                    if (direction.y > 0)
                    {
                        OnSwipeEvent?.Invoke(Direction.Up);
                        _isStarted = false;
                    }
                    else if (direction.y < 0)
                    {
                        OnSwipeEvent?.Invoke(Direction.Down);
                        _isStarted = false;
                    }
                }
                else
                {
                    if (direction.x > 0)
                    {
                        OnSwipeEvent?.Invoke(Direction.Right);
                        _isStarted = false;
                    }
                    else if (direction.x < 0)
                    {
                        OnSwipeEvent?.Invoke(Direction.Left);
                        _isStarted = false;
                    }
                }
                break;
        }
    }
}
