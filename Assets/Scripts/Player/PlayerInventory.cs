using System;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private PlayerItemDisplay playerinventoryItemPrefab;
    [SerializeField] private Transform inventoryContainer;

    private void Awake()
    {
        PopulateInventory();
    }

    private void Start()
    {
        GameManager.Instance.HandleItemSelled += UpdateInventory;
    }

    private void PopulateInventory()
    {
        foreach (Item item in inventory.items)
        {           
            InstantiatePlayerItem(item);
        }
    }

    public void UpdateInventory(Item newItem)
    {
        inventory.items.Add(newItem);
        InstantiatePlayerItem(newItem);
    }

    private void InstantiatePlayerItem(Item item)
    {
        PlayerItemDisplay playerItem = Instantiate(playerinventoryItemPrefab, inventoryContainer);
        playerItem.PopulateDisplay(item);
    }
}