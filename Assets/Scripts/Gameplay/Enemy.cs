using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    GameObject[] targets;
    Transform target;
    [SerializeField] 
    LayerMask heroMask;
    private int targetSelected;

    [SerializeField]
    float timeBetweenAttacks;
    [SerializeField]
    GameObject projectile;
    private bool alreadyAttacked;

    [SerializeField]
    float sightRange, attackRange;
    bool playerInSightRange, playerInAttackRange;

    [SerializeField]
    GameObject deadBody;

    private int _indexHeroSelected;

    private bool _enemyTurn;
    private float _turnTimer = 0.0f;

    [SerializeField]
    private float health = 20.0f;

    [SerializeField]
    Hero[] heros;

    [SerializeField]
    Hero[] heros1;

    [SerializeField]
    Hero[] heros2;

    void Awake()
    {

    }


    void Update()
    {   
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName == "battle")
        {
            if (!_enemyTurn)
            {
                SelectTarget();
            }
            playerInSightRange = Physics.CheckSphere(transform.position, sightRange, heroMask);
            playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, heroMask);
            if (playerInAttackRange && playerInSightRange && _enemyTurn) AttackPlayer();
        }

        TurnTimer();
    }

    private void AttackPlayer()
    {
        transform.LookAt(target);

        if (!alreadyAttacked)
        {
            Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 20f, ForceMode.Impulse);
            rb.AddForce(transform.up * 4f, ForceMode.Impulse);

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0) Invoke(nameof(DeathEnemy), 0.5f);
    }

    private void DeathEnemy()
    {
        Instantiate(deadBody, transform.position, Quaternion.Euler(new Vector3(0, 209, 0)));
        Destroy(gameObject);
    }


    void OnTriggerEnter(Collider other)
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if(other.CompareTag("Hero"))
        {
            if (sceneName == "rpgScene")
            {
                SceneManager.LoadScene(1);
            }

            if (sceneName == "battle" && heros[0].IsAttack)
            {
                TakeDamage(5);
            }
            if (sceneName == "battle" && heros1[0].IsAttack)
            {
                TakeDamage(5);
            }
            if (sceneName == "battle" && heros2[0].IsAttack)
            {
                TakeDamage(5);
            }
        }
    }

    void SelectTarget()
    {
        targets = GameObject.FindGameObjectsWithTag("Hero");

        heros = targets[0].GetComponents<Hero>();
        heros1 = targets[1].GetComponents<Hero>();
        heros2 = targets[2].GetComponents<Hero>();
        
        targetSelected = Random.Range(0, targets.Length - 1);
        target = targets[targetSelected].transform;
    }

    void TurnTimer()
    {        
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (sceneName == "battle")
        {
            _turnTimer += Time.deltaTime;
            if(_turnTimer < 15.0f)
            {
                _enemyTurn = false;
            }
            if(_turnTimer > 15.0f)
            {
                _enemyTurn = true;
            }
            if (_turnTimer > 30.0f)
            {
                _turnTimer = 0.0f;
            }
        }
    }
}
