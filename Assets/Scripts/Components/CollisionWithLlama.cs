using UnityEngine;

/// <summary>
/// When the player sollides with a llama execute the OnCollisionEnter
/// </summary>
public class CollisionWithLlama : MonoBehaviour
{
    [Header("Prefabs")]
    [Tooltip("Drag the prefab of the FX")]
    [SerializeField]
    GameObject fXPrefab;
    LlamaPenManager llamaManager;
    PoolingSystem poolingSystem;
    /// <summary>
    /// get the reference to the llamaManager
    /// </summary>
    private void Start()
    {
        llamaManager = FindObjectOfType<LlamaPenManager>();
        poolingSystem = FindObjectOfType<PoolingSystem>();
    }

    /// <summary>
    /// verify whether the player collides with a llama. 
    /// next, check if the pen have less of 15 llamas inside
    /// after that add the llama to the list of llama manager, start the timer of the llama
    /// begin to substract health, remove the llama from the pooling system
    /// finaly instantiate a particle effect and cerate other llama
    /// 
    /// </summary>
    /// <param name="collision">The collider of the llama</param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Llama"))
        {
            if (llamaManager.GetSizeLlamasList() <= 15) 
            {
                Instantiate(fXPrefab, collision.transform.position, Quaternion.identity);
                llamaManager.AddLlama(collision.gameObject);
                StartCoroutine(collision.collider.gameObject.GetComponent<TimerToRemove>().LlamaTimer());
                poolingSystem.LlamaRemoveFromPooling(collision.gameObject, collision.transform.position);
                StartCoroutine(poolingSystem.TimeToSpawn());
            }
        }
    }
}
