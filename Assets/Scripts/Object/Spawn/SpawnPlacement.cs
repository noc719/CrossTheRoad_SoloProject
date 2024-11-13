using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlacement : MonoBehaviour
{
    public float startPos = 25;
    public float endPos = -25;

    private Transform middlePoint;

    public List<Placement> placements;


    private void Start()
    {
        middlePoint = this.gameObject.transform;
        SpawnPlacementObject();
    }

    private void SpawnPlacementObject()
    {
        foreach(Placement placement in placements)
        {
            for(int i =0; i<placement.maxAmount; i++)
            {
                Vector3 spawnPoint = SetSpawnPoint();
                if (!Physics.Raycast(spawnPoint + Vector3.up * 0.1f, Vector3.up, out RaycastHit hit)) //�ش���ġ�� �ٸ� ������Ʈ�� �ִ���
                {
                    GameObject obj = PlacementManager.Instance.SpawnFromPool(placement.placementSO.PlacementId);  
                    obj.transform.position = spawnPoint;
                }
                else
                {
                    i--;
                    continue; //�ٽ� �ݺ�
                }
            }
        }
    }

    private Vector3 SetSpawnPoint()
    {
        return new Vector3(Random.Range(startPos, endPos), middlePoint.position.y, middlePoint.position.z);
    }
}
