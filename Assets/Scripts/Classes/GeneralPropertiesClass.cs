using UnityEngine;


/// <summary>
/// General class would be inherited by the player and llama
/// </summary>
public class GeneralPropertiesClass : MonoBehaviour
{
    [Header("General Properties")]
    [Tooltip("Heatlth")]
    [SerializeField]
    int health;
    [Tooltip("Coins quantity")]
    [SerializeField]
    int coins;

    #region Get and Set
    virtual public int GetHealth()
    {
        return health;
    }

    virtual public void SetHealth(int _health)
    {
        health = _health;
    }

    virtual public int GetCoins()
    {
        return coins;
    }

    virtual public void SetCoins(int _coins)
    {
        coins = _coins;
    }
    #endregion
}
