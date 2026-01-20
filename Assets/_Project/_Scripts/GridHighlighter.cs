using UnityEngine;

public class GridHighlighter : MonoBehaviour
{
    [SerializeField] Color32 _highlightColor;
    SpriteRenderer _sprite;
    Color32 _defaultColor;

    private void Start()
    {
        _sprite = GetComponent<SpriteRenderer>();
        _defaultColor = _sprite.color;
    }
    public void Hightlight(bool highlight){

        if (highlight) 
            _sprite.color = _highlightColor;
        else 
            _sprite.color = _defaultColor;
   }

}
