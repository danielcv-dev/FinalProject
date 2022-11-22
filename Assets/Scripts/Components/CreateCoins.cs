using UnityEngine;

/// <summary>
/// Create the coin and return the object instantiated
/// </summary>
public class CreateCoins : MonoBehaviour
{
    [Header("Prefabs")]
    [Tooltip("Add the coin Prefab")]
    [SerializeField]
    GameObject coinPrefab;
    //offset to instantiate the coin
    Vector3 offset = new Vector3(0, 3.0f, 0);

    /// <summary>
    /// instantiate the coin and return the coin created
    /// </summary>
    /// <param name="_spawnTransform">the vector of the collision</param>
    /// <returns>game object instantiated</returns>
    public GameObject InstatiateCoins(Vector3 _spawnTransform)
    {
        return Instantiate(coinPrefab, _spawnTransform + offset, Quaternion.identity);
    }
}
