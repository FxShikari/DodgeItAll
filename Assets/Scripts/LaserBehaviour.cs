using System.Collections;
using UnityEngine;

public class LaserBehaviour : MonoBehaviour
{

    [SerializeField] private Collider2D _rayon;
    [SerializeField] private int _chargeTime = 3;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rayon.enabled = false;
        StartCoroutine(LaserShoot());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator LaserShoot()
    {
        yield return new WaitForSeconds(_chargeTime);
        _rayon.enabled = true;
    }
}
