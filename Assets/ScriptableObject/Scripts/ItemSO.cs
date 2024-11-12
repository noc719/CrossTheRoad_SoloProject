using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemSO", menuName = "ItemData", order = 0)]
public class ItemSO : ScriptableObject
{
    [Header("ItemInfo")]
    private string itemName;
    public string ItemName { get { return name; } set { name = value; } }

    public GameObject prefabs;
}
