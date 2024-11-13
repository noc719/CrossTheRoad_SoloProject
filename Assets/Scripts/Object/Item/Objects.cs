using UnityEngine;

public class Objects : MonoBehaviour
{
    public ObjectSO objectSO;

    public int poolSize = 3;

    private void Update()
    {
        if (transform.position.x < -25f || transform.position.x > 25f) //일정거리에 도달하면
        {
            MovingObjectsManager.Instance.ReturnObject(gameObject, objectSO.ItemId); //풀을 반환
        }
    }
}
