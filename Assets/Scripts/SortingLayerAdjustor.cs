using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SortingLayerAdjustor : MonoBehaviour
{
    public SpriteRenderer sr;
    public bool isStationary;

    void Start ()
    {
        if (isStationary)
        {
            sr.sortingOrder = (int)(transform.position.y * 100) * -1;
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        sr.sortingOrder = (int)(transform.position.y * 100) * -1;
    }
}
