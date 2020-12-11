using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Couple : MovingInteractable
{
    public SpawnManager sm;
    public List<GameObject> spawnables;
    public float coupleBreakForce;

    public override IEnumerator Interact()
    {
        Debug.Log("start couple");
        yield return base.Interact();

        // Couple action & animations
        MovingInteractable first =
            sm.SpawnMovingInteractable(spawnables[Random.Range(0, spawnables.Count)], this.movementSpeed, this.movementVec, transform.position.x, transform.position.y + 0.1f);
        MovingInteractable second = 
            sm.SpawnMovingInteractable(spawnables[Random.Range(0, spawnables.Count)], this.movementSpeed, this.movementVec, transform.position.x, transform.position.y - 0.1f);

        first.Push(coupleBreakForce);
        second.Push(-coupleBreakForce);
        
        Debug.Log("end couple");
        Destroy(gameObject);
    }
}
