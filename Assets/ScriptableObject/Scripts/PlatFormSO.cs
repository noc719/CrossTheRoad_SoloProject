using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="FlatFormSO",menuName ="FlatForm",order =20)]
public class PlatFormSO : ScriptableObject
{
    public int platformId;

    public GameObject prefab;

    public Vector3 width;
}
