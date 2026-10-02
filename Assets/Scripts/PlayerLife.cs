using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private int _lifePoint = 1;
    [SerializeField] private CircleCollider2D _circleCollider;
    [SerializeField] private LayerMask _projectileLayer;

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

    public void SetHp(int amount)
    {
        _lifePoint += amount;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    private void Death()
    {
        Debug.Log("you dead broda");
    }
}
