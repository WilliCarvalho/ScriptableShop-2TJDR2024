using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public InputManager InputManager { get; private set; }

    [SerializeField] private GameObject shopUI;
    [SerializeField] private GameObject inventoryUI;
    [SerializeField] private PlayerInventory playerInventory;
    [SerializeField] private ShopManager shopManager;

    private void Awake()
    {
        Instance = this;
        InputManager = new InputManager();

        shopUI.SetActive(false);
        inventoryUI.SetActive(false);
    }

    public void OpenCloseInventory()
    {
        inventoryUI.SetActive(!inventoryUI.activeSelf);
    }

    public void CheckAndHandleShopUIEnabled()
    {
        if (shopUI.activeSelf == true)
        {
            CloseShopUI();
        }
        else
        {
            OpenShopUI();
        }
    }

    public void OpenShopUI()
    {
        shopUI.SetActive(true);
    }

    public void CloseShopUI()
    {
        shopUI.SetActive(false);
    }

    public void TransferItemToInventory(Item item)
    {
        playerInventory.UpdateInventory(item);
    }

}
