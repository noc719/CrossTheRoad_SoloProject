using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawnController : MonoBehaviour
{
    public bool goLeft = false; //������ ��ġ�� �����ִ� ��
    public bool goRight = false;

    public List<GameObject> items; //�������� ������ �������� ��ȯ
    public List<SpawnPoint> pointLeft = new List<SpawnPoint>(); //���� ������
    public List<SpawnPoint> pointRight = new List<SpawnPoint>(); //������ ������


    //����ȭ�� ���� ������Ʈ Ǯ
    //��ȯ�� ����� �ش� ��ġ���� �̵��ϵ��� �̵����� ����
}
