using System.Collections;
using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField] private Transform _bullet;
    [SerializeField] private float _bulletSpeed = 5;
    //[SerializeField] private Rigidbody2D _bullet;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.forward, _bulletSpeed * Time.deltaTime);
    }

    //private void fire()
    //{
    //    StartWait();
    //    Rigidbody2D bullet = (Rigidbody2D)Instantiate(_bullet, transform.position, transform.rotation);
    //    bullet.linearVelocity = transform.forward * _bulletSpeed;
    //}

}
