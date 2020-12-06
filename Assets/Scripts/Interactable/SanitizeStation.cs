using UnityEngine;
using System.Collections;

public class SanitizeStation : Interactable
{
    public override void Interact()
    {
        base.Interact();

        // Decrease player corona

        Debug.Log("interacted SanitizeStation");
    }
}
