using TMPro;
using UnityEditor;
using UnityEngine;

public class DeadScreen : MonoBehaviour
{
    [SerializeField] GameObject _deadScreen;
    [SerializeField] TMP_Text _scoreTxt;
    [SerializeField] TMP_Text _countdownTxt;
    [SerializeField] float _screenDuration;
    [SerializeField] string _sceneToCharge;

    private void OnEnable()
    {
        _screenDuration = 10;
        _scoreTxt.text = ("Your score: ") + GameManager.Instance._playerScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (_screenDuration > 0)
        {
            _screenDuration -= Time.deltaTime;
            _countdownTxt.text = ((int)_screenDuration).ToString();
        }
        if ((int)_screenDuration == 0)
        {
            StartCoroutine(SceneLoader.Instance.ChangeScene(_sceneToCharge));
        }
    }
}
