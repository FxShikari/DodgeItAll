using System.Collections;
using UnityEngine;

public class LaserBehaviour : MonoBehaviour
{

    [SerializeField] private Collider2D _rayon;
    [SerializeField] private int _chargeTime = 3;
    [SerializeField] private GameObject _target;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rayon.enabled = false;
        StartCoroutine(LaserShoot());
        LaserAim();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LaserAim()
    {
        Vector3 Look = transform.InverseTransformPoint(_target.transform.position);
        float Angle = Mathf.Atan2(Look.y, Look.x) * Mathf.Rad2Deg - 90;

        transform.Rotate(0, 0, Angle);
    }

    IEnumerator LaserShoot()
    {
        yield return new WaitForSeconds(_chargeTime);
        _rayon.enabled = true;
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
