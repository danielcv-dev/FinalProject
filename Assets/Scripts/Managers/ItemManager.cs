using UnityEngine;

/// <summary>
/// Script manage the purchase between the store and the player
/// </summary>
public class ItemManager : MonoBehaviour
{
    [Header("prefabs")]
    [Tooltip("Drag the button prefab")]
    [SerializeField]
    GameObject itemPrefab;
    [SerializeField]
    MikesProperties player;
    [SerializeField]
    CanvasUI canvasUI;

    /// <summary>
    /// get the reference of the player and the canvas UI to show message
    /// </summary>
    private void Start()
    {
        player = FindObjectOfType<MikesProperties>();
        canvasUI = FindObjectOfType<CanvasUI>();
    }

    /// <summary>
    /// do the subtraction between the coins that had the player and the price of the item. 
    /// whether the result is less zero show a message, otherwise create a item and 
    /// complete the purchase
    /// </summary>
    /// <param name="_price">price of the item</param>
    /// <param name="_itemImage">item image</param>

    public void CommitItemPurchase(int _price, Sprite _itemImage)
    {
        int commitPrice = player.GetCoins() - _price;
        if (commitPrice < 0)
        {
            canvasUI.ShowMessage("Not enough money!!");
        }
        else
        {
            CreateGameObjectItem(_itemImage);
            player.SetCoins(commitPrice);
        }
    }

    /// <summary>
    /// Create a new object and add the item in the player inventory
    /// </summary>
    /// <param name="_itemImage"></param>
    public void CreateGameObjectItem(Sprite _itemImage)
    {
        ItemClass item = new ItemClass(_itemImage);
        player.AddItem(item);
    }



}
