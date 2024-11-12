using UnityEngine;

public enum EDirection
{
    left,
    right
}

[CreateAssetMenu(fileName ="MovementSO",menuName = "ItemData/Movement",order =1)]
public class MovementSO : ItemSO
{
    [Header("MovementSO")]
    private float speed;
    public float Speed { get { return speed; } set { speed = value; } }
  
    private EDirection direction;
    public EDirection Direction { get { return direction; } set { direction = value; } }
}
