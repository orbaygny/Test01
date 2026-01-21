using UnityEngine;

public class GridHighlighter : MonoBehaviour
{
    [SerializeField] Color32 _highlightColor;
    [SerializeField] Color32 _highlightColorPart;
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

    public void FullHightLight()
    {
        _sprite.color = _highlightColor;
    }
    public void PartHighlight()
    {
        _sprite.color = _highlightColorPart;
    }
    public void Reset()
    {
        _sprite.color = _defaultColor;
    }

}
