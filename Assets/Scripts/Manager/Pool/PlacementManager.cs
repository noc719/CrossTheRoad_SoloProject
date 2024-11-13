
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlacementManager : Manager<PlacementManager>
{
    public List<Placement> Placements;

    public Dictionary<int, Queue<GameObject>> placementDict;

    private void Start()
    {
        SetPool();
    }

    private void SetPool()
    {
        placementDict = new Dictionary<int, Queue<GameObject>>();
        foreach (var placement in Placements)
        {
            Queue<GameObject> queue = new Queue<GameObject>();
            for(int i = 0; i<10 ; i++)
            {
                GameObject obj = Instantiate(placement.placementSO.prefab,this.transform);
                obj.SetActive(false);
                queue.Enqueue(obj);
            }
            placementDict.Add(placement.placementSO.PlacementId, queue);
        }
    }

    public GameObject SpawnFromPool(int key)
    {
        if(!placementDict.ContainsKey(key))return null;

        if (placementDict[key].Count > 0) //해당 키의 큐가 비어있지 않다면 
        {
            GameObject obj = placementDict[key].Dequeue();
            obj.SetActive(true);
            return obj;
        }
        else
        {
            Placement placement = Placements.Find(n => n.placementSO.PlacementId == key);
            GameObject obj = Instantiate(placement.placementSO.prefab,this.transform);
            obj.SetActive(false);
            return obj;
        }
    }

    public void ReturnPlacement(int key,  GameObject obj)
    {

    }
}
