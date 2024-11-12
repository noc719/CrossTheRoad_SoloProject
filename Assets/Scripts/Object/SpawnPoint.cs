using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public Transform startPoint;

    public ObjectPool pool;

    private void Start()
    {
        startPoint = transform;
        pool = GetComponent<ObjectPool>();
    }

    


}
