using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager<T> : MonoBehaviour where T : MonoBehaviour //�ٸ� �ڷ����� ������ �ֱ⿡ MonoBehaviour�� ������ �ɾ��
{
    private static T instance;
    public static T Instance
    {
        get 
        { 
            if(instance == null) //��ӹ��� Ŭ������ �ν��Ͻ��� null�̶��
            {
                instance = FindObjectOfType<T>(); //��򰡿� �ش� �ν��Ͻ��� ������ �� ������ �ش� Ŭ������ Ÿ���� ã�´�.
                //instance = (T)FindAnyObjectByType<T>(); 
                if (instance == null) //�׷����� ã�� �� ���ٸ�
                {
                    GameObject singletonObj = new GameObject(typeof(T).Name); //�ش�Ŭ������ �̸����� ���ο� ��ü�� �����
                    instance = singletonObj.AddComponent<T>(); //�ش� Ÿ������ �ʱ�ȭ �����ش�.
                    DontDestroyOnLoad(singletonObj);
                }
            }
            return instance; 
        }
    }
}
