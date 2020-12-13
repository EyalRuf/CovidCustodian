using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class MovingInteractable : Interactable
{
    public Rigidbody2D rb;
    public Vector2 movementVec;
    public float movementSpeed;
    public float moveSpeedPenalty;

    public float destroySelfX;
    public bool dodging;
    public float dodgingSpeed;
    public float dodgingCircleRadius;
    public float dodgingDistance;

    public bool beingPushed;
    public float pushPower;
    public float pushDecay;

    private string animatorPropNameXMovment = "xMovement";

    protected virtual void Start ()
    {
        animator.SetFloat(animatorPropNameXMovment, movementVec.x);
    }

    protected override void Update()
    {
        base.Update();

        if (Mathf.Abs(transform.position.x) > destroySelfX)
        {
            if (isEnabled)
            {
                cm.updateGlobalMeter(selfCoronaChange);
            }

            Destroy(gameObject);
        }

        AvoidCollisions();
        ApplyPush();
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + (movementVec * (movementSpeed - moveSpeedPenalty) * Time.deltaTime));
    }

    void AvoidCollisions ()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, dodgingCircleRadius, movementVec, dodgingDistance, LayerMask.GetMask("Interactable"));
        Transform hitTransform = null;
        foreach (RaycastHit2D hit in hits)
        {
            if (hit.collider != null && hit.collider.GetInstanceID() != coll2d.GetInstanceID())
            {
                hitTransform = hit.transform;
                break;
            } else
            {
                movementVec = new Vector2(movementVec.x, 0);
            }
        }

        if (hitTransform != null)
        {
            movementVec = new Vector2(movementVec.x, dodgingSpeed * (transform.position.y > hitTransform.position.y ? 1 : -1));
        }
    }

    void ApplyPush ()
    {
        if (beingPushed)
        {
            movementVec = new Vector2(movementVec.x, pushPower);
            pushPower = Mathf.Lerp(pushPower, 0, pushDecay);
            if (Mathf.Abs(pushPower) <= pushDecay)
            {
                beingPushed = false;
            }
        }
    }

    public void Push(float pushPower)
    {
        beingPushed = true;
        this.pushPower = pushPower;
    }
}
