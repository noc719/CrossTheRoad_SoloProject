
using System.Collections.Generic;
using UnityEngine;

public class PlatFormManager : Manager<PlatFormManager>
{
    public List<PlatForm> platForms;
    public Dictionary<int, Queue<GameObject>> platformsDict;
    private Vector3 spawnPoint = Vector3.zero;

    private void Start()
    {
        SetPool(); // 사용할 플랫폼 생성

        for (int i = 0; i < 6; i++) //초기 지형을 생성해줌
        {
            SpawnFromPool();
        }
    }

    private void Update()
    {
        
    }

    private void SpawnFromPool()
    {
        int randomNumber = DecidePlatForm(); //랜덤한 플랫폼을 생성하기위해 난수 로직을 돌림
        GameObject obj = CreatePlatForm(randomNumber);  //생성할 플랫폼
        obj.transform.position = spawnPoint; //오브젝트가 생성될 지점을 정해줌
        spawnPoint += Vector3.forward; //spawnPoint를 플랫폼이 차지하는 만큼 앞으로 당김
        obj.SetActive(true);
    }

    private void SetPool()
    {
        platformsDict = new Dictionary<int, Queue<GameObject>>();

        foreach(var data in platForms)
        {
            Queue<GameObject> queue = new Queue<GameObject>();
            for(int i = 0; i <2; i++)
            {
                GameObject obj = Instantiate(data.platFormSO.prefab, this.transform);
                obj.SetActive(false);
                queue.Enqueue(obj);
            }
            platformsDict.Add(data.platFormSO.platformId, queue);
        }
    }

    public GameObject CreatePlatForm(int key)
    {
        if(!platformsDict.ContainsKey(key))return null;

        if (platformsDict[key].Count > 0) //해당 키의 큐가 비어있지 않다면 
        {
            GameObject obj = platformsDict[key].Dequeue();
            obj.SetActive(true);
            return obj;
        }
        else
        {
            PlatForm platForm = platForms.Find(n => n.platFormSO.platformId == key);
            GameObject obj = Instantiate(platForm.platFormSO.prefab,this.transform);
            obj.SetActive(false);
            return obj;
        }
    }

    private int DecidePlatForm()
    {
        int SelectedId = Random.Range(0, platformsDict.Keys.Count); //키의 수만큼 난수값을 범위로 잡음
        return SelectedId;
    }

    public void ReturnPlatForm(int key, GameObject obj)
    {
        if (!platformsDict.ContainsKey(key)) return;

        obj.SetActive(false);
        platformsDict[key].Enqueue(obj);
    }
}
