using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public static SceneLoader Instance { get; private set; }

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

    public IEnumerator ChangeScene(string sceneName)
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneName);
    }
}
