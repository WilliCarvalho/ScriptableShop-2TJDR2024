using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private Inventory shopInventory;
    [SerializeField] private ShopItemDisplay displayPrefab;
    [SerializeField] private Transform shopContainer;

    private void Awake()
    {
        LoadInventoryItems();
    }

    private void LoadInventoryItems()
    {
        foreach(Item item in shopInventory.items)
        {
            ShopItemDisplay shopItem = Instantiate(displayPrefab, shopContainer);
            shopItem.PopulateDisplay(item);
            //shopItem.OnSellItem += HandleItemSelled;
        }
    }

    private void HandleItemSelled(Item item)
    {
        if (item.itemState != ItemState.ToBuy) return;
        shopInventory.items.Remove(item);
    }
}
