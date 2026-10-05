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
    [SerializeField] GameObject _visualpreview;
    float _time;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _target = FindFirstObjectByType<PlayerMouvement>();
        transform.position = _target.transform.position;
        _collider.enabled = false;
        StartCoroutine (wait());
        
    }

    private void Update()
    {
        _time += Time.deltaTime;
        float timeAjustement = (_time / _detonationTime) - 0.05f;
        _visualpreview.transform.localScale = new Vector3(timeAjustement,timeAjustement, timeAjustement);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (_follow == true)
        {
            transform.position = Vector2.MoveTowards (transform.position, _target.transform.position, 1 * Time.deltaTime);
        }
    }

    private void fire()
    {
        Debug.Log("explosion");
        _previewExplosion.SetActive (false);
        _collider.enabled = true;
        StartCoroutine(Stop());
    }

    IEnumerator Stop()
    {
        yield return new WaitForSeconds(0.1f);
        _collider.enabled = false;
        Destroy(gameObject);
    }
    IEnumerator wait()
    {
        _follow = true;
        Debug.Log("waiting");
        yield return new WaitForSeconds(_detonationTime);
        _follow = false;
        fire();
    }
}
