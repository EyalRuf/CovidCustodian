using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Couple : MovingInteractable
{
    public SpawnManager sm;
    public GameObject spawnedTop;
    public GameObject spawnedBottom;
    public float coupleBreakForce;

    public override IEnumerator Interact()
    {
        Debug.Log("start couple");
        yield return base.Interact();

        // Couple action & animations
        MovingInteractable top =
            sm.SpawnMovingInteractable(spawnedTop, this.movementSpeed, this.movementVec, transform.position.x, transform.position.y + 0.1f);
        MovingInteractable bottom = 
            sm.SpawnMovingInteractable(spawnedBottom, this.movementSpeed, this.movementVec, transform.position.x, transform.position.y - 0.1f);

        top.Push(coupleBreakForce);
        bottom.Push(-coupleBreakForce);
        
        Debug.Log("end couple");
        Destroy(gameObject);
    }
}
