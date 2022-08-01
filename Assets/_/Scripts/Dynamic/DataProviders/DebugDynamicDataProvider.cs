using System.Collections.Generic;
using UnityEngine;

public class DebugDynamicDataProvider : IDynamicDataProvider
{
    public List<Level> Levels { get; }

    public DebugDynamicDataProvider()
    {
        var cells = new[,]
        {
            {CellType.Wall, CellType.Wall, CellType.Wall, CellType.Wall, CellType.Wall},
            {CellType.Wall, CellType.Floor, CellType.Floor, CellType.Floor, CellType.Wall},
            {CellType.Wall, CellType.Floor, CellType.Wall, CellType.Floor, CellType.Wall},
            {CellType.Wall, CellType.Floor, CellType.Floor, CellType.Floor, CellType.Wall},
            {CellType.Wall, CellType.Wall, CellType.Wall, CellType.Wall, CellType.Wall},
        };

        var spawnPoint = new Vector2Int(1, 1);
        var level = new Level(cells, spawnPoint);
        Levels = new List<Level> { level };
    }
}
