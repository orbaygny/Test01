using System.Collections.Generic;
using UnityEngine;

public class PlaceholderManager : MonoBehaviour
{
    [SerializeField] Transform[] _placeholders;
    Dictionary<int, Placeholder> _placeholderDict;

    private void Awake()
    {
        _placeholderDict = new Dictionary<int, Placeholder>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < _placeholders.Length; i++)
        {
            Placeholder p = new(_placeholders[i].position, true);
            _placeholderDict.Add(i, p);
        }
    }

    public void CheckPlaceholder(Transform t)
    {
        for (int i = 0; i < _placeholders.Length; i++)
        {
            if (_placeholders[i].childCount == 0)
            {
                t.transform.position = _placeholders[i].position;
                t.parent = _placeholders[i];
                break;
            }
        }
    }
}
