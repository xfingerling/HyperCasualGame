using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private Cell[,] _cells;
    private Ball _ball;

    public void Play(Level level)
    {
        Clear();

        var xLength = level.cells.GetLength(0);
        var zLength = level.cells.GetLength(1);

        _cells = new Cell[xLength, zLength];

        for (int x = 0; x < xLength; x++)
        {
            for (int y = 0; y < zLength; y++)
            {
                var cellType = level.cells[x, y];
                var index = new Vector2Int(x, y);
                var cell = LevelFactory.CreateCell(cellType, index);
                _cells[x, y] = cell;
            }
        }

        _ball = LevelFactory.CreateBall(level.spawnPoint);
        _ball.OnMovedEvent += OnBallMoved;
        _ball.Activate();

        var startCell = GetCellAt(level.spawnPoint);
        if (startCell != null)
            startCell.Complete();
    }

    public List<Cell> GetCellsPath(Vector2Int startIndex, Direction direction)
    {
        var path = new List<Cell>();

        var startCell = GetCellAt(startIndex);
        if (startCell == null)
            return path;

        while (true)
        {
            var nextCellIndex = startIndex.Add(direction);
            var nextCell = GetCellAt(nextCellIndex);

            if (nextCell == null || nextCell.type != CellType.Floor)
                break;

            path.Add(nextCell);
            startIndex = nextCellIndex;
        }

        return path;
    }

    public void Clear()
    {
        if (_cells != null)
        {
            for (var x = 0; x < _cells.GetLength(0); x++)
            {
                for (var y = 0; y < _cells.GetLength(1); y++)
                {
                    var cell = _cells[x, y];
                    Destroy(cell.gameObject);
                }
            }

            _cells = null;
        }

        if (_ball != null)
        {
            Destroy(_ball.gameObject);
            _ball = null;
        }
    }

    private Cell GetCellAt(Vector2Int index)
    {
        if (index.x < 0 || index.y < 0 || index.x >= _cells.GetLength(0) || index.y >= _cells.GetLength(1))
            return null;

        return _cells[index.x, index.y];
    }

    private void OnBallMoved()
    {
        for (var x = 0; x < _cells.GetLength(0); x++)
        {
            for (var y = 0; y < _cells.GetLength(1); y++)
            {
                var cell = _cells[x, y];
                if (cell.type != CellType.Floor)
                    continue;

                if (!cell.isCompleted)
                    return;
            }
        }

        _ball.Deactivate();
        MainApp.instance.windowManager.Show<LevelPassedWindow>();
    }
}
