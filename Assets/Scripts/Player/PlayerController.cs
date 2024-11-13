using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Vector3 moveValue;
    private Rigidbody rb;
    public Transform shape;

    public float moveDistance = 5 ; //������ �Ÿ�

    private void Start()
    {
        moveValue = Vector3.zero;
        rb = GetComponent<Rigidbody>();
    }

    private void Move(Vector3 input)
    {
        Vector3 moveInput = input.normalized * moveDistance;
        rb.velocity = moveInput;  //������ �ƴ� ���� ������ �غ��� �;��µ� �� �� ����غ����� �� ����. 
    }

    private void Rotate(Vector3 input)
    {
        transform.rotation = Quaternion.Euler(270, input.x * 90, 0);  //x ���� ������ �� �Ʒ� y���� ������ ���� �������� ȸ�� ��Ų��. 
    }

    public void MoveInput(InputAction.CallbackContext context)
    {
        Vector3 moveInput = context.ReadValue<Vector3>();

        if (moveInput.magnitude > 1) return; //�밢������ �Է¹޴´ٸ� �Է°��� 1���� Ŀ���� �� (�Է� ��ȿ ó��)

        if (context.phase == InputActionPhase.Performed)//Performed�� ������ �����ʴ��� ���������� ���� ����
        {
            if (moveInput.magnitude == 0f) // �Է¹޴� ���� ���� ��
            {
                Move(moveValue); //Fixed Update�� ������� ��� ���������� �ӷ��� ���ϹǷ� Ʈ���Ÿ� �δ°� �´� �� ����.
                Rotate(moveInput);
                moveValue = Vector3.zero; //�����̰��� �ٽ� ������ �ʱ�ȭ
            }
            else 
            {
                Debug.Log("�Է¹޴� ����");
                moveValue =  moveInput * moveDistance; //�Է��� �Ͽ��� �� ������ ������ ����
                Debug.Log($"���� �Է¹��� ���� {moveInput} �׸��� ���� ������ ���� {moveValue}");
            }
        }
    }
}
