using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class Target : MonoBehaviour
{
    [SerializeField] float _hp;
    [SerializeField] SpriteRenderer _spriteRenderer;
    [SerializeField] Image _fill;
    public void TakeDamage(float damage)
    {
        _hp -= damage;
        _fill.fillAmount = _hp / 10f;
        if (_hp <= 0)
        {
            _spriteRenderer.transform.parent = null;
            _spriteRenderer.enabled = false;
            RePosition();
        }
    }


    void RePosition()
    {
        _spriteRenderer.transform.position = transform.position - Vector3.right*-2;
        _fill.fillAmount = 1f;
        _spriteRenderer.enabled = true;
        Sequence seq = DOTween.Sequence();
        seq.Append(_spriteRenderer.transform.DOMoveX(transform.position.x, 1f).SetEase(Ease.Linear)).
            OnComplete(() => {
                _hp = 10;
                _spriteRenderer.transform.parent = transform; });
    }
}
