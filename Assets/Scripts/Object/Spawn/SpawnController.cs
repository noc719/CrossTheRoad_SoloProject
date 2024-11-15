using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpawnPoints
{
    public SpawnPoint leftPoint;
    public SpawnPoint rightPoint;
}

public class SpawnController : MonoBehaviour
{
    private EDirection eDirection;

    public List<SpawnPoints> spawnPoints;

    private void Start()
    {
        for (int i = 0; i < spawnPoints.Count; i++)
        {
            spawnPoints[i].leftPoint.gameObject.SetActive(false);
            spawnPoints[i].rightPoint.gameObject.SetActive(false);
        }

        DecideDirection();
    }

    private void DecideDirection()
    {
        for (int i = 0; i < spawnPoints.Count; i++)
        {
            eDirection = (EDirection)Random.Range(0, 2); //무작위로 방향을 설정

            switch (eDirection)
            {
                case EDirection.left:
                    spawnPoints[i].leftPoint.gameObject.SetActive(true); break;
                case EDirection.right:
                    spawnPoints[i].rightPoint.gameObject.SetActive(true); break;
            }
        }
        
    }
}
