using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public Transform startPoint = null; //빈 오브젝트를 두고 해당 지점에 소환시킬 것

    [Header("Delay")]
    public float minSpawnDelay = 1f; //소환 쿨타임
    public float maxSpawnDelay = 5f;
    [Header("Speed")]
    public float minSpeed = 1f; //움직이는 물체의 이동속도
    public float maxSpeed = 5f;

    public bool isPlacement = false; // 고정 설치물인지 판별하는 불값
    public int spawnCount = 4;

    private float lastTime = 0; //
    private float delayTime = 0; //랜덤값으로 결정된 소환 쿨타임
    private float speed = 0; //랜덤값으로 결정된 이동속도

    [HideInInspector] public ItemData item = null;
    [HideInInspector] public bool isLeft = false; //오른쪽 왼쪽 여부
    [HideInInspector] public float spawnLeftPosition = 0;
    [HideInInspector] public float spawnRightPosition = 0;

    private void Start()
    {
        if (isPlacement)
        {
            for (int i = 0; i<spawnCount; i++)
            {
                SpawnItem();
            }
        }
        else
        {
            speed = Random.Range(minSpeed, maxSpeed);
        }

    }

    private void SpawnItem()
    {
        GameObject obj = PoolManager.Instance.SpawnObject(item.id);
        obj.transform.position = GetSpawnPosition();

        float direction = 0;
        if (isLeft) direction = 180; //만약 왼쪽이라면 아이템을 180도 돌린다.

        if (!isPlacement)
        {
            //obj.GetComponent<Mover>().speed = speed;
            obj.transform.rotation = obj.transform.rotation * Quaternion.Euler(new Vector3(0, direction, 0));
            //좌우 여부에 따라 오브젝트의 방향 조정
        }
    }

    private Vector3 GetSpawnPosition()
    {
        if (isPlacement) //고정된 아이템일 경우
        {
            return new Vector3(Random.Range(spawnLeftPosition, spawnRightPosition), startPoint.position.y, startPoint.position.z); //좌 우로 길게 늘어져있기에
        }
        else
        {
            return startPoint.position; //움직이는 물체의 경우 시작지점에서 생성
        }
    }
}
