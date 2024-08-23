using System;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private Inventory shopInventory;
    [SerializeField] private ShopItemDisplay shopItemPrefab;

    private void Awake()
    {
        DisplayInventoryItems();
    }

    private void DisplayInventoryItems()
    {
        foreach(Item item in shopInventory.items)
        {
           ShopItemDisplay itemToDisplay = Instantiate(shopItemPrefab, this.transform);
            itemToDisplay.PopulateDisplay(item);
        }
    }
}
