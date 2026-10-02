using System.Collections;
using UnityEngine;

public class BulletTest : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(death());
    }
    void Update()
    {
        transform.Translate(Vector3.up * 3 * Time.deltaTime);
    }

    IEnumerator death()
    {
        yield return new WaitForSeconds(4);
        Destroy(gameObject);
    }
}
