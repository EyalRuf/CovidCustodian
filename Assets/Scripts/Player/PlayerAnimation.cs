using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public PlayerController pc;
    public Animator anim;

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("hm", pc.movementVec.x);
        anim.SetFloat("vm", pc.movementVec.y);
    }

    public void InteractionAnimation (bool flag)
    {
        anim.SetTrigger(flag ? "interacting" : "stopInteracting");
    }
}
