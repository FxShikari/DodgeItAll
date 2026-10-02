using Mono.Cecil;
using System;
using System.Collections;
using UnityEngine;

public class bomb : MonoBehaviour
{
    [SerializeField] private Collider2D _collider;
    [SerializeField] private int _detonationTime = 5;
    [SerializeField] private bool _follow;
    [SerializeField] private GameObject _target;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _collider.enabled = false;
        StartCoroutine (wait());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_follow == true)
        {
            transform.position = Vector2.MoveTowards (transform.position, _target.transform.position, 10 * Time.deltaTime);
        }
    }

    private void fire()
    {
        Debug.Log("explosion");
        _collider.enabled = true;
    }


    IEnumerator wait()
    {
        _follow = true;
        Debug.Log("waiting");
        yield return new WaitForSeconds(_detonationTime);
        _follow = false;
        fire();
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
