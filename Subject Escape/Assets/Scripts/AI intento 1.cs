using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIintento1 : MonoBehaviour
{
    // NAVMESH ES UNITY PARA AI MOVEMENT FIND SOLO
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    //PATROL Walking around
    public Vector3 walkPoint;
    bool walkPointSet; //is walk point already set?
    public float walkPointRange; //control walkpoint range

    //Attack system
    public float timeBetweenAttack;
    bool alreadyAttacked;

    //States of ranges
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        //Check if player in sight | attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) Chasing();
        if (playerInSightRange && playerInAttackRange) AttackingPlayer();
    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkpoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distantceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distantceToWalkPoint.magnitude < 1f )
            walkPointSet = false;
    }

    private void SearchWalkpoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        
        if (Physics.Raycast(walkPoint, -transfer.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void Chasing()
    {
        
    }

    private void AttackingPlayer()
    {
        
    }
}
