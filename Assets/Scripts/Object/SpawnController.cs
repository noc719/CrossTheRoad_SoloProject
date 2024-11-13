using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    private EDirection eDirection;

    public SpawnPoint leftPoint;
    public SpawnPoint rightPoint;

    private void Start()
    {
        leftPoint.enabled = false;
        rightPoint.enabled = false;
        DecideDirection();
    }

    private void DecideDirection()
    {
        eDirection =  (EDirection)Random.Range(0, 2); //무작위로 방향을 설정

        switch (eDirection)
        {
            case EDirection.left:
                leftPoint.enabled = true; break;
            case EDirection.right:
                rightPoint.enabled = true; break;
        }
    }
}
