using UnityEngine;
using System.Collections;

public class Person : MovingInteractable
{
    private string animatorPropNameMasked = "masked";
    private string animatorPropNameXMovment = "xMovement";

    void Start()
    {
        // Setting masked/unmasked + direction of animations 
        animator.SetFloat(animatorPropNameXMovment, movementVec.x);
        animator.SetBool(animatorPropNameMasked, !this.isEnabled);
    }

    public override IEnumerator Interact()
    {
        Debug.Log("start person");
        yield return base.Interact();

        Debug.Log("end person");
    }

    public override void Enable()
    {
        base.Enable();
        animator.SetBool(animatorPropNameMasked, false);
    }

    public override void Disable()
    {
        base.Disable();
        animator.SetBool(animatorPropNameMasked, true);
    }
}
