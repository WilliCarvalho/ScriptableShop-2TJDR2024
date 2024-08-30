using System;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public InputManager InputManager { get; private set; }
    
    public event Action<Item> HandleItemSelled;

    private void Awake()
    {
        Instance = this;
        InputManager = new InputManager();
    }

    public void InvokeHandleItemSelled(Item item) => HandleItemSelled?.Invoke(item);
}
