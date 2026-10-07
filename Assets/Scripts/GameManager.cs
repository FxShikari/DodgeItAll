using System.Collections;
using TMPro;
using Unity.VisualScripting;
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
    public int _playerHp = 1;

    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        // If there is an instance, and it's not me, kill myself NOW.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }



    void Start()
    {
        _spawnerManager = FindFirstObjectByType<SpawnerManager>();
        _playerHP = FindFirstObjectByType<PlayerLife>();
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
        StartCoroutine(TimePoint());
        if (_spawnerManager != null)
        {
            _spawnerManager.StarterParckProMax();
        }
    }

    public void PlayerHpAmount(int amount)
    {
        _playerHp = amount;
    }
}
