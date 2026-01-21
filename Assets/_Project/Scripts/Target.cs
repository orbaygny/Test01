using UnityEngine;
using DG.Tweening;
public class Target : MonoBehaviour
{
    [SerializeField] float _hp;
    [SerializeField] SpriteRenderer _spriteRenderer;
    public void TakeDamage(float damage)
    {
        _hp -= damage;
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
        _spriteRenderer.enabled = true;
        Sequence seq = DOTween.Sequence();
        seq.Append(_spriteRenderer.transform.DOMoveX(transform.position.x, 1f).SetEase(Ease.Linear)).
            OnComplete(() => {
                _hp = 10;
                _spriteRenderer.transform.parent = transform; });
    }
}
