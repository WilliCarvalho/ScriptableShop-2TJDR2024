using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemDisplay : MonoBehaviour
{
    [SerializeField] private Image itemImage;
    [SerializeField] private TextMeshProUGUI itemPrice;
    [SerializeField] private TextMeshProUGUI itemName;
    private Button buyButton;
    private Item storedItem;

    private void Awake()
    {
        buyButton = GetComponent<Button>();
        buyButton.onClick.AddListener(SellItem);
    }

    public void PopulateDisplay(Item storedItem)
    {
        itemImage.sprite = storedItem.itemImage;
        itemPrice.text = storedItem.itemPrice.ToString();
        itemName.text = storedItem.itemName;
        storedItem.itemState = ItemState.ToBuy;
        this.storedItem = storedItem;
    }

    public void SellItem()
    {
        Destroy(this.gameObject);
    }
}
