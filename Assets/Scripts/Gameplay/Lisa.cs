using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lisa : Hero
{

    protected override void Movement()
    {
        base.Movement();

        anim.SetFloat("move", movementValue);
        if(ImLeader)
        {
            anim.SetBool("Attack", isAttacking);
        }
        
        if(_healthHero <= 0)
        {
            anim.SetBool("Die", true);
            this.GetComponent<InputsController>().enabled = false;
            agent.enabled = false;
            Gamemanager.Instance.CurrentGameMode.ChangeLeader(transform);
        }

        if (IsLookEnemy == true)
        {
            talks.actualTalk = talks.lisaTalks[1];
        }
        else
        {
            talks.actualTalk = talks.lisaTalks[0];
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Ball"))
        {
            _healthHero -= 5.0f;
        }
    }
}
