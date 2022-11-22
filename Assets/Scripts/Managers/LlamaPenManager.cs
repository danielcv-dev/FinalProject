using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// manage the llamas in Pen
/// </summary>
public class LlamaPenManager : MonoBehaviour
{
    [SerializeField]
    List<GameObject> llamas;

    #region Get and Set
    public void AddLlama(GameObject _llama)
    {
        llamas.Add(_llama);
    }

    public void RemoveLlama(GameObject _llama)
    {
        llamas.Remove(_llama);
    }

    public int GetSizeLlamasList()
    {
        return llamas.Count;
    }

    public List<GameObject> GetLlamaPropertiesList()
    {
        return llamas;
    }
    #endregion
}
