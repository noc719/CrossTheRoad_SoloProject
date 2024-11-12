using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager<T> : MonoBehaviour where T : MonoBehaviour //다른 자료형이 들어갈수도 있기에 MonoBehaviour로 제한을 걸어둠
{
    private static T instance;
    public static T Instance
    {
        get 
        { 
            if(instance == null) //상속받은 클래스의 인스턴스가 null이라면
            {
                instance = FindObjectOfType<T>(); //어딘가에 해당 인스턴스가 존재할 수 있으니 해당 클래스의 타입을 찾는다.
                //instance = (T)FindAnyObjectByType<T>(); 
                if (instance == null) //그럼에도 찾을 수 없다면
                {
                    GameObject singletonObj = new GameObject(typeof(T).Name); //해당클래스의 이름으로 새로운 객체를 만들고
                    instance = singletonObj.AddComponent<T>(); //해당 타입으로 초기화 시켜준다.
                    DontDestroyOnLoad(singletonObj);
                }
            }
            return instance; 
        }
    }
}
