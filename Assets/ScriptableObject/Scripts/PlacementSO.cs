using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="PlacementSO",menuName ="Placement",order = 2)]
public class PlacementSO : ScriptableObject
{
    [SerializeField]
    private int placementId;
    public int PlacementId { get { return placementId; } set { placementId = value; } }

    public GameObject prefab;
}
