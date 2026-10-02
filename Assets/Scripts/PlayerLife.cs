using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private int _lifePoint = 1;

    public void SetHp(int amount)
    {
        _lifePoint += amount;
    }
}
