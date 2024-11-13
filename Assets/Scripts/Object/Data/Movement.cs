using UnityEngine;

public class Movement : MonoBehaviour
{
    [HideInInspector] public float speed = 1f;

    private void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }
}
