using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawnController : MonoBehaviour
{
    public bool goLeft = false; //������ ��ġ�� �����ִ� ��
    public bool goRight = false;

    public List<GameObject> items; //��ֹ��̳� �������� ��Ƶδ� ����Ʈ
    public List<SpawnPoint> pointLeft = new List<SpawnPoint>(); //���� ������
    public List<SpawnPoint> pointRight = new List<SpawnPoint>(); //������ ������

    private void Start()
    {
        int itemID1 = Random.Range(0, items.Count);
        int itemID2 = Random.Range(0, items.Count);
    }


}
