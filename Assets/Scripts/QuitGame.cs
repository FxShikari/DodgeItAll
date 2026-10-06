using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitGame : MonoBehaviour
{
    [SerializeField] private int _holdTime = 5;
    Coroutine _countdown;

    public void Quit()
    {
        Application.Quit();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _countdown = StartCoroutine(StartAfterCountdown());
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && _countdown != null)
        {
            StopCoroutine(_countdown);
            _countdown = null;
        }
    }

    IEnumerator StartAfterCountdown()
    {
        yield return new WaitForSeconds(_holdTime);
        Debug.Log("QuitGame");
    }
}
