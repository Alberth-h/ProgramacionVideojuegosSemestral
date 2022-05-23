using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(InputsController))]
public class Hero : Character, IHostile
{
    [SerializeField]
    protected int damage;
    [SerializeField]
    protected JobsOptions jobsOptions;
    [SerializeField]
    CharacterJob currentJob;
    [SerializeField]
    float leaderMinDistance;

    [SerializeField]
    Vector2 minMaxAngle;
    protected float movementValue;
    protected InputsController inputsController;

    [SerializeField]
    private float _rotSpeed = 20f;

    [SerializeField]
    private float _lookEnemyRadius;
    [SerializeField] 
    LayerMask enemyMask;
    private bool _isLookingEnemy = false;

    protected Talks talks;

    new void Awake()
    {
        base.Awake();
        inputsController = GetComponent<InputsController>();
        talks = GetComponent<Talks>();
    }

    IEnumerator Start()
    {
        agent.speed = moveSpeed;
        agent.stoppingDistance = leaderMinDistance;
        while(true)
        {
            if(Gamemanager.Instance.CurrentGameMode)
            {
                agent.enabled = !ImLeader;
                break;
            }
            yield return null;
        }
    }

    protected override void Movement()
    {
        Hero leader = Gamemanager.Instance.CurrentGameMode.GetPartyLeader.GetComponent<Hero>();

        if(ImLeader)
        {
            base.Movement();
            transform.Translate(inputsController.Axis.normalized.magnitude * Vector3.forward * moveSpeed * Time.deltaTime);
            FacingDirection();
            LookEnemy();
            movementValue = leader.IsMoving ? 1 : 0f;

            //Gamemanager.Instance.CurrentGameMode.GetGameUI.Health = health * 100f / maxHealth;
        }
        else
        {
            if(agent.enabled)
            {
                agent.destination = leader.transform.position;
                movementValue = agent.velocity != Vector3.zero ? 1 : 0f;
            }
        }
    }

    protected void LateUpdate()
    {

    }

    public void Attack()
    {

    }

    public int GetDamage()
    {
        return damage;
    }


    //void OnTriggerEnter(Collider other)
    //{
    //    if(other.CompareTag("Enemy"))
    //    {
    //        SceneManager.LoadScene(1);
    //    }
    //}

/// <summary>
/// Checks if you are the leader of the party.
/// </summary>
/// <returns>Returns a true/false depending of the comparing with leader transform.</returns>
    public bool ImLeader => Gamemanager.Instance.CurrentGameMode.CompareToLeader(transform);

    protected void LookEnemy()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, _lookEnemyRadius, enemyMask);
        if (rangeChecks.Length != 0)
        {
            _isLookingEnemy = true;
        }
        else
        {
            _isLookingEnemy = false;
        }
    }

    protected void FacingDirection()
    {
        if(IsMoving)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, RotationDirection, Time.deltaTime * _rotSpeed);
        }
    }

    Quaternion RotationDirection => Quaternion.LookRotation(inputsController.Axis);

    public bool IsMoving => inputsController.Axis != Vector3.zero;
    public bool IsLookEnemy => _isLookingEnemy;

    public CharacterJob CurrentJob{get => currentJob; set => currentJob = value;}
    public JobsOptions GetJobsOptions => jobsOptions;
    public NavMeshAgent GetAgent => agent;

    public InputsController GetInputsController => inputsController;

}