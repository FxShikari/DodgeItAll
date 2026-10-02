using UnityEngine;

public class PlayerSize : MonoBehaviour
{
    [SerializeField, Range(0,1.5f)] private float _playerSize;
    [SerializeField] CircleCollider2D _styleZone;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void OnEnable()
    {
        transform.localScale = new Vector3(_playerSize, _playerSize, _playerSize);
        _styleZone.radius = _playerSize * 1.3f;
    }
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(this.transform.position, _styleZone.radius);
    }
}
