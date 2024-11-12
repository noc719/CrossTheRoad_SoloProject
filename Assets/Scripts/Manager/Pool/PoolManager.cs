using System.Collections.Generic;
using UnityEngine;
public class PoolManager : Manager<PoolManager>
{
    public List<ItemData> data;
    public Dictionary<int, Queue<GameObject>> Pool;

    private void Awake()
    {
        SetPool();
    }

    private void SetPool()
    {
        Pool = new Dictionary<int, Queue<GameObject>>();
        foreach (var pool in data)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for (int i = 0; i < 3; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
            Pool.Add(pool.id, objectPool);
        }
    }

    public GameObject SpawnObject(int id)
    {
        if (!Pool.ContainsKey(id)) return null; //해당 키가 없을 경우 null반환

        if (Pool[id].Count > 0) //큐의 오브젝트가 0이 아니라면
        {
            GameObject obj = Pool[id].Dequeue(); //해당 큐에서 오브젝트를 꺼냄
            obj.SetActive(true);
            return obj; //해당 오브젝트를 반환
        }
        else //큐가 비어있다면
        {
            ItemData poolData = data.Find(n => n.id == id); //리스트에서 이름이 동일한 데이터를 받아옴

            GameObject newObj = Instantiate(poolData.prefab); // 새로 오브젝트를 생성
            newObj.SetActive(false); //오브젝트를 비활성화
            Pool[id].Enqueue(newObj); // 큐에 새로 생성한 오브젝트를 넣음
            return newObj; //해당 오브젝트를 반환
        }
    }

    public void ReturnObject(GameObject obj, int id)
    {

        if (!Pool.ContainsKey(id)) return; //딕셔너리에 키가 없다면 반환
        obj.SetActive(false);
        Pool[id].Enqueue(obj);
    }
}
