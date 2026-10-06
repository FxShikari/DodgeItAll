using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{

    [SerializeField] LayerMask _playerLayer;


    public void NextScene()
    {
        SceneManager.LoadScene("");
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if ((_playerLayer & (1 << collision.transform.gameObject.layer)) > 0)
        {
            Debug.Log("StartGame");
        }
    }

}
