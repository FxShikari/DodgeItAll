using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject _projToSpawn;
    [SerializeField] GameObject[] _spawnPoints;
    [SerializeField] Poubelle _father;
    [SerializeField] bool _spin;
    [SerializeField] bool _move;
    [SerializeField] bool _randomSpawn = false;

    [SerializeField] float _Mspeed;
    [SerializeField] float _Rspeed;
    [SerializeField] float _FireRate;

    [SerializeField] float _lifeTime;
    bool _canFire = true;
    void Start()
    {
        _father = FindFirstObjectByType<Poubelle>();
        StartCoroutine(LifeTime(_lifeTime));
        StartCoroutine(Delay());
    }

    // Update is called once per frame
    void Update()
    {
        if (_spin)
        {
            Spin(_Rspeed);
        }
        if (_move)
        {
            Move(_Mspeed);
        }
        if (_canFire)
        {
            StartCoroutine(Fire());
        }
    }

    private void Spin(float speed)
    {
        transform.Rotate(new Vector3(0,0,1), speed * Time.deltaTime);
    }

    private void Move(float speed)
    {
        transform.Translate(Vector3.up * _Mspeed * Time.deltaTime);
    }

    IEnumerator Fire()
    {
        _canFire = false;
        yield return new WaitForSeconds(_FireRate);

        if (_randomSpawn)
        {
            GameObject bullet = Instantiate(_projToSpawn, new Vector3(RandomInt(-8,8),RandomInt(-4,4),0), transform.rotation);
            bullet.transform.parent = _father.transform;
            _canFire = true;
        }
        else
        {
            foreach (GameObject Sp in _spawnPoints)
            {
                GameObject bullet = Instantiate(_projToSpawn, Sp.transform.position, Sp.transform.rotation);
                bullet.transform.parent = _father.transform;
                _canFire = true;
            }
        }
    }

    IEnumerator LifeTime(float amout)
    {
        yield return new WaitForSeconds(amout);
        Destroy(gameObject);
    }

    private int RandomInt(int min, int max)
    {
        int result = Random.Range(min, max);
        return result;
    }

    IEnumerator Delay()
    {
        _canFire = false;
        yield return new WaitForSeconds(1);
        _canFire = true;
        StartCoroutine(Fire());
    }
}
