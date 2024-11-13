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
        //disableObjects = new List<GameObject>(); //new�� ���� ����� ���� �������ϸ� ����ų �� ���� ���� ������ �����Ͽ�����

        foreach(Placement placement in placements)
        {
            int random = Random.Range(0,placement.maxAmount);
            for(int i =0; i<random; i++)
            {
                Vector3 spawnPoint = SetSpawnPoint();
                if (!Physics.Raycast(spawnPoint + Vector3.up * 0.1f, Vector3.up, out RaycastHit hit)) //�ش���ġ�� �ٸ� ������Ʈ�� �ִ���
                {
                    GameObject obj = PlacementManager.Instance.SpawnFromPool(placement.placementSO.PlacementId);  
                    obj.transform.position = spawnPoint;
                    //disableObjects.Add(obj);
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

    //private void OnDisable()
    //{
    //    for(int i = 0; i < disableObjects.Count; i++)
    //    {
    //        if(disableObjects[i].TryGetComponent<PlacementSO>(out PlacementSO placement)) //����� ������Ʈ���� ������ �˻�
    //        {
    //            PlacementManager.Instance.ReturnPlacement(placement.PlacementId, disableObjects[i]);
    //            Debug.Log("������ü Ǯ ��ȯ");
    //        }
    //        else
    //        {
    //            Destroy(disableObjects[i]); //���� Ű�� ���� �� �ı�
    //        }
    //    }
    //}
}
