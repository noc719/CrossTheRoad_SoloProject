using UnityEngine;


[CreateAssetMenu(fileName ="MovementSO",menuName = "Item/Movement",order =1)]
public class MovementSO : ItemSO
{
    [Header("MovementSO")]

    [SerializeField]
    private float speed;
    public float Speed { get { return speed; } set { speed = value; } }

}
