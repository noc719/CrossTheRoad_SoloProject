using UnityEngine;

public class ItemData : MonoBehaviour 
{
    public int id;
    public GameObject prefab;

    private void Update()
    {
        if (transform.position.x < -25f || transform.position.x > 25f) //일정거리에 도달하면
        {
            PoolManager.Instance.ReturnObject(gameObject, id); //풀을 반환
        }
    }
}
