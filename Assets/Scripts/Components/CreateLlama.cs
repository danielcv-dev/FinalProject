using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Create the llama with all the properties
/// </summary>
public class CreateLlama : MonoBehaviour
{
    [Header("Prefabs")]
    [Tooltip("Drag the llama Prefab")]
    [SerializeField]
    GameObject llamaPrefab;
    [Header("Materials")]
    [Tooltip("Drag all the materials to change llama skin")]
    [SerializeField]
    List<Material> llamaMaterials;

    /// <summary>
    /// Create the llama with a random vector 3 and return the llama instantiated.
    /// </summary>
    /// <returns>llama game object</returns>
    public GameObject InstatiateLlama()
    {
        RandomVector3 randomVector3 = new RandomVector3();

        GameObject llama = Instantiate(llamaPrefab, randomVector3.GiveMeARandomVector3(-70, 70, -80, 80), llamaPrefab.transform.rotation);
        SetAllLlamaProperties(llama);
        return llama;
    }


    #region Llama creation
    /// <summary>
    /// Set all the llama properties randomized. (health, age, coins to spawn, diet Type and size) and change the skin
    /// </summary>
    /// <param name="_llama">llama instantiated</param>
    void SetAllLlamaProperties(GameObject _llama)
    {
        LlamaProperties llamaProperties = _llama.GetComponent<LlamaProperties>();
        llamaProperties.SetHealth(Random.Range(1, 20));
        llamaProperties.SetAge(Random.Range(1, 5));
        llamaProperties.SetCoins(Random.Range(1, 5));
        llamaProperties.SetDietType(Random.Range(0, 2));
        _llama.GetComponentInChildren<SkinnedMeshRenderer>().material = llamaMaterials[Random.Range(0, llamaMaterials.Count)];
        SetSizeLlama(llamaProperties.GetAge(), _llama.transform);
    }

    /// <summary>
    /// with a simple rule of three i get the size proportional to the age value
    /// and modify the llama scale 
    /// </summary>
    /// <param name="ageLlama">llama age property</param>
    /// <param name="llama">llama transform</param>
    void SetSizeLlama(int ageLlama, Transform _llama)
    {
        float sizeLlama = (ageLlama * 0.4f) / 1;

        _llama.localScale = new Vector3(sizeLlama, sizeLlama, sizeLlama);
    }

    #endregion
}
