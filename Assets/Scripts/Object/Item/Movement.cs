using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 1f;

    private void Start()
    {

    }

    private void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }
}