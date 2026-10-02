using UnityEngine;

public class GameManager : MonoBehaviour
{
    PlayerLife _playerHP;
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

    public void SetPlayerHP(int amount)
    {
        _playerHP.SetHp(amount);
    }
}
