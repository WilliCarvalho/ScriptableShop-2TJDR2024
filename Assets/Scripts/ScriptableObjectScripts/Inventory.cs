using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "Inventory", menuName = "ScriptableAssets/New Inventory")]
public class Inventory : ScriptableObject
{
    [SerializeField] public List<Item> items;
}
