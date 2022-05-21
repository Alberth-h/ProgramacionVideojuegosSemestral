using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputsController : MonoBehaviour
{
    GameInputs gameInputs;

    Hero hero;

    void Awake()
    {
        gameInputs = new GameInputs();
    }

    void OnEnable()
    {
        gameInputs.Enable();
    }

    void OnDisable()
    {
        gameInputs.Disable();
    }

    void Start()
    {
        hero = GetComponent<Hero>();
        ChangeJob(hero.GetJobsOptions);
        gameInputs.Gameplay.ChangeJob.performed += _=> ChangeJob(hero.GetJobsOptions);
        gameInputs.Gameplay.ChangeLeader.canceled += _=> PassLeaderToNextone();
    }

    void ChangeJob(JobsOptions job)
    {

        if(hero.CurrentJob)
        {
            Destroy(hero.CurrentJob);
        }
        switch(job)
        {
            case JobsOptions.MAGE:
            hero.CurrentJob = gameObject.AddComponent<Mage>();
            break;
            case JobsOptions.ARCHER:
            hero.CurrentJob = gameObject.AddComponent<Archer>();
            break;
            case JobsOptions.WARRIOR:
            hero.CurrentJob = gameObject.AddComponent<Warrior>();
            break;
        }
    }

    void PassLeaderToNextone()
    {
        Gamemanager.Instance.CurrentGameMode.ChangeLeader(transform);
    }

    public GameInputs GetGameinputs => gameInputs;

    public Vector3 Axis => new Vector3(Direction.x, 0f, Direction.y);

    public Vector2 Direction => gameInputs.Gameplay.Direction.ReadValue<Vector2>();
}
