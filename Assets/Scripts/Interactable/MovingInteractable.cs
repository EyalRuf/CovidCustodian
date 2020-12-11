using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class MovingInteractable : Interactable
{
    private Rigidbody2D rb;
    public Vector2 movementVec;
    public float movementSpeed;
    public float moveSpeedPenalty;

    public float destroySelfX;
    public bool dodging;
    public float dodgingSpeed;
    public float dodgingCircleRadius;
    public float dodgingDistance;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
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
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + (movementVec * (movementSpeed - moveSpeedPenalty) * Time.deltaTime));
    }

    void AvoidCollisions ()
    {
        //RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, movementVec, dodgingDistance, LayerMask.GetMask("Interactable"));
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, dodgingCircleRadius, movementVec, dodgingDistance, LayerMask.GetMask("Interactable"));
        foreach (RaycastHit2D hit in hits)
        {
            if (hit.collider != null && hit.collider.GetInstanceID() != coll2d.GetInstanceID())
            {
                movementVec = new Vector2(movementVec.x, dodgingSpeed);
                break;
            } else
            {
                movementVec = new Vector2(movementVec.x, 0);
            }
        }
    }
}
