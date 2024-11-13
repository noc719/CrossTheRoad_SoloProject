using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="FlatFormSO",menuName ="FlatForm",order =1)]
public class PlatFormSO : ScriptableObject
{
    [SerializeField]
    private int placementId;
    public int PlacementId { get { return placementId; } set { placementId = value; } }   

    public GameObject prefab;

}
