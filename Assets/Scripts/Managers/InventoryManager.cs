using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script to show the items in the UI 
/// </summary>
public class InventoryManager : MonoBehaviour
{
    [SerializeField]
    List<GameObject> items;
    [SerializeField]
    MikesProperties player;
    [SerializeField]
    GameObject itemPrefab;
 
    /// <summary>
    /// Get the inventory in the player and create buttons to select in the UI inventory
    /// </summary>
    public void ShowInventory()
    {
        List<ItemClass> itemsClass = FindObjectOfType<MikesProperties>().GetList();

        foreach (ItemClass item in itemsClass)
        {
            items.Add(CreateItem(item));
        }
    }

    /// <summary>
    /// delete all the objects in the UI inventory and clear the list items
    /// </summary>
    public void ClearInventory()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        items.Clear();
    }

    /// <summary>
    /// Create a button with the item properties saved in the player properties
    /// and add this properties to te button and initialize it
    /// </summary>
    /// <param name="_item">propertie</param>
    /// <returns>the button created</returns>
    public GameObject CreateItem(ItemClass _item)
    {
        GameObject buttonItem = Instantiate(itemPrefab, transform);
        Item itemProperty = buttonItem.GetComponent<Item>();
        itemProperty.SetItemImage(_item.GetItemImage());
        itemProperty.InitItem();

        return buttonItem;
    }

}
