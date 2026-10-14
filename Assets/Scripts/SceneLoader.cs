using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] Animator _transition;
    [SerializeField] private AudioClip _open;
    [SerializeField] private AudioClip _close;
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
        }
    }

    private void Start()
    {
        SoundManager.Instance.PlayClip(_open, Vector3.zero, 5);
    }

    public IEnumerator ChangeScene(string sceneName)
    {
        SoundManager.Instance.PlayClip(_close, Vector3.zero, 5);
        _transition.SetTrigger("Start");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(sceneName);
    }
}
