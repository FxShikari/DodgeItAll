using System.Collections;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    CircleCollider2D _hitbox;
    [SerializeField] PlayerMouvement _playerMouvement;
    [SerializeField] LayerMask _projectileLayer;
    [SerializeField] private int _lifePoint = 1;
    [SerializeField] private CircleCollider2D _circleCollider;
    [SerializeField] GameObject _blood;
    [SerializeField] AudioClip _deathSound;
     [SerializeField] AudioClip _hitSound;
    [SerializeField] Animator _sprite;

    void Start()
    {
        SetHp(GameManager.Instance._playerHp);
        _circleCollider = GetComponent<CircleCollider2D>();
        _hitbox = FindFirstObjectByType<CircleCollider2D>();
    }

    public void SetHp(int amount)
    {
        _lifePoint += amount;
        _lifePoint = Mathf.Clamp(_lifePoint, 0, 3);
        
        HpVerify();
    }

    public void StartHp(int amount)
    {
        _lifePoint = amount;
        _lifePoint = Mathf.Clamp(_lifePoint, 0, 3);
        HpVerify();
    }

    private void HpVerify()
    {
        _sprite.SetInteger("Hp", _lifePoint);

        if (_lifePoint <= 0)
        {
            //Death();
            StartCoroutine(TheEnd());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_circleCollider.IsTouching(collision))
        {
            if ((_projectileLayer & (1 << collision.transform.gameObject.layer)) > 0)
            {
                if (_lifePoint > 0)
                {
                    SoundManager.Instance.PlayClip(_hitSound, transform.position, 1f);
                    StartCoroutine(Invincible());
                    SetHp(-1);
                }
            }
        }
    }

    IEnumerator TheEnd()
    {
        _circleCollider.enabled = false;
        _playerMouvement.enabled = false;
        if (_deathSound != null)
        {
            SoundManager.Instance.PlayClip(_deathSound, transform.position, 0.8f);
        }
        _blood.SetActive(true);
        yield return new WaitForSeconds(1);
        GameManager.Instance.StopGame();
        Destroy(gameObject);
    }

    IEnumerator Invincible()
    {
       _circleCollider.enabled = false;
       yield return new WaitForSeconds(0.8f);
       _circleCollider.enabled = true;
    }
}
