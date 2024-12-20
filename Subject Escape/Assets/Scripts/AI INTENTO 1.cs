using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIintento1 : MonoBehaviour
{
    public PlayerHealth takeDamageFromShot;
    //Get spawn point of ray
    public Transform firePoint;

    //create can shoot boolean
    public bool canShoot = true;

    //set the shot delay
    public float shotDelayInSeconds = 1;

    public GameObject myself;

    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patrolling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInAttackRange && playerInSightRange) AttackPlayer();
    }

    private void Patrolling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }
    private void SearchWalkPoint()
    {
        //Calculate random point in range
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
        //Make sure enemy doesn't move
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            ///Attack code here
            Invoke(nameof(Fire), shotDelayInSeconds);
            ///End of attack code

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    //delay in shot by AI
    private IEnumerator ShootDelay()
    {
        yield return new WaitForSeconds(shotDelayInSeconds);
        canShoot = true;
    }

    //Destroy bullet after 3 seconds
    private IEnumerator DestroyBulletAfterTime(GameObject bullet, float delay)
    {
        //wait for delay time to pass
        yield return new WaitForSeconds(delay);

        //destroy the bullet object
        Destroy(bullet);
    }

    //Fire bullet function
    private void Fire()
    {

        if (canShoot == true)
        {
            ;
            //create raycast
            RaycastHit hit;

            Vector3 Aim = firePoint.transform.rotation.eulerAngles;

            //se fija si el raycast choca contra algo en 100 units or less (podemo cambiar eso si queremos mas lejos)
            if (Physics.Raycast(firePoint.position, firePoint.forward, out hit, 100))
            {
                //inicializa el "target" aka the object hit by our ray"
                GameObject target = hit.transform.gameObject;
                //checks if target hit is "enemy"
                if (target.tag.Contains("Player"))
                {
                    //Damage player
                    takeDamageFromShot.takeShotDamage();
                }
            }
            //prevent next shot
            canShoot = false;

            //call function to delay next shot
            StartCoroutine(ShootDelay());
        }
    }
}
