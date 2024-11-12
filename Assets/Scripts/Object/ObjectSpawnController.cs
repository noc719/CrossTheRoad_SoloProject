using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawnController : MonoBehaviour
{
    public bool goLeft = false; //생성될 위치를 정해주는 불
    public bool goRight = false;

    public List<GameObject> items; //아이템이 있을시 아이템을 소환
    public List<SpawnPoint> pointLeft = new List<SpawnPoint>(); //왼쪽 스폰점
    public List<SpawnPoint> pointRight = new List<SpawnPoint>(); //오른쪽 스폰점


    //최적화를 위한 오브젝트 풀
    //소환한 대상이 해당 위치에서 이동하도록 이동로직 설정
}
