using UnityEngine;
using System.Collections;

public class Couple : MovingInteractable
{
    public override IEnumerator Interact()
    {
        Debug.Log("start couple");
        yield return base.Interact();

        // Corona meter updates

        // Couple states & animations

        Debug.Log("end couple");
    }
}
