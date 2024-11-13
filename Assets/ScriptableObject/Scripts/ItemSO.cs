using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemSO", menuName = "Item", order = 0)]
public class ItemSO : ScriptableObject
{
    [Header("ItemInfo")]

    [SerializeField]
    private int itemId;
    public int ItemId { get { return itemId; } set { itemId = value; } }

    public GameObject prefab;

    [Header("Movement")]

    [SerializeField]
    private float speed;
    public float Speed { get { return speed; } set { speed = value; } }
}
