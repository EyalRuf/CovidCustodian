using UnityEngine;
using System.Collections;

public class Table : Interactable
{
    public override void Interact()
    {
        base.Interact();

        // Decrease global corona

        // Inc player corona

        // Change table sprite to clean

        Debug.Log("interacted Table");
    }
}
