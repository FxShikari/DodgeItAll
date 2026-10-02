using UnityEngine;

public class BulletTest : MonoBehaviour
{
    void Update()
    {
        transform.Translate(Vector3.up * 1 * Time.deltaTime);
    }
}
