using UnityEngine;

[CreateAssetMenu (fileName = "EquippedItem", menuName = "ScriptableAssets/New Item")]
public class Item : ScriptableObject
{
    public GameObject itemPrefab;
    public Sprite itemImage;
    public int itemPrice;
    public string itemName;
    public ItemType itemType;
    public ItemState itemState;
}
