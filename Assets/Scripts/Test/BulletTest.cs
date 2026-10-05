using System;
using System.Collections;
using UnityEngine;

public class BulletTest : MonoBehaviour
{
    [SerializeField] bool _moving;
    [SerializeField] float _speed;
    private void Start()
    {
        StartCoroutine(death());
    }
    void Update()
    {
        if (_moving)
        {
            transform.Translate(Vector3.up * _speed * Time.deltaTime);
        }


    }

    IEnumerator death()
    {
        yield return new WaitForSeconds(4);
        Destroy(gameObject);
    }
}
