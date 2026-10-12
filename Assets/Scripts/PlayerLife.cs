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

    void Start()
    {
        _lifePoint = (GameManager.Instance._playerHp);
        _circleCollider = GetComponent<CircleCollider2D>();
        _hitbox = FindFirstObjectByType<CircleCollider2D>();
    }

    public void SetHp(int amount)
    {
        _lifePoint += amount;
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
                StartCoroutine(Invincible());
                SetHp(-1);
            }
        }
    }

    IEnumerator TheEnd()
    {
        _playerMouvement.enabled = false;
        _blood.SetActive(true);
        yield return new WaitForSeconds(1);
        GameManager.Instance.StopGame();
        Destroy(gameObject);
    }

    IEnumerator Invincible()
    {
       _circleCollider.enabled = false;
       yield return new WaitForSeconds(0.3f);
       _circleCollider.enabled = true;
    }
}
