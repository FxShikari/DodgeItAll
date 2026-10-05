using System;
using System.Collections;
using UnityEngine;

public class bomb : MonoBehaviour
{
    [SerializeField] private Collider2D _collider;
    [SerializeField] private int _detonationTime = 5;
    [SerializeField] private bool _follow;
    [SerializeField] private PlayerMouvement _target;

    [SerializeField] GameObject _previewExplosion;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _target = FindFirstObjectByType<PlayerMouvement>();
        _collider.enabled = false;
        StartCoroutine (wait());
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_follow == true)
        {
            transform.position = Vector2.MoveTowards (transform.position, _target.transform.position, 5 * Time.deltaTime);
        }
    }

    private void fire()
    {
        Debug.Log("explosion");
        _previewExplosion.SetActive (false);
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
