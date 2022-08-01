using UnityEngine;

public class Cell : MonoBehaviour
{
    public Vector2Int index { get; protected set; }

    public virtual void Initialize(Vector2Int index)
    {
        this.index = index;
        transform.position = new Vector3(index.x, 0f, index.y);
    }
}
