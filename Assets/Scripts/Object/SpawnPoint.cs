using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public enum EDirection
{
    left,
    right
}

public class SpawnPoint : MonoBehaviour
{
    public Transform startPoint = null; //빈 오브젝트를 두고 해당 지점에 소환시킬 것

    public Item spawnData = null; //오브젝트 풀에서 가져올 

    [Header("SpawnDelay")]
    public float spawnDelayMin = 1f; //소환에 걸리는 시간
    public float spawnDelayMax = 4f;
    private float lastCheckTime = 0;
    private float spawnDelayTime = 0;

    public EDirection Edirection = EDirection.left;
    private float direction = 0;

    public int spawnCount = 0;

    private void Start()
    {
        SetDirection();
    }

    private void Update()
    {
        if (Time.time > lastCheckTime + spawnDelayTime)
        {
            lastCheckTime = Time.time;
            spawnDelayTime = Random.Range(spawnDelayMin, spawnDelayMax);
            SpawnItem();
        }
    }

    private void SpawnItem()
    {
        GameObject obj = ItemManager.Instance.SpawnObject(spawnData.ItemSO.ItemId);
        obj.GetComponent<Movement>().speed = spawnData.ItemSO.Speed;
        obj.transform.rotation = obj.transform.rotation * Quaternion.Euler(0, direction, 0);
        obj.transform.position = transform.position;
    }

    private void SetDirection()
    {
        switch (Edirection) //설정에 따라 진행 방향을 변경
        {
            case EDirection.left:
                direction = 0; break;
            case EDirection.right:
                direction = 180; break;
        }
        Debug.Log($"방향은 {Edirection}");
    }
}
