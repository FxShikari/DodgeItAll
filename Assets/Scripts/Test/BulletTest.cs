using System.Collections;
using UnityEngine;

public class BulletTest : MonoBehaviour
{
    [SerializeField] bool _moving;
    [SerializeField] bool _zigzag;
    [SerializeField] float _speed;
    float _zigzagPower;
    [SerializeField] float _zigzagPowerP;
    [SerializeField] float _zigzagPowerN;
    private void Start()
    {
        if (_zigzag)
        {
            StartCoroutine(Switch());
        }
        StartCoroutine(death());
    }
    void Update()
    {
        if (_moving)
        {
            if (_zigzag)
            {
                transform.Translate(new Vector3(_zigzagPower, 1 , 0) * _speed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector3.up * _speed * Time.deltaTime);
                print("ok");
            }
        }
    }

    IEnumerator Switch()
    {

        _zigzagPower = _zigzagPowerP;
        yield return new WaitForSeconds(0.1f);
        _zigzagPower = _zigzagPowerN;
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(Switch());

    }

    IEnumerator death()
    {
        yield return new WaitForSeconds(4);
        Destroy(gameObject);
    }
}
