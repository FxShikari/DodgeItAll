using System;
using TMPro;
using UnityEngine;

public class LaunchGame : MonoBehaviour
{
    [SerializeField] TMP_Text _scoreTxt;
    [SerializeField] TMP_Text _countdownTxt;
    [SerializeField] SpawnerManager _spawnerManager;
    [SerializeField] GameObject _deadScreen;
    [SerializeField] GameObject _deadPlayer;
    [SerializeField] GameObject _restartZone;
    private void Awake()
    {
        GameManager.Instance.SetGmTxt(_scoreTxt, _countdownTxt);
        GameManager.Instance.SetSpawnManager(_spawnerManager);
        GameManager.Instance.SetDeadScreen(_deadScreen);
        GameManager.Instance.setDeadPlayer(_deadPlayer);
        GameManager.Instance.setRestartZone(_restartZone);

    }
    private void Start()
    {
        GameManager.Instance.InGame();
        Destroy(gameObject);
    }
}
