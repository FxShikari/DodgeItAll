using UnityEngine;

public class PlayerMouvement : MonoBehaviour
{
    Camera _camera;
    Vector3 _oldPose;

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
        //orientation(_worldPose);
        _oldPose = _worldPose;
    }

    /*private void orientation(Vector3 newPos)
    {
        float angle = Vector2.Angle(_oldPose, newPos);
        transform.rotation = Quaternion.Euler(0,0,angle);
    }*/
}
