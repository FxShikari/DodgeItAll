using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class bomb : MonoBehaviour
{
    [SerializeField] bool _Nbomb = false;
    [SerializeField] private GameObject _collider;
    [SerializeField] private float _detonationTime = 5;
    [SerializeField] private int _radTime = 5;
    private bool _follow;
    [SerializeField] private bool _Move = true;
    [SerializeField] private PlayerMouvement _target;
    [SerializeField] private AudioClip _explosionSfx;
    [SerializeField] GameObject _previewExplosion;
    [SerializeField] GameObject _visualpreview;
    float _time;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _target = FindFirstObjectByType<PlayerMouvement>();
        _collider.SetActive(false);
        if (_target != null)
        {
            transform.position = _target.transform.position;
        }
        StartCoroutine (wait());
        
    }

    private void Update()
    {
        _time += Time.deltaTime;
        float timeAjustement = (_time / _detonationTime);
        _visualpreview.transform.localScale = new Vector3(timeAjustement,timeAjustement, timeAjustement);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (_Move)
        {
            if (_target != null)
            {
                if (_follow == true)
                {
                    transform.position = Vector2.MoveTowards(transform.position, _target.transform.position, 1 * Time.deltaTime);
                }
            } 
        }
    }

    private void fire()
    {
        _previewExplosion.SetActive (false);
        _collider.SetActive (true);
        
    }

    IEnumerator Stop()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
    IEnumerator wait()
    {
        if (_Nbomb == false)
        {
            _follow = true;
        }
        yield return new WaitForSeconds(_detonationTime);
        _follow = false;
        SoundManager.Instance.PlayClip(_explosionSfx, transform.position, 1);
        fire();
        if (_Nbomb)
        {
            yield return new WaitForSeconds(_radTime);
        }
        StartCoroutine(Stop());
    }
}
