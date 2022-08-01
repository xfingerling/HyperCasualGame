using System;
using UnityEngine;
using Object = UnityEngine.Object;

public static class LevelFactory
{
    private static readonly Transform _container;
    private static readonly GameObject _ballPrefab;
    private static readonly Cell _floorPrefab;
    private static readonly Cell _wallPrefab;

    static LevelFactory()
    {
        _container = new GameObject("[LevelContainer]").transform;

        _ballPrefab = Resources.Load<GameObject>("Gameplay/Ball");
        _floorPrefab = Resources.Load<Cell>("Gameplay/Floor");
        _wallPrefab = Resources.Load<Cell>("Gameplay/Wall");
    }

    public static GameObject CreateBall(Vector2Int spawnPoint)
    {
        var ball = Object.Instantiate(_ballPrefab, _container);
        ball.transform.position = new Vector3(spawnPoint.x, 0f, spawnPoint.y);
        return ball;
    }

    public static Cell CreateCell(CellType cellType, Vector2Int index)
    {
        Cell cell;

        switch (cellType)
        {
            case CellType.Floor:
                cell = Object.Instantiate(_floorPrefab, _container);
                break;
            case CellType.Wall:
                cell = Object.Instantiate(_wallPrefab, _container);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(cellType), cellType, null);
        }

        cell.Initialize(index);
        return cell;
    }
}

