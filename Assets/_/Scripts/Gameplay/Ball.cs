using System;
using System.Linq;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public event Action OnMovedEvent;

    private SwipeDetector _swipeDetector;
    private Vector2Int _currentPosition;

    private void Awake()
    {
        _swipeDetector = gameObject.AddComponent<SwipeDetector>();
    }

    public void Teleport(Vector2Int currentPosition)
    {
        _currentPosition = currentPosition;
        transform.position = new Vector3(_currentPosition.x, 0f, _currentPosition.y);
    }

    public void Activate()
    {
        _swipeDetector.OnSwipeEvent += OnSwipe;
    }

    public void Deactivate()
    {
        _swipeDetector.OnSwipeEvent -= OnSwipe;
    }

    private void OnSwipe(Direction direction)
    {
        var path = MainApp.instance.gameController.GetCellsPath(_currentPosition, direction);

        if (path.Count <= 0)
            return;

        foreach (var cell in path)
            cell.Complete();

        Teleport(path.Last().index);
        OnMovedEvent?.Invoke();
    }
}
