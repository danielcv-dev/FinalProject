using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script to create instance and take the control of the instance in the environment
/// Require the cerate llama and cerate coins scripts
/// </summary>
[RequireComponent(typeof(CreateLlama))]
[RequireComponent(typeof(CreateCoins))]
public class PoolingSystem : MonoBehaviour
{
    [SerializeField]
    List<GameObject> llamas;
    [SerializeField]
    List<GameObject> coins;
    [SerializeField]
    Transform llamasPen;
    CreateLlama createLlama;
    CreateCoins createCoins;

    /// <summary>
    /// get the reference of the cerate llama and create coins. 
    /// Create all the llamas in the environment
    /// </summary>
    // Start is called before the first frame update
    void Start()
    {
        createLlama = GetComponent<CreateLlama>();
        createCoins = GetComponent<CreateCoins>();
        for (int i = 0; i < 10; i++)
        {
            StartCoroutine(TimeToSpawn());
        }
    }

    /// <summary>
    /// Wait time between 3 - 7 to spawn a new llama
    /// </summary>
    /// <returns></returns>
    public IEnumerator TimeToSpawn()
    {
        yield return new WaitForSeconds(Random.Range(3,7));
        SpawnLlama();
    }

    /// <summary>
    /// Add a llama in the list of llamas
    /// </summary>
    public void SpawnLlama()
    {
            llamas.Add(createLlama.InstatiateLlama());
    }

    /// <summary>
    /// When remove from the list of llamas, first remove from the list. after, spawn the random coins. 
    /// next, deactive the llama, move the llama to the Pen and set as a parent the Pen. 
    /// Finaly disable the llama movement and active again the llama
    /// </summary>
    /// <param name="_llama">Game object llama </param>
    /// <param name="_transformCollision">the vector 3 of the collision</param>
    public void LlamaRemoveFromPooling(GameObject _llama, Vector3 _transformCollision)
    {
        RemoveObjectFromList(_llama);
        SpawnCoins(_llama.GetComponent<LlamaProperties>().GetCoins(), _transformCollision);
        _llama.SetActive(false);
        _llama.transform.position = llamasPen.position;
        _llama.transform.SetParent(llamasPen);
        _llama.GetComponent<LlamaMovement>().enabled = false;
        _llama.SetActive(true);
    }

    /// <summary>
    /// Spawn the number of coins in the vector 3 collision and add in the list of coins
    /// </summary>
    /// <param name="_llamaCoins"></param>
    /// <param name="_transformCollision"></param>
    public void SpawnCoins(int _llamaCoins, Vector3 _transformCollision)
    {
        for (int i = 0; i < _llamaCoins; i++)
        {
            coins.Add(createCoins.InstatiateCoins(_transformCollision));
        }
    }

    /// <summary>
    /// when we remove from the list remove form the list according to the 
    /// game object tag. if is llama only remove from the list, if is coin
    /// remove from the list coins
    /// </summary>
    /// <param name="_obj"></param>
    public void RemoveObjectFromList(GameObject _obj)
    {
        switch (_obj.tag)
        {
            case "Llama":
                llamas.Remove(_obj);
                break;
            case "Coin":
                coins.Remove(_obj);
                DestroyObjects(_obj);
                break;
        }
    }

    /// <summary>
    /// Destroy the objects in the pooling system
    /// </summary>
    /// <param name="_obj">game object to destroy</param>
    public void DestroyObjects(GameObject _obj)
    {
        Destroy(_obj);
    }

}
