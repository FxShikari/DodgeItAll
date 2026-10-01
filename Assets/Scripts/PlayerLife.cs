using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    private int _lifePoint = 1;

    public void LoseLifePoints(int amount)
    {
        _lifePoint -= amount;
    }

    public void AddLifePoints(int amount)
    {
        _lifePoint += amount;
    }
}
