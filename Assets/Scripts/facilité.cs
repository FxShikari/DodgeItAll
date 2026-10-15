using TMPro;
using UnityEngine;

public class facilité : MonoBehaviour
{

    public int _lifeAmount;
    [SerializeField] private TextMeshProUGUI _modeName;
    [SerializeField] private string _modeDescription;
    [SerializeField] Animator _animator;
    [SerializeField] AudioClip _buttonClic;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _animator.SetTrigger("Push");
            if (_buttonClic != null)SoundManager.Instance.PlayClip(_buttonClic, transform.position, 1);
            GameManager.Instance.PlayerHpAmount(_lifeAmount);
            _modeName.text = _modeDescription;
            
        }
    }
}
