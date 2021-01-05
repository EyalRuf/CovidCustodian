using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D)), RequireComponent(typeof(Collider2D))]
public class PlayerController : MonoBehaviour
{
    public InputManager inputManager;
    public PlayerAnimation pAnimation;
    private Rigidbody2D rb;
    private Collider2D playerCollider;
    public Vector2 movementVec = Vector2.zero;
    
    public float movementSpeed;
    public float movementLerpFactor;

    public bool isInteracting = false;
    public float interactionTimer = 0;
    public float interactionRadius;
    public Interactable closestInteractable;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
    }

    void Update()
    {
        calcMovements();

        if (!isInteracting)
        {
            FindClosestInteractable();

            if (closestInteractable != null && inputManager.isInteracting)
            {
                interactionTimer = closestInteractable.interactionDuration;
                pAnimation.InteractionAnimation(true);
                isInteracting = true;
                StartCoroutine(closestInteractable.Interact());
            }
        } else
        {
            interactionTimer -= Time.deltaTime;
            if (interactionTimer <= 0)
            {
                isInteracting = false;
                pAnimation.InteractionAnimation(false);
            }
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + (movementVec * movementSpeed * Time.deltaTime));
    }

    void calcMovements()
    {
        Vector2 movementInput = isInteracting ? Vector2.zero : inputManager.movementInput;

        float lerpedX = Mathf.Lerp(movementVec.x, movementInput.x, movementLerpFactor);
        float lerpedY = Mathf.Lerp(movementVec.y, movementInput.y, movementLerpFactor);

        movementVec = new Vector2(lerpedX, lerpedY);

        if (Mathf.Abs(movementVec.x) < 0.01f)
        {
            movementVec.x = 0;
        }

        if (Mathf.Abs(movementVec.y) < 0.01f)
        {
            movementVec.y = 0;
        }
    }

    void FindClosestInteractable()
    {
        if (closestInteractable != null)
        {
            if (!closestInteractable.isEnabled || Physics2D.Distance(closestInteractable.coll2d, playerCollider).distance > interactionRadius)
            {
                closestInteractable.Unhighlight();
                closestInteractable = null;
            }
        }

        LayerMask mask = LayerMask.GetMask("Interactable");
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, interactionRadius * 2, mask);
        Collider2D closestCollider = null;

        if (colliders.Length > 0)
        {
            closestCollider = colliders[0];

            float closestDistance = Physics2D.Distance(closestCollider, playerCollider).distance;
            for (int i = 1; i < colliders.Length; i++)
            {
                if (Physics2D.Distance(colliders[i], playerCollider).distance < closestDistance)
                {
                    closestCollider = colliders[i];
                }
            }
        }

        if (closestCollider != null)
        {
            Interactable newClosest = closestCollider.GetComponent<Interactable>();
            if (newClosest.isEnabled && (closestInteractable == null || newClosest.GetInstanceID() != closestInteractable.GetInstanceID()))
            {
                if (closestInteractable != null)
                {
                    closestInteractable.Unhighlight();
                }

                closestInteractable = newClosest;
                closestInteractable.Highlight();
            }
        }
    }
}
