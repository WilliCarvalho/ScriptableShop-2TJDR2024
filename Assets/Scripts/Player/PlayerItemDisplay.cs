using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerItemDisplay : MonoBehaviour
{
    [SerializeField] private Image itemImage;
    [SerializeField] private TextMeshProUGUI itemName;
    private Button equipButton;
    private Item storedItem;

    private void Awake()
    {
        equipButton = GetComponent<Button>();
    }

    public void PopulateDisplay(Item storedItem)
    {
        itemImage.sprite = storedItem.itemImage;
        itemName.text = storedItem.itemName;
        storedItem.itemState = ItemState.ToEquip;
        this.storedItem = storedItem;
    }
}