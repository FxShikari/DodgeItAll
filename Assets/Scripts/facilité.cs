using TMPro;
using UnityEngine;

public class facilité : MonoBehaviour
{

    public int _lifeAmount;
    [SerializeField] private TextMeshProUGUI _modeName;
    [SerializeField] private string _modeDescription;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.PlayerHpAmount(_lifeAmount);
            Debug.Log("HP Change");
            _modeName.text = _modeDescription;
            
        }
    }
}
