using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator Animator;
    public string VerticalMovePropertyName;
    public string HorizontalMovePropertyName;
    public InputController InputController;

    private void Update()
    {
        if (Animator == null)
        {
            return;
        }

        Animator.SetFloat(VerticalMovePropertyName, InputController.AxisInput.y);
        Animator.SetFloat(HorizontalMovePropertyName, InputController.AxisInput.x);
    }
}
