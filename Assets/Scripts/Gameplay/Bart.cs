using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bart : Hero
{
    protected override void Movement()
    {
        base.Movement();
        anim.SetFloat("move", movementValue);

        if (IsLookEnemy == true)
        {
            talks.actualTalk = talks.bartTalks[1];
        }
        else
        {
            talks.actualTalk = talks.bartTalks[0];
        }
    }

}
