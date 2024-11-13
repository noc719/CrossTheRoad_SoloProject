
using System.Collections.Generic;
using UnityEngine;

public class PlatFormManager : Manager<PlatFormManager>
{
    public List<PlatForm> platForms;
    public Dictionary<int, Queue<GameObject>> platformsDict;

    private float lastPos = 0;
    private float lastScale = 0;

    private void Start()
    {
        SetPool(); // 사용할 플랫폼 생성

        SpawnFromPool(0); //시작하는 지점은 초원으로
        for (int i = 0; i < 6; i++) //초기 지형을 생성해줌
        {
            SpawnFromPool(DecidePlatForm());
        }
    }

    private void Update()
    {
        
    }

    private void SpawnFromPool(int num)
    {
        GameObject obj = CreatePlatForm(num);  
        float offset = lastPos + (lastScale * 0.5f); // 오브젝트의 중심점에서 반을 더 가야 가장자리가 나오게된다. 따라서 z축방향으로 마지막 오브젝트의 절반만큼 일단 거리를 벌려준 것
        offset += (obj.transform.localScale.z) * 0.5f; //현재 오브젝트 또한 중심점까지 반을 더 가야한다. 차지하는 공간을 생각하였을 때 z축의 방향으로 scale의 절반만큼 더 거리를 벌린 것
        obj.transform.position = new Vector3(0,0,offset); //위에서 거리를 벌린만큼의 값을 안에 집어넣어준다. 
        lastPos = obj.transform.position.z; //마지막 지점은 다시 이 오브젝트가 현재 위치한 좌표로 설정하여주고
        lastScale = obj.transform.localScale.z;//lastScale에도 이 오브젝트의 z scale 값으로 초기화해준다

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
