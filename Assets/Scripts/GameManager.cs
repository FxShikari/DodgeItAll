using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    PlayerLife _playerHP;
    int _playerScore;
    [SerializeField]TMP_Text _scoreTxt;
    [SerializeField]float _timer;
    void Start()
    {
        SetOfCursor();
        AddPoint(0);
    }

    private void Update()
    {
        _timer += Time.deltaTime;
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
        _scoreTxt.text = _playerScore.ToString();
    }
}
