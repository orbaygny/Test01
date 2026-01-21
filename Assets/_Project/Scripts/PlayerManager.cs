using UnityEngine;
using DG.Tweening;
public class PlayerManager : MonoBehaviour
{
    [SerializeField] GameObject[] _weapons;
    [SerializeField] Transform _firePoint;
    [SerializeField] Target _target;
    [SerializeField] Transform _playerSprite;
    Tween p;
    public void Attack(int index, float damage)
    {
        if (_target.transform.childCount != 0)
        {
            p.Complete();
            GameObject g = Instantiate(_weapons[index]);
            g.transform.position = _firePoint.position;
            g.SetActive(true);
           p = _playerSprite.DOLocalRotate(new Vector3(0, 0, -10f), 0.07f).SetEase(Ease.Linear).SetLoops(2, LoopType.Yoyo);
            Sequence seq = DOTween.Sequence();
            seq.Join(g.transform.DORotate(new Vector3(0, 0, -520),0.75f,RotateMode.FastBeyond360)).SetEase(Ease.Linear);
            seq.Join(g.transform.DOJump(_target.transform.position, Random.Range(0.5f,2f), 1, 0.75f).SetEase(Ease.Linear));
            seq.Play().OnComplete(() => { Destroy(g); 
            _target.TakeDamage(damage);
            });
        }
    }

}
