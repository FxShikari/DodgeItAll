using System;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject[] _ProjToSpawn;
    [SerializeField] bool _spin;
    [SerializeField] bool _move;

    [SerializeField] Transform _target;
    [SerializeField] float _Mspeed;
    [SerializeField] float _Rspeed;
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
    }

    private void Spin(float speed)
    {
        transform.Rotate(new Vector3(0,0,1), speed * Time.deltaTime);
    }

    private void Move(float speed)
    {
        transform.Translate(Vector3.up * _Mspeed * Time.deltaTime);
    }
}
