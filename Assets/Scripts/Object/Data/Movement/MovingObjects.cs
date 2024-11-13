using UnityEngine;

public class MovingObjects : MonoBehaviour
{
    public MovingObjectSO objectSO;

    public int poolSize = 3;

    private void Update()
    {
        if (transform.position.x < -25f || transform.position.x > 25f ) //플랫폼 양옆 크기만큼 범위
        {
            MovingObjectsManager.Instance.ReturnObject(gameObject, objectSO.MoveObjectId); //풀을 반환
        }
    }
}
