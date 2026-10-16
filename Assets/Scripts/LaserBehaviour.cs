using System.Collections;
using UnityEngine;

public class LaserBehaviour : MonoBehaviour
{
    [SerializeField] private float _chargeTime = 3;
    [SerializeField] private PlayerMouvement _target;
    [SerializeField] private GameObject _visualpreview;
    [SerializeField] private GameObject _preview;
    [SerializeField] private GameObject _laser;
    [SerializeField] private AudioClip _laserShoot;
    [SerializeField] private AudioClip _laserSpawn;
    float _time;
   [SerializeField] bool _lookAt;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _target = FindFirstObjectByType<PlayerMouvement>();
        if (_laserSpawn != null)
        {
            SoundManager.Instance.PlayClip(_laserSpawn, transform.position,0.5f);
        }
        if (_lookAt)
        {
            if (_target != null)
            {
                LaserAim();
            } 
        }
        StartCoroutine(LaserShoot());
    }

    private void Update()
    {
        if (_chargeTime > _time)
        {
            _time += Time.deltaTime;
            float timeAjustement = ((_time / (_chargeTime)) / 1.5f);
            _visualpreview.transform.localScale = new Vector3(timeAjustement, 1, 1);
        }
    }

    private void LaserAim()
    {
        Vector3 Look = transform.InverseTransformPoint(_target.transform.position);
        float Angle = Mathf.Atan2(Look.y, Look.x) * Mathf.Rad2Deg - 89.5f;

        transform.Rotate(0, 0, Angle);
    }

    IEnumerator LaserShoot()
    {
        yield return new WaitForSeconds(_chargeTime);
        _preview.SetActive(false);
        _laser.SetActive(true);
        SoundManager.Instance.PlayClip(_laserShoot, transform.position, 0.5f);
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
