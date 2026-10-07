using UnityEngine;

public class facilité : MonoBehaviour
{

    public int _lifeAmount;

    GameManager _manager;




    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _manager.SetPlayerHP(_lifeAmount);
            Debug.Log("HP Change");
        }
    }
}
