using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBrain : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, WhatIsPlayer;
    public GameObject EnnemyProjectile;
    //patrolling // 
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking//
    public float timeBetweenAttack;
    bool alreadyAttacked;

    //States 
    public float sighRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {
        player = GameObject.Find("ThirdPersonPlayer").transform;
        agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        //check for sight & attack range 
        playerInSightRange = Physics.CheckSphere(transform.position, sighRange, WhatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, WhatIsPlayer);

       /* if (!playerInSightRange && !playerInAttackRange)
        {
            Patroling();
            Debug.Log("ennemyPatrol");
        }
        if (playerInSightRange && !playerInAttackRange)
        {
            ChasePlayer();
            Debug.Log("ennemyChase");
        }*/
        if (playerInAttackRange && playerInAttackRange)
        {
            AttackPlayer();
            Debug.Log("ennemyattack");
        }

    }
    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();
        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached // 
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;

    }
    private void SearchWalkPoint()
    {
        //calculate random // 
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true; 
    }
    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }
    private void AttackPlayer()
    {
        //Ennemy doesn't moves// 
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if(!alreadyAttacked)
        {
            //AttackCode IA // 
            Rigidbody rb = Instantiate(EnnemyProjectile,transform.position,Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 32f, ForceMode.Impulse); // video : https://www.youtube.com/watch?v=UjkSFoLxesw&t=172s à 4:15 // 
            rb.AddForce(transform.up * 32f, ForceMode.Impulse);
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttack);
        }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
}
