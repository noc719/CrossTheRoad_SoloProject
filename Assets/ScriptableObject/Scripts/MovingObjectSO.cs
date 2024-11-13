using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MovingObjectSO", menuName = "MovingObjects", order = 0)]
public class MovingObjectSO : ScriptableObject
{
    [Header("ItemInfo")]

    [SerializeField]
    private int moveObjectId;
    public int MoveObjectId { get { return moveObjectId; } set { moveObjectId = value; } }

    public GameObject prefab;

    [Header("Movement")]

    [SerializeField]
    private float speed;
    public float Speed { get { return speed; } set { speed = value; } }
}
