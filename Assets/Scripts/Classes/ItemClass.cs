using System;
using UnityEngine;


/// <summary>
/// Class of item to save the item properties and it's serializable to see the information in the inspector.
/// </summary>
[Serializable]
public class ItemClass
{
    [SerializeField]
    Sprite imageItem;
    public ItemClass(Sprite _imgeItem)
    {
        imageItem = _imgeItem;
    }

    public Sprite GetItemImage()
    {
        return imageItem;
    }
}
