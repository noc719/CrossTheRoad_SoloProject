using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Vector3 moveValue;
    public Transform shape;

    public float moveDistance = 1 ; //������ �Ÿ�

    private void Start()
    {
        moveValue = Vector3.zero;
    }

    private void Move(Vector3 input)
    {
        Vector3 moveInput = input;
        transform.Translate(moveInput);  //���� �������� �������� ó���ϱ⿣ 1ĭ 1ĭ ��Ȯ�� ��ġ �̵��� �ʿ��ϹǷ� ���� ��ǥ�� �̵����ַ��Ѵ�.
    }

    private void Rotate(Vector3 input)
    {
        shape.rotation = Quaternion.Euler(270, input.x * 90, 0);  //x ���� ������ �� �Ʒ� y���� ������ ���� �������� ȸ�� ��Ų��. 
        //y�ุ �Ҵ��ϸ� �������� ������ ������ ������ 90������ 270���� �� �����־� �����·� ���������ش�.
    }

    public void MoveInput(InputAction.CallbackContext context)
    {
        Vector3 moveInput = context.ReadValue<Vector3>();

        if (moveInput.magnitude > 1) return; //�밢������ �Է¹޴´ٸ� �Է°��� 1���� Ŀ���� �� (�Է� ��ȿ ó��)

        if (context.phase == InputActionPhase.Performed)//Performed�� ������ �����ʴ��� ���������� ���� ����
        {
            if (moveInput.magnitude == 0f) // �Է¹޴� ���� ���� ��
            {
                Move(moveValue); 
                Rotate(moveValue);
                moveValue = Vector3.zero; //�����̰��� �ٽ� ������ �ʱ�ȭ
            }
            else 
            {
                moveValue =  moveInput * moveDistance; //�Է��� �Ͽ��� �� ������ ������ ����
            }
        }
    }
}
