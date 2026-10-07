using System.Collections;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    CircleCollider2D _hitbox;
    [SerializeField] LayerMask _projectileLayer;
    [SerializeField] private int _lifePoint;
    [SerializeField] private CircleCollider2D _circleCollider;

    bool _invincible;

    private void Awake()
    {
        SetHp(GameManager.Instance._playerHp);
    }

    void Start()
    {
        _circleCollider = GetComponent<CircleCollider2D>();
        _hitbox = FindFirstObjectByType<CircleCollider2D>();
    }

    private void FixedUpdate()
    {
        if (_lifePoint <= 0)
        {
            Death();
        }
    }

    public void SetHp(int amount)
    {
        if (_invincible == false)
        {
            _lifePoint += amount;
            if (_lifePoint <= 0)
            {
                Death();
            }
            InvincibleTime();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((_projectileLayer & (1 << collision.transform.gameObject.layer)) > 0)
        {
            print("boom");
            SetHp(-1);
        }
    }
    private void Death()
    {
        Debug.Log("you dead broda");
        Destroy(gameObject);
    }

    IEnumerator InvincibleTime()
    {
        _invincible = true;
        yield return new WaitForSeconds(1.5f);
        _invincible = false;
    }
}
