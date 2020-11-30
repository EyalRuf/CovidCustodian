using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 movementVec = Vector2.zero;
    private PlayerInput pi;
    
    public float movementSpeed;
    public float movementLerpFactor;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        pi = GetComponent<PlayerInput>();
    }

    void Update()
    {
        Vector2 userInput = pi.actions["Move"].ReadValue<Vector2>();

        float lerpedX = Mathf.Lerp(movementVec.x, userInput.x, movementLerpFactor);
        float lerpedY = Mathf.Lerp(movementVec.y, userInput.y, movementLerpFactor);

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

    void FixedUpdate()
    {
        Move(movementVec);
    }

    void Move(Vector2 movementVec)
    {
        rb.MovePosition(rb.position + (movementVec * movementSpeed * Time.deltaTime)); 
    }
}
