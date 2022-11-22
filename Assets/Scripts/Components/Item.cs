using System;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// Conteiner of all item properties for create buttons dynamically
/// </summary>
[Serializable]
public class Item : MonoBehaviour
{
    [SerializeField]
    Sprite itemImage;
    
    /// <summary>
    /// Set the image of the item property
    /// </summary>
    /// <param name="_itemImage">image from item property</param>
    public void SetItemImage(Sprite _itemImage)
    {
        itemImage = _itemImage;
    }

    /// <summary>
    /// Initialize the item button 
    /// </summary>
    public void InitItem()
    {
        GetComponent<Image>().sprite = itemImage;
    }

}
