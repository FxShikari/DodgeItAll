using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Start()
    {
        SetOfCursor();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetOfCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }
}
