using System;
using System.Collections;
using Lean.Touch;
using UnityEngine;
public class ItemManager : MonoBehaviour
{
    [SerializeField] Transform[] _itemParts;
    [SerializeField] GridCheker _gridChecker;
    [SerializeField] LeanSelectableByFinger selectable;
    [SerializeField] PlaceholderManager _placeholderManager;
    [SerializeField] bool _isPlaced;
    [SerializeField] bool _isSelected;
    public SpriteRenderer _spriteRenderer;
    Vector3 _pos;
    bool _isPlaceable;
    [SerializeField] float coolDown;
    [SerializeField] float damage;
    [SerializeField] PlayerManager _playerManager;
    [SerializeField] int _weaponIndex;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _pos = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
    
        if (selectable.IsSelected)
        {
            _spriteRenderer.material.SetFloat("_FillAmount", 1);
            _isSelected = true;
            transform.parent = null;
            _isPlaced = false;
            if (transform.hasChanged)
            {
                _isPlaceable = _gridChecker.FindClosest(_itemParts, gameObject.GetInstanceID());
                _pos = transform.position;
            }
        }

        else if (_isPlaceable && !_isPlaced && !selectable.IsSelected)
        {

            Debug.Log("Place");
            _gridChecker.PlaceItem(transform);
            _isPlaced = true;
            _isPlaceable = false;
            _isSelected = false;
            StartCoroutine(UseItem());
        }
        else if (_isSelected != selectable.IsSelected) {

            _placeholderManager.CheckPlaceholder(transform);
            _isSelected = selectable.IsSelected;
            _gridChecker.FindClosest(_itemParts, gameObject.GetInstanceID());
        }
    }

    IEnumerator UseItem()
    {
        float fill = 0;
        while (_isPlaced)
        {
            if(fill < 1)
            {
                fill += Time.deltaTime * coolDown;
                _spriteRenderer.material.SetFloat("_FillAmount", fill);
            }
            else
            {
                _playerManager.Attack(_weaponIndex,damage);
                fill = 0;
            }
            yield return null;
        }

    }

}
