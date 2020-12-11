using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Table : Interactable
{
    // Animator props
    private const string animatorPropNameIsDirty = "dirty";
    private const string animatorPropNameSparkleOver = "sparkleOver";

    // Table state
    public bool isDirty = false;
    public float sparkleDuration;

    // Clean to dirty variables
    public List<int> cleanToDirtyPeopleIdList;
    public int cleanToDirtyPeopleAmount = 4;
    public float cleanToDirtyPeopleRadius = 0.3f;
    public float cleanToDirtyTimer = 0;
    public float cleanToDirtyDuration = 30f;

    void Start()
    {
        cleanToDirtyPeopleIdList = new List<int>();

        if (isDirty)
        {
            animator.SetBool(animatorPropNameIsDirty, true);
        } else
        {
            this.Disable();
            cleanToDirtyTimer = cleanToDirtyDuration;
        }
    }

    protected override void Update()
    {
        base.Update();

        if (!isDirty)
        {
            cleanToDirtyTimer -= Time.deltaTime;

            List<Collider2D> colliders = new List<Collider2D>(Physics2D.OverlapCircleAll(transform.position, cleanToDirtyPeopleRadius * 2, LayerMask.GetMask("Interactable")));
            cleanToDirtyPeopleIdList.AddRange(colliders.ConvertAll<int>(c => 
                c.gameObject.GetInstanceID()).FindAll((c) => {
                    if (c != gameObject.GetInstanceID() && !cleanToDirtyPeopleIdList.Contains(c))
                    {
                        this.Warning();
                        return true;
                    }
                    return false;
            }));

            if (cleanToDirtyTimer <= 0 || cleanToDirtyPeopleIdList.Count >= cleanToDirtyPeopleAmount)
            {
                Dirty();
            }
        }
    }

    public override IEnumerator Interact()
    {
        Debug.Log("start table");
        yield return base.Interact();

        // Corona meter updates

        // Table states and animations
        StartCoroutine(Clean());

        Debug.Log("end table");
    }

    public void Dirty()
    {
        this.Enable();
        
        isDirty = true;
        animator.SetBool(animatorPropNameIsDirty, true);
    }

    public IEnumerator Clean()
    {
        isDirty = false;
        cleanToDirtyTimer = cleanToDirtyDuration;
        cleanToDirtyPeopleIdList.Clear();

        // Sparkle start
        animator.SetBool(animatorPropNameIsDirty, false);

        yield return new WaitForSeconds(sparkleDuration);

        // Sparkle over
        animator.SetTrigger(animatorPropNameSparkleOver);
    }
}
