using UnityEngine;
using System.Collections;

public class MasklessPerson : MovingInteractable
{
    public override IEnumerator Interact()
    {
        Debug.Log("start person");
        yield return base.Interact();

        // Corona meter updates

        // Person states & animations

        Debug.Log("end person");
    }
}
