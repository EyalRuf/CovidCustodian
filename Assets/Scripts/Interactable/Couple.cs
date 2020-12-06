using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Couple : Interactable
{
    private Rigidbody2D rb;
    public float movementSpeed;
    public Vector2 movementVec;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + (movementVec * movementSpeed * Time.deltaTime));
    }

    public override void Interact()
    {
        base.Interact();

        // Decrease global corona

        // Inc player corona

        // Change table sprite to clean

        Debug.Log("interacted Couple");
    }
}
