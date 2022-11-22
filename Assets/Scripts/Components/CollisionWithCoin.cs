using UnityEngine;

/// <summary>
/// When the player collides with a Coin execute the OnCollisionEnter
/// </summary>
public class CollisionWithCoin : MonoBehaviour
{
    [Header("FX")]
    [Tooltip("Drag the audio clip that will sound when the player take a coin")]
    [SerializeField]
    AudioClip audioCoin;
    AudioSource audioSource;
    MikesProperties playerProperties;
    PoolingSystem poolingSystem;

    /// <summary>
    /// Get the player properties and the pooligon system references
    /// </summary>
    private void Start()
    {
        playerProperties = GetComponent<MikesProperties>();
        poolingSystem = FindObjectOfType<PoolingSystem>();
        audioSource = GameObject.Find("SoundFX").GetComponent<AudioSource>();
    }

    /// <summary>
    /// veify if the player collides with a coin. next remove the coin from pooligon system 
    /// and add one to the player coins
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Coin"))
        {
            audioSource.PlayOneShot(audioCoin);
            poolingSystem.RemoveObjectFromList(collision.gameObject);
            playerProperties.SetCoins(playerProperties.GetCoins() + 1);
        }
    }
}
