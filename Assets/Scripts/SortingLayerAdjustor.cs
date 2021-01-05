using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SortingLayerAdjustor : MonoBehaviour
{
    public bool isStationary;
    public SpriteRenderer[] srsToBeAdjusted;

    void Start ()
    {
        if (isStationary)
        {
            this.Adjust();
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        this.Adjust();
    }

    void Adjust()
    {
        int so = (int)(transform.position.y * 100) * -1;
        foreach (SpriteRenderer sr in srsToBeAdjusted)
        {
            sr.sortingOrder = so;
        }
    }
}
