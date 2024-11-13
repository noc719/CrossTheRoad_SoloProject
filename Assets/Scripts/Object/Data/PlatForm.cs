using UnityEngine;

public class PlatForm : MonoBehaviour
{
    public PlatFormSO platFormSO;

    private float distance = 10f;

    private void Update()
    {
        if(CharacterManager.Instance.Player.transform.position.z - gameObject.transform.position.z > distance)
        {
            PlatFormManager.Instance.ReturnPlatForm(platFormSO.PlacementId, gameObject);
        }
    }
}
