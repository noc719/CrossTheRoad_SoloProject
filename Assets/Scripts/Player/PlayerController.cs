using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Vector3 moveValue;
    public Transform shape;

    public float moveDistance = 1 ; //움직일 거리

    private void Start()
    {
        moveValue = Vector3.zero;
    }

    private void Move(Vector3 input)
    {
        Vector3 moveInput = input;
        transform.Translate(moveInput);  //물리 연산으로 움직임을 처리하기엔 1칸 1칸 정확한 위치 이동이 필요하므로 직접 좌표를 이동해주려한다.
    }

    private void Rotate(Vector3 input)
    {
        shape.rotation = Quaternion.Euler(270, input.x * 90, 0);  //x 축을 돌리면 위 아래 y축을 돌리면 왼쪽 오른쪽을 회전 시킨다. 
        //y축만 할당하면 엎어지기 때문에 엎어진 상태의 90도에서 270도를 더 돌려주어 원상태로 복구시켜준다.
    }

    public void MoveInput(InputAction.CallbackContext context)
    {
        Vector3 moveInput = context.ReadValue<Vector3>();

        if (moveInput.magnitude > 1) return; //대각선으로 입력받는다면 입력값이 1보다 커지게 됨 (입력 무효 처리)

        if (context.phase == InputActionPhase.Performed)//Performed는 누르고 있지않더라도 지속적으로 값을 받음
        {
            if (moveInput.magnitude == 0f) // 입력받는 값이 없을 때
            {
                Move(moveValue); 
                Rotate(moveValue);
                moveValue = Vector3.zero; //움직이고나서 다시 변수를 초기화
            }
            else 
            {
                moveValue =  moveInput * moveDistance; //입력을 하였을 때 움직일 방향을 설정
            }
        }
    }
}
