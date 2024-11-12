using System.Collections.Generic;
using System.Diagnostics;
using UnityEditor;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
[System.Serializable]
public class PoolData
{
    public string name;
    public GameObject prefab;
    public int poolSize;
}
public class ObjectPool : MonoBehaviour
{
    public List<PoolData> data;
    public Dictionary<string, Queue<GameObject>> Pool = new Dictionary<string, Queue<GameObject>>();

    private void Start()
    {
        SetPool();
    }

    private void SetPool()
    {
        for(int i  = 0; i < data.Count; i++)
        {
            Queue<GameObject> queue = new Queue<GameObject>();
            for(int j = 0; j < data[i].poolSize; j++)
            {
                GameObject obj = Instantiate(data[i].prefab); 
                obj.SetActive(false);
                queue.Enqueue(obj);
            }
            Pool.Add(data[i].name, queue);
        }
    }

    public GameObject SpawnObject(string name)
    {
        if(!Pool.ContainsKey(name)) return null; //해당 키가 없을 경우 null반환

        if (Pool[name].Count > 0) //큐의 오브젝트가 0이 아니라면
        {
            GameObject obj = Pool[name].Dequeue(); //해당 큐에서 오브젝트를 꺼냄
            return obj; //해당 오브젝트를 반환
        }
        else //큐가 비어있다면
        {
            PoolData poolData = data.Find(n => n.name == name); //리스트에서 이름이 동일한 데이터를 받아옴

            GameObject newObj = Instantiate(poolData.prefab); // 새로 오브젝트를 생성
            newObj.SetActive(false); //오브젝트를 비활성화
            return newObj; //해당 오브젝트를 반환

        } 
    }

    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false); //게임 오브젝트를 비활성화
        string tagName = obj.name.Replace("(Clone)", ""); //복제하였을 때 생기는 (Clone)을 지워줌

        if (Pool.ContainsKey(tagName)) //딕셔너리에 해당 오브젝트의 키 값이 존재한다면
        {
            Pool[tagName].Enqueue(obj); //해당 오브젝트를 큐에 넣어줌
        }
        else //해당하는 키가 없다면 
        {
            Destroy(obj); //오브젝트를 제거
        }
    }
}