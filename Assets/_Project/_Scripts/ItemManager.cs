using System.Collections;
using Lean.Touch;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField] Transform[] _itemParts;
    [SerializeField] GridCheker _gridChecker;
    [SerializeField] LeanSelectableByFinger selectable;
    Vector3[] _positions;
    Vector3 _pos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _positions = new Vector3[_itemParts.Length];
       _pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.frameCount % 30 == 0)
        {
            Debug.Log(Mathf.Abs(gameObject.GetInstanceID()));
            for (int i = 0; i < _itemParts.Length; i++)
            {
                _positions[i] = _itemParts[i].transform.position;
            }

            _gridChecker.FindClosestGrid(_positions);

            _pos = transform.position;
        }
    }

}
