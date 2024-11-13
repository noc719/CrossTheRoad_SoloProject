using UnityEngine;

public class PlatForm : MonoBehaviour
{
    public PlatFormSO platFormSO;

    private void Update()
    {
        //플레이어와 일정거리 멀어지면 풀로 반환되도록
        //PlatFormManager.Instance.ReturnPlatForm(platFormSO.platformId,gameObject);
    }
}
