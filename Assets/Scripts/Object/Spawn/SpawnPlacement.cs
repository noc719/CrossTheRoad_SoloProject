using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlacement : MonoBehaviour
{
    public float startPos = 25;
    public float endPos = -25;

    private Transform middlePoint;

    public List<Placement> placements;

    //private List<GameObject> disableObjects; 


    private void Start()
    {
        middlePoint = this.gameObject.transform;
        SpawnPlacementObject();
    }

    private void SpawnPlacementObject()
    {
        //disableObjects = new List<GameObject>(); //new를 많이 만드는 것은 성능저하를 일으킬 수 있음 개선 방향을 생각하여본다

        foreach(Placement placement in placements)
        {
            int random = Random.Range(0,placement.maxAmount);
            for(int i =0; i<random; i++)
            {
                Vector3 spawnPoint = SetSpawnPoint();
                if (!Physics.Raycast(spawnPoint + Vector3.up * 0.1f, Vector3.up, out RaycastHit hit)) //해당위치에 다른 오브젝트가 있는지
                {
                    GameObject obj = PlacementManager.Instance.SpawnFromPool(placement.placementSO.PlacementId);  
                    obj.transform.position = spawnPoint;
                    //disableObjects.Add(obj);
                }
                else
                {
                    i--;
                    continue; //다시 반복
                }
            }
        }
    }

    private Vector3 SetSpawnPoint()
    {
        return new Vector3(Random.Range(startPos, endPos), middlePoint.position.y, middlePoint.position.z);
    }

    //private void OnDisable()
    //{
    //    for(int i = 0; i < disableObjects.Count; i++)
    //    {
    //        if(disableObjects[i].TryGetComponent<PlacementSO>(out PlacementSO placement)) //사라질 오브젝트들의 내역을 검사
    //        {
    //            PlacementManager.Instance.ReturnPlacement(placement.PlacementId, disableObjects[i]);
    //            Debug.Log("고정물체 풀 반환");
    //        }
    //        else
    //        {
    //            Destroy(disableObjects[i]); //만일 키가 없을 땐 파괴
    //        }
    //    }
    //}
}
