using UnityEngine;

public class GameGrid : MonoBehaviour
{
    public Vector3 Position;
    public Vector2Int Id;
    public bool IsEmpty;
    public GridHighlighter Highlighter;
    private void Awake()
    {
        Position = transform.position;
        Id = GenerateId();
        IsEmpty = true;
        Highlighter = GetComponent<GridHighlighter>();
    }

    Vector2Int GenerateId()
    {
        string name = gameObject.name;
        string[] parts = name.Split('x');
        int x = int.Parse(parts[0]);
        int y = int.Parse(parts[1]);
        return new Vector2Int(x, y);
    }
}
