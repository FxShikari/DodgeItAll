using UnityEngine;

public class PlayerMouvement : MonoBehaviour
{
    Camera _camera;

    void Start()
    {
        _camera = Camera.main;
    }

    void FixedUpdate()
    {
      SetPosition();
    }

    private void SetPosition()
    {
        Vector3 _worldPose = _camera.ScreenToWorldPoint(Input.mousePosition);
        _worldPose.z = 0f;
        transform.position = _worldPose;
    }
}
