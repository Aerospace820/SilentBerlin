using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIBehavior : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask ground, players;
    
    //partrol
    public Vector3 walkpoint;
    bool walkpointset = false;
    public float walkPointRange;

    //attack
    public float timebetweenatttacks;
    bool alreadyattacked;


    //states
    public float attackrange;
    public bool playerattackrange;

    void Update()
    {
        playerattackrange = Physics.CheckSphere(transform.position, attackrange, players);

        if(!playerattackrange)
        {
            Patrol();
        }

        else if(playerattackrange)
        {
            Attack();
        }
    }

    private void Patrol()
    {
        if(!walkpointset) {
            SearchWalkpoint();}

        if(walkpointset)
        {
            agent.SetDestination(walkpoint);
        }

        Vector3 distancewalk = transform.position - walkpoint;

        if(distancewalk.magnitude < 4f)
        {
            walkpointset = false;
        }

    }

    private void SearchWalkpoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        
        walkpoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if(Physics.Raycast(walkpoint, -transform.up, 2f, ground)){
            walkpointset = true;
        }
    }

    private void Attack()
    {
        agent.SetDestination(player.position);
        transform.LookAt(player);   
        
        if(!alreadyattacked)
        {
            Debug.Log("funne");
            alreadyattacked = true;
            Invoke(nameof(ResetAttack), timebetweenatttacks);
        }

    }

    private void ResetAttack()
    {
        alreadyattacked = false;
    }
}
