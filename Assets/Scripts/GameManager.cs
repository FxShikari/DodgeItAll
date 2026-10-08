using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    PlayerLife _playerHP;
    public int _playerScore;
    SpawnerManager _spawnerManager;
    [SerializeField]TMP_Text _scoreTxt;
    [SerializeField]TMP_Text _decompte;
    [SerializeField] GameObject _deadScreen;
    [SerializeField]float _countdown;
    [SerializeField] bool _isStarted = false;
    [SerializeField] bool _inGame = false;
    public int _playerHp = 3;

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
        StartCoroutine(TimePoint());
    }

    public void AddPoint(int amount)
    {
        _playerScore += amount;
        _scoreTxt.text = _playerScore.ToString();
    }

    private void SetPoints(int amount)
    {
        _playerScore = amount;
        _scoreTxt.text = _playerScore.ToString();
    }

    private void StartGame()
    {
        SetPoints(0);
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
    public void InGame()
    {
        _inGame = true;
    }

    public void SetGmTxt(TMP_Text scoreTxt, TMP_Text countdownTxt)
    {
        _scoreTxt = scoreTxt;
        _decompte = countdownTxt;
    }

    public void SetSpawnManager(SpawnerManager sp)
    {
        _spawnerManager = sp;
    }

    public void SetDeadScreen(GameObject ds)
    {
        _deadScreen = ds;
    }

    public void StopGame()
    {
        _deadScreen.SetActive(true);
        _spawnerManager.Stop();
        StopAllCoroutines();
        _playerHp = 3;
        _countdown = 4;
        _isStarted = false;
        _inGame = false; 
    }
}
