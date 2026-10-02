using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class StyleZone : MonoBehaviour
{
    GameManager gameManager ;
    [SerializeField] private LayerMask _projectileLayer;
    CircleCollider2D _styleZone;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _styleZone = GetComponent<CircleCollider2D>();
        gameManager = FindFirstObjectByType<GameManager>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if ((_projectileLayer & (1 << collision.transform.gameObject.layer)) > 0)
        {
            print("projectile");
            gameManager.AddPoint(10);
        }
    }

    

}
