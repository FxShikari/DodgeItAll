using Unity.VisualScripting;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    CircleCollider2D _hitbox;
    [SerializeField] LayerMask _projectileLayer;
    [SerializeField] private int _lifePoint = 1;
    [SerializeField] private CircleCollider2D _circleCollider;

    void Start()
    {
        _circleCollider = GetComponent<CircleCollider2D>();
        
    }

    private void FixedUpdate()
    {
        if (_lifePoint <= 0)
        {
            Death();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        {
            if ((_projectileLayer & (1 << collision.transform.gameObject.layer)) > 0)
            {
                print("boom");
                SetHp(-1);
            }
        }
    }

    public void SetHp(int amount)
    {
        _lifePoint += amount;
        if (_lifePoint <= 0)
        {
            Death();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
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
    }
}
