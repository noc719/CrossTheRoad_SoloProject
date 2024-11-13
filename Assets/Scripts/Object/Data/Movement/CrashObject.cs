using UnityEngine;

public class CrashObject : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("GameOver");
            GameManager.Instance.GameOver();
        }
    }
}
