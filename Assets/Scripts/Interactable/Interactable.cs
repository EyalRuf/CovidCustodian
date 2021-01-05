using UnityEngine;
using System.Collections;

public class Interactable : MonoBehaviour
{
    public CoronaMetersManager cm;
    public Animator animator;
    public Collider2D coll2d;
    public GameObject highlight;

    public bool isEnabled = true;
    public bool isHighlighted = false;
    public float interactionDuration = 1f;
    
    public float globalCoronaChange;
    public float selfCoronaChange;

    public bool isWarning = false;
    public SpriteRenderer warningSR;
    public float warningDuration = 0.5f;
    public float warningTimer = 0;

    public GameObject skull;

    protected virtual void Update()
    {
        if (isWarning)
        {
            warningTimer -= Time.deltaTime;
            
            if (warningTimer <= 0)
            {
                isWarning = false;
            } else
            {
                float newA = warningSR.color.a - ((1 / warningDuration) * Time.deltaTime);
                warningSR.color = new Color(warningSR.color.r, warningSR.color.g, warningSR.color.b, newA);
            }
        }
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

    public virtual IEnumerator Interact ()
    {
        Unhighlight();
        Disable();

        yield return new WaitForSeconds(interactionDuration);
        cm.updateGlobalMeter(globalCoronaChange);
        cm.updateSelfMeter(selfCoronaChange);
    }

    public virtual void Disable ()
    {
        isEnabled = false;
        skull.SetActive(false);
    }

    public virtual void Enable()
    {
        isEnabled = true;
        skull.SetActive(true);
    }

    public virtual void Warning ()
    {
        isWarning = true;
        warningTimer = warningDuration;
        warningSR.color = new Color(warningSR.color.r, warningSR.color.g, warningSR.color.b, 1);
    }
}
