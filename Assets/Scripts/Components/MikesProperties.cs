using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// inherate from the general properties and add the extra attributes (Item list, canvasUI)
/// </summary>
public class MikesProperties : GeneralPropertiesClass
{
    [Header("Player Properties")]
    [SerializeField]
    List<ItemClass> items;
    [SerializeField]
    CanvasUI canvasUI;

    /// <summary>
    /// Get the reference to the canvas UI and initialize the values to show
    /// </summary>
    private void Start()
    {
        canvasUI = FindObjectOfType<CanvasUI>();
        canvasUI.UpdateCoinsValue(GetCoins());
        canvasUI.HealthBar(GetHealth());
    }

    #region Get and Set
    /// <summary>
    /// override the base set coin and update the cuantitie of the coins 
    /// to show in the canvas UI
    /// </summary>
    /// <param name="_coins"></param>
    public override void SetCoins(int _coins)
    {
        base.SetCoins(_coins);
        canvasUI.UpdateCoinsValue(GetCoins());
    }

    public override void SetHealth(int _health)
    {
        base.SetHealth(_health);
        canvasUI.HealthBar(GetHealth());
    }

    public void AddItem(ItemClass _item)
    {
        items.Add(_item);
    }

    public List<ItemClass> GetList()
    {
        return items;
    }
    #endregion
}
