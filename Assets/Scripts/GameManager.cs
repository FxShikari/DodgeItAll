using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    PlayerLife _playerHP;
    int _playerScore;
    [SerializeField]float _timer;
    void Start()
    {
        SetOfCursor();
    }

    private void Update()
    {
        _timer = Time.deltaTime;
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

    public void AddPoint(int amount)
    {
        _playerScore += amount;
    }
}
