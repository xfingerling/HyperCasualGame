using UnityEngine;

public class Cell : MonoBehaviour
{
    [SerializeField] private Material _completeMaterial;
    [SerializeField] private MeshRenderer _meshRenderer;

    public Vector2Int index { get; protected set; }
    public CellType type { get; private set; }
    public bool isCompleted { get; private set; }

    public virtual void Initialize(Vector2Int index, CellType type)
    {
        this.index = index;
        this.type = type;
        transform.position = new Vector3(index.x, 0f, index.y);
    }

    public void Complete()
    {
        if (isCompleted)
            return;

        isCompleted = true;

        if (_meshRenderer == null || _completeMaterial == null)
            return;

        _meshRenderer.material = _completeMaterial;
    }
}
