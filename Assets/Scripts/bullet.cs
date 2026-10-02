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
        transform.Translate( _bulletSpeed * Time.deltaTime, 0, 0);
    }

}
