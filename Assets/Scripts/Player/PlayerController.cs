using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Vector3 moveValue;
    private Rigidbody rb;
    public Transform shape;

    public float moveDistance = 5 ; //움직일 거리

    private void Start()
    {
        moveValue = Vector3.zero;
        rb = GetComponent<Rigidbody>();
    }

    private void Move(Vector3 input)
    {
        Vector3 moveInput = input.normalized * moveDistance;
        rb.velocity = moveInput;  //에셋이 아닌 직접 구현을 해보고 싶었는데 좀 더 고민해보야할 것 같다. 
    }

    private void Rotate(Vector3 input)
    {
        transform.rotation = Quaternion.Euler(270, input.x * 90, 0);  //x 축을 돌리면 위 아래 y축을 돌리면 왼쪽 오른쪽을 회전 시킨다. 
    }

    public void MoveInput(InputAction.CallbackContext context)
    {
        Vector3 moveInput = context.ReadValue<Vector3>();

        if (moveInput.magnitude > 1) return; //대각선으로 입력받는다면 입력값이 1보다 커지게 됨 (입력 무효 처리)

        if (context.phase == InputActionPhase.Performed)//Performed는 누르고 있지않더라도 지속적으로 값을 받음
        {
            if (moveInput.magnitude == 0f) // 입력받는 값이 없을 때
            {
                Move(moveValue); //Fixed Update에 집어넣을 경우 지속적으로 속력을 더하므로 트리거를 두는게 맞는 것 같다.
                Rotate(moveInput);
                moveValue = Vector3.zero; //움직이고나서 다시 변수를 초기화
            }
            else 
            {
                Debug.Log("입력받는 상태");
                moveValue =  moveInput * moveDistance; //입력을 하였을 때 움직일 방향을 설정
                Debug.Log($"현재 입력받은 값은 {moveInput} 그리고 현재 변수의 값은 {moveValue}");
            }
        }
    }
}
