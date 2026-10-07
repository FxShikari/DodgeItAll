using System.Collections;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    PlayerLife _playerHP;
    int _playerScore;
    SpawnerManager _spawnerManager;
    [SerializeField]TMP_Text _scoreTxt;
    [SerializeField]TMP_Text _decompte;
    [SerializeField]float _countdown;
    [SerializeField] bool _isStarted = false;
    [SerializeField] bool _inGame = false;
    void Start()
    {
        _spawnerManager = FindFirstObjectByType<SpawnerManager>();
        //Time.timeScale = 0.25f;
        SetOfCursor();
        if (_inGame)
        {
            AddPoint(0);

        }
    }

    private void Update()
    {
        if (_inGame)
        {
            if (_isStarted == false)
            {
                _countdown -= Time.deltaTime;
                _decompte.text = ((int)_countdown).ToString();
                if ((int)_countdown == 0)
                {

                    _decompte.text = ("DodgeItAll");
                }
                if (_countdown <= -1)
                {
                    StartGame();
                    _isStarted = true;
                }
            }
        }
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
    
    IEnumerator TimePoint()
    {
        yield return new WaitForSeconds(5);
        AddPoint(10);
        TimePoint();
    }

    public void AddPoint(int amount)
    {
        _playerScore += amount;
        _scoreTxt.text = _playerScore.ToString();
    }

    private void StartGame()
    {
        _decompte.gameObject.SetActive(false);
        _scoreTxt.gameObject.SetActive(true);
        if (_spawnerManager != null)
        {
            _spawnerManager.StarterParckProMax();
        }
        StartCoroutine(TimePoint());
    }
}
