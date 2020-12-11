using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    [SerializeField] private GameManager gm;
    [SerializeField] private JoystickMovement jm;
    [SerializeField] private InteractBtn intBtn;
    
    public Vector2 movementInput = Vector2.zero;
    public bool isInteracting = false;

    void Update()
    {
        if (gm._isMobile)
        {
            movementInput.x = jm.HorizontalInput();
            movementInput.y = jm.VerticalInput();
            isInteracting = intBtn.isPressed;
        } else
        {
            movementInput.x = Input.GetAxis("Horizontal");
            movementInput.y = Input.GetAxis("Vertical");
            isInteracting = Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.Mouse0);
        }
    }
}
