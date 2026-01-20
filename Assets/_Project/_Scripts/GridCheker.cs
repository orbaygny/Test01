using System.Collections.Generic;
using Lean.Touch;
using NUnit.Framework;
using UnityEngine;

public class GridCheker : MonoBehaviour
{
    [SerializeField] List<GridHighlighter> _gridList;
    [SerializeField] float _treshold;
    List<GridHighlighter> _gridList2;
    List<Vector3[]> poses;
    private void Start()
    {
        _gridList2 = new List<GridHighlighter>();
    }
    public void AddItem(Vector3[] pos)
    {

    }
    public void FindClosestGrid(Vector3[] pos)
    {
        ResetHighlight();
        _gridList2.Clear();
        for (int j = 0; j < pos.Length; j++)
        {
            Vector3 result = _gridList[0].transform.position;
            int r = 0;
            for (int i = 1; i < _gridList.Count; i++)
            {
                float disTmp = Vector3.Distance(result, pos[j]);
                float disGrid = Vector3.Distance(_gridList[i].transform.position, pos[j]);
                if (disGrid < disTmp)
                {
                    result = _gridList[i].transform.position;
                    r = i;
                }
            }
            if(Vector3.Distance(result, pos[j])< _treshold)
            {
                _gridList2.Add(_gridList[r]);
                _gridList[r].Hightlight(true);
            }
        }
    }


    void ResetHighlight()
    {
        for (int i = 0; i < _gridList.Count; i++)
        {
            if (!_gridList2.Contains(_gridList[i]))
                _gridList[i].Hightlight(false);
        }        
    }
}
