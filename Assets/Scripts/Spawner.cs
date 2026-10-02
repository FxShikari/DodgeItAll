using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject _projToSpawn;
    [SerializeField] GameObject[] _spawnPoints;
    [SerializeField] GameObject _father;
    [SerializeField] bool _spin;
    [SerializeField] bool _move;

    [SerializeField] Transform _target;
    [SerializeField] float _Mspeed;
    [SerializeField] float _Rspeed;
    [SerializeField] float _Fspeed;

    bool _canFire = true;
    void Start()
    {
        
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
        yield return new WaitForSeconds(_Fspeed);
        foreach (GameObject Sp in _spawnPoints)
        {
           GameObject bullet = Instantiate(_projToSpawn,Sp.transform.position,Sp.transform.rotation);
            bullet.transform.parent = _father.transform;
            _canFire = true;
        }
        
    }
}
