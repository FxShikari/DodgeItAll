using TMPro;
using UnityEngine;

public class LaunchGame : MonoBehaviour
{
    [SerializeField] TMP_Text _scoreTxt;
    [SerializeField] TMP_Text _countdownTxt;
    [SerializeField] SpawnerManager _spawnerManager;

    private void Awake()
    {
        GameManager.Instance.SetGmTxt(_scoreTxt, _countdownTxt);
        GameManager.Instance.SetSpawnManager(_spawnerManager);
    }
    private void Start()
    {
        
        GameManager.Instance.InGame();
        Destroy(gameObject);
    }
}
