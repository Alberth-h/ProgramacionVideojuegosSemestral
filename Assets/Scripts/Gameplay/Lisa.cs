using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lisa : Hero
{

    protected override void Movement()
    {
        base.Movement();

        anim.SetFloat("move", movementValue);

        if (IsLookEnemy == true)
        {
            talks.actualTalk = talks.lisaTalks[1];
        }
        else
        {
            talks.actualTalk = talks.lisaTalks[0];
        }
    }
}
