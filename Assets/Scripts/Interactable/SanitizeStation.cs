using UnityEngine;
using System.Collections;

public class SanitizeStation : Interactable
{
    public override IEnumerator Interact()
    {
        yield return base.Interact();

        // Re-enable ss to be reused again
        this.Enable();
    }
}
