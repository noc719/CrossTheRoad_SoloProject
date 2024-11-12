using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawnController : MonoBehaviour
{
    public bool goLeft = false; //생성될 위치를 정해주는 불
    public bool goRight = false;

    public List<GameObject> items; //장애물이나 아이템을 담아두는 리스트
    public List<SpawnPoint> pointLeft = new List<SpawnPoint>(); //왼쪽 스폰점
    public List<SpawnPoint> pointRight = new List<SpawnPoint>(); //오른쪽 스폰점

    private void Start()
    {
        int itemID1 = Random.Range(0, items.Count);
        int itemID2 = Random.Range(0, items.Count);
    }


}
