using System.Collections;
using UnityEngine;

public class LaserBehaviour : MonoBehaviour
{

    [SerializeField] private Collider2D _rayon;
    [SerializeField] private int _chargeTime = 3;
    [SerializeField] private PlayerMouvement _target;
    [SerializeField] private GameObject _visualpreview;
    float _time;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _target = FindFirstObjectByType<PlayerMouvement>();
        _rayon.enabled = false;
        LaserAim();
        StartCoroutine(LaserShoot());
    }

    private void Update()
    {
        _time += Time.deltaTime;
        float timeAjustement = (_time / _chargeTime) - 0.05f;
        _visualpreview.transform.localScale = new Vector3(timeAjustement, 0, 0);
        Mathf.Clamp(_visualpreview.transform.localScale.x, 0, 0.5f);
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
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
