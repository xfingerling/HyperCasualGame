using System;
using UnityEngine;

public static class Extensions
{
    public static Vector2Int Add(this Vector2Int index, Direction direction)
    {
        switch (direction)
        {
            case Direction.Up:
                return index + Vector2Int.up;
            case Direction.Down:
                return index + Vector2Int.down;
            case Direction.Right:
                return index + Vector2Int.right;
            case Direction.Left:
                return index + Vector2Int.left;
            default:
                throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
        }
    }
}
