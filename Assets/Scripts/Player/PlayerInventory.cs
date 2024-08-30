using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private Button sellButton;
    [SerializeField] private Transform inventoryContainer;
    [SerializeField] private InventoryItemDisplay inventoryItemPrefab;
    private InventoryItemDisplay selectedDisplay;

    private void Awake()
    {
        DisplayInventoryItems();
    }

    private void DisplayInventoryItems()
    {
        foreach (Item item in inventory.items)
        {
            InstantiateAndPopulateDisplay(item);
        }
    }

    private void InstantiateAndPopulateDisplay(Item item)
    {
        print("Showing item: " + item.name);
        InventoryItemDisplay itemToDisplay = Instantiate(inventoryItemPrefab, inventoryContainer);
        inventoryItemPrefab.PopulateDisplay(item);
        inventoryItemPrefab.OnItemSelected += StoreSelectedItem;
    }

    public void UpdateInventory(Item item)
    {
        inventory.items.Add(item);
        InstantiateAndPopulateDisplay(item);
    }

    private void StoreSelectedItem(InventoryItemDisplay selectedItem)
    {
        selectedDisplay = selectedItem;
    }
}
