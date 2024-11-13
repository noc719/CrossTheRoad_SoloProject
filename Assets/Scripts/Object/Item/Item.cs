using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemSO ItemSO;

    public int poolSize = 3;

    private void Update()
    {
        if (transform.position.x < -25f || transform.position.x > 25f) //일정거리에 도달하면
        {
            ItemManager.Instance.ReturnObject(gameObject, ItemSO.ItemId); //풀을 반환
        }
    }
}
