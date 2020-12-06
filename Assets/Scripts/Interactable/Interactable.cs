using UnityEngine;
using System.Collections;

public class Interactable : MonoBehaviour
{
    public bool isHighlighted = false;
    public float interactionDuration = 1f;
    public bool isEnabled = true;
    public Collider2D collider;
    public GameObject highlight;

    void Awake()
    {
        collider = GetComponent<Collider2D>();
    }

    public void Highlight()
    {
        isHighlighted = true;
        highlight.SetActive(true);
    }

    public void Unhighlight()
    {
        isHighlighted = false;
        highlight.SetActive(false);
    }

    public virtual void Interact ()
    {
        Unhighlight();
        isEnabled = false;
        Debug.Log("interacted Interactable");
    }
}
