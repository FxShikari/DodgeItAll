using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class StartGame : MonoBehaviour
{

    [SerializeField] private float _holdTime = 3;

    [SerializeField] private TextMeshProUGUI _countdownText;

    Coroutine _countdown;

    void Start()
    {
        
    }

    public void NextScene()
    {
        SceneManager.LoadScene("");
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _countdown = StartCoroutine(Countdown());
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && _countdown != null)
        {
            StopCoroutine(_countdown);
            _countdown = null;
            _countdownText.text = "";
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
    }

    private void FixedUpdate()
    {
        _countdownText.SetText(_holdTime.ToString());
    }

}
