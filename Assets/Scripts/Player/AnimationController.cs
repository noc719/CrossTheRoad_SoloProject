using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimationController : MonoBehaviour
{
    private Animator chickAnimator;

    private string jumpParameter = "jump";
    private int Jump;

    private void Start()
    {
        if(TryGetComponent<Animator>(out Animator animator))
        {
            chickAnimator = animator;
        }

        Jump = Animator.StringToHash(jumpParameter); 
    }

    public void Move(InputAction.CallbackContext context)
    {
        Vector3 input = context.ReadValue<Vector3>();

        if (input.magnitude > 1f) return;

        if (context.performed)
        {
            if (input.magnitude == 0f)
            {
                chickAnimator.SetBool(Jump, false); 
            }
            else
            {
                chickAnimator.SetBool(Jump, true); //에셋의 애니메이터에서 jumpStart 로 가는 condition이 jump가 true일때로 설정되어있다.
            }
        }
    }
}
