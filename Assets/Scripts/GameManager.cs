using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public InputManager InputManager { get; private set; }

    [SerializeField] private GameObject ShopUI;

    private void Awake()
    {
        Instance = this;
        InputManager = new InputManager();

        ShopUI.SetActive(false);
    }

    public void CheckAndHandleShopUIEnabled()
    {
        if (ShopUI.activeSelf == true)
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
        ShopUI.SetActive(true);
    }

    public void CloseShopUI()
    {
        ShopUI.SetActive(false);
    }

}
