using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            bool getId = TryGetComponent<Placement>(out Placement placement);
            PlacementManager.Instance.ReturnPlacement(placement.placementSO.PlacementId, this.gameObject);
        }
    }
}
