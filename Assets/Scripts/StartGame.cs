using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class StartGame : MonoBehaviour
{

    [SerializeField] private float _holdTime = 3;

    [SerializeField] private TextMeshProUGUI _countdownText;

    Coroutine _countdown;

    void Start()
    {
        _countdownText.enabled = false;
    }

    public void NextScene()
    {
        SceneManager.LoadScene("Clery");
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _countdown = StartCoroutine(Countdown());
            _countdownText.enabled = true;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && _countdown != null)
        {
            StopCoroutine(_countdown);
            _countdown = null;
            _countdownText.text = "";
            _countdownText.enabled = false;
        }
    }


    IEnumerator Countdown()
    {
        float remaining = _holdTime;
        while (remaining > 0)
        {
            _countdownText.text = Mathf.CeilToInt(remaining).ToString();
            remaining -= Time.deltaTime;
            yield return null;
        }
        _countdownText.text = "0";
        Debug.Log("StartGame");
        NextScene();
    }

}
