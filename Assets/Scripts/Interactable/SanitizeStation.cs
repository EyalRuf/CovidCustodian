using UnityEngine;
using System.Collections;

public class SanitizeStation : Interactable
{
    public override IEnumerator Interact()
    {
        Debug.Log("start ss");
        yield return base.Interact();

        // SS states & animations

        this.Enable();
        Debug.Log("end ss");
    }
}
