using TMPro;
using UnityEngine;

public class facilité : MonoBehaviour
{

    public int _lifeAmount;
    [SerializeField] private TextMeshProUGUI _modeName;
    [SerializeField] private string _modeDescription;
    [SerializeField] Animator _animator;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _animator.SetTrigger("Push");
            GameManager.Instance.PlayerHpAmount(_lifeAmount);
            _modeName.text = _modeDescription;
            
        }
    }
}
