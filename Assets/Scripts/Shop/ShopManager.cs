using System;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private Inventory shopInventory;
    [SerializeField] private ShopItemDisplay shopItemPrefab;
    [SerializeField] private Button buyItemButtom;
    private ShopItemDisplay selectedDisplay;
    private Item selectedItem;

    private void Awake()
    {
        DisplayInventoryItems();
        buyItemButtom.onClick.AddListener(BuySelectedItem);
    }

    private void BuySelectedItem()
    {
        GameManager.Instance.TransferItemToInventory(selectedItem);
        shopInventory.items.Remove(selectedItem);
        Destroy(selectedDisplay.gameObject);
    }

    private void DisplayInventoryItems()
    {
        foreach (Item item in shopInventory.items)
        {
            ShopItemDisplay itemToDisplay = Instantiate(shopItemPrefab, this.transform);
            itemToDisplay.PopulateDisplay(item);
            itemToDisplay.OnItemSelected += StoreSelectedItem;
        }
    }

    private void StoreSelectedItem(ShopItemDisplay selectedDisplay)
    {
        print("Storing item");
        selectedItem = selectedDisplay.GetItem();
        this.selectedDisplay = selectedDisplay;
    }
}
