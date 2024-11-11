using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Vector3 moveValue;
    private Rigidbody rb;

    public float moveDistance = 5 ; //움직일 거리

    private void Start()
    {
        moveValue = Vector3.zero;
        rb = GetComponent<Rigidbody>();
    }

    private void Move(Vector3 value)
    {
        rb.velocity = value;
    }

    public void MoveInput(InputAction.CallbackContext context)
    {
        Vector3 moveInput = context.ReadValue<Vector3>();

        if (moveInput.magnitude > 1) return; //대각선으로 입력받는다면 입력값이 1보다 커지게 됨 (입력 무효 처리)

        if (context.phase == InputActionPhase.Performed)//Performed는 누르고 있지않더라도 지속적으로 값을 받음
        {
            if (moveInput.magnitude == 0f) // 입력받는 값이 없을 때
            {
                //해당방향으로 움직이고 다시 초기화해야함
                Move(transform.position + moveValue);
                moveValue = Vector3.zero; //움직이고나서 다시 변수를 초기화
                Debug.Log("Input종료");
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
