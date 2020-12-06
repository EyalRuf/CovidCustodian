using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class InteractBtn : MonoBehaviour
{
    public bool isPressed = false;
    public float clickDuration = 1;
    public float clickTimer = 0;

    void Update()
    {
        if (isPressed) {
            clickTimer -= Time.deltaTime;
            if (clickTimer <= 0)
            {
                isPressed = false;
            }
        }
    }

    public void pressed ()
    {
        isPressed = true;
        clickTimer = clickDuration;
    }
}
