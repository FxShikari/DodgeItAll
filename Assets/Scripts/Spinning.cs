using UnityEngine;

public class Spinning : MonoBehaviour
{
    [SerializeField] float _speed;
    // Update is called once per frame
    void Update()
    {
        Spin(_speed);
    }
    private void Spin(float speed)
    {
        transform.Rotate(new Vector3(0, 0, 1), speed * Time.deltaTime);
    }
}
