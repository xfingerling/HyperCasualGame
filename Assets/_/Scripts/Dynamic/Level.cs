using UnityEngine;

public class Level
{
    public CellType[,] cells { get; }
    public Vector2Int spawnPoint { get; }

    public Level(CellType[,] cells, Vector2Int spavnPoint)
    {
        this.cells = cells;
        this.spawnPoint = spavnPoint;
    }
}
