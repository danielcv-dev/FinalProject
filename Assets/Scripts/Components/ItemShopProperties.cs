using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Here define the properties of the item to purchase (Price, image, etc.)
/// </summary>
public class ItemShopProperties : MonoBehaviour
{
    [Header("Sprite")]
    [Tooltip("Drag the sprite of the item")]
    [SerializeField]
    Sprite itemImage;
    [Header("Poperties")]
    [Tooltip("Price of the item")]
    [SerializeField]
    int price;


    /// <summary>
    /// Add the information of the attributes to the corrsponding components
    /// and add a onclick event to commit the purchase
    /// </summary>
    private void Start()
    {
        transform.GetChild(0).GetComponent<Image>().sprite = itemImage;
        GetComponentInChildren<TextMeshProUGUI>().text = price.ToString();
        GetComponentInChildren<Button>().onClick.AddListener(() => { OnClickToCommitPurchase(); });
    }

    /// <summary>
    /// Get the component itemManager to commit the purchase, send the prices and the attibutes
    /// </summary>
    public void OnClickToCommitPurchase()
    {
        GetComponentInParent<ItemManager>().CommitItemPurchase(price, itemImage);
    }

    #region get and set
    public Sprite GetImageItem()
    {
        return itemImage;
    }

    public void SetItemImage(Sprite _itemImage)
    {
        itemImage = _itemImage;
    }

    public int GetPrice()
    {
        return price;
    }

    public void SetPrice(int _price)
    {
        price = _price;
    }
    #endregion


}