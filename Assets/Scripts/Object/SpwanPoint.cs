using UnityEngine;

public class SpwanPoint : MonoBehaviour
{
    public Transform startPoint;

    public ObjectPool pool;

    private void Start()
    {
        startPoint = transform;
        pool = GetComponent<ObjectPool>();
    }

    


}
