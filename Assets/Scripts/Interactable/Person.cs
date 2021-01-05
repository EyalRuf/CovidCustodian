using UnityEngine;
using System.Collections;

public class Person : MovingInteractable
{
    private string animatorPropNameMasked = "masked";

    protected override void Start()
    {
        base.Start();

        animator.SetBool(animatorPropNameMasked, !this.isEnabled);
    }

    public override IEnumerator Interact()
    {
        yield return base.Interact();
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
