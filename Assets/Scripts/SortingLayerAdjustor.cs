using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(SpriteRenderer))]
public class SortingLayerAdjustor : MonoBehaviour
{
    public SpriteRenderer sr;
    public List<GameObject> objectsToAdjustTo = new List<GameObject>();

    // Update is called once per frame
    void Update()
    {
        if (objectsToAdjustTo.Count > 0)
        {
            Vector2 myPos = transform.position;

            if (objectsToAdjustTo.Count > 1)
            {
                objectsToAdjustTo.Sort((a, b) => Physics2D.Distance(a.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>()).distance >
                    Physics2D.Distance(b.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>()).distance ? 1 : -1);
            }

            GameObject obj = objectsToAdjustTo[0];
            Vector2 objPos = obj.transform.position;

            if (objPos.y > myPos.y)
            {
                sr.sortingOrder = objectsToAdjustTo.Count + 1;
            } else
            {
                sr.sortingOrder = 0;
            }
        }
    }
}
