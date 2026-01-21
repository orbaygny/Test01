using System.Collections;
using System.Collections.Generic;
using Lean.Touch;
using UnityEngine;

public class GridCheker : MonoBehaviour
{
    [SerializeField] float _treshold;
    [SerializeField] List<GameGrid> _sceneGrids;
    List<GameGrid> _gridsToHighlight;
    Dictionary<Vector2Int, GameGrid> _grids;
    Dictionary<int, GameGrid[]> _nonEmptyGrids;
    private void Awake()
    {
        _grids = new Dictionary<Vector2Int, GameGrid>();
        _gridsToHighlight = new List<GameGrid>();
        _nonEmptyGrids = new Dictionary<int, GameGrid[]>();
    }
    private void Start()
    {
        for (int i = 0; i < _sceneGrids.Count; i++)
        {
            _grids.Add(_sceneGrids[i].Id, _sceneGrids[i]);
        }
    }
    public void PlaceItem(Transform pivot)
    {
        GameGrid current = _grids[Vector2Int.one];
        foreach (GameGrid g in _grids.Values)
        {
            float disCurrent = Vector3.Distance(current.Position, pivot.position);
            float disG = Vector3.Distance(g.Position, pivot.position);
            if (disG < disCurrent)
            {
                current = g;
            }
        }
        GameGrid[] grids = _gridsToHighlight.ToArray();
        _nonEmptyGrids.Add(pivot.gameObject.GetInstanceID(), grids);
        for (int i = 0; i < _gridsToHighlight.Count; i++)
        {
            _gridsToHighlight[i].IsEmpty = false;
        }
        _gridsToHighlight.Clear();
        pivot.position = current.Position;
    }
    public bool FindClosest(Transform[] parts, int ID)
    {
        if (_nonEmptyGrids.TryGetValue(ID, out GameGrid[] grids))
        {

            ResetWithID(grids);
            _nonEmptyGrids.Remove(ID);
        }
        _gridsToHighlight.Clear();
        ResetHighlight();
        for (int i = 0; i < parts.Length; i++)
        {
            GameGrid current = _grids[Vector2Int.one];

            foreach (GameGrid g in _grids.Values)
            {
                float disCurrent = Vector3.Distance(current.Position, parts[i].position);
                float disG = Vector3.Distance(g.Position, parts[i].position);
                if (disG < disCurrent)
                {
                    current = g;
                }

            }
            if (Vector3.Distance(current.Position, parts[i].position) < _treshold && current.IsEmpty)
            {
                if (!_gridsToHighlight.Contains(current))
                    _gridsToHighlight.Add(current);
            }
        }

        for (int i = 0; i < _gridsToHighlight.Count; i++)
        {
            if (_gridsToHighlight.Count == parts.Length)
            {
                _gridsToHighlight[i].Highlighter.FullHightLight();

                if (i == parts.Length - 1)
                    return true;
            }
            else
            {
                _gridsToHighlight[i].Highlighter.PartHighlight();
            }
        }
        return false;
    }

    void ResetHighlight()
    {
        foreach (GameGrid grid in _grids.Values)
        {
            if (grid.IsEmpty)
                grid.Highlighter.Reset();
        }
    }
    void ResetWithID(GameGrid[] grids)
    {
        for (int i = 0; i < grids.Length; i++)
        {
            grids[i].IsEmpty = true;
            grids[i].Highlighter.Reset();
        }
    }
}
