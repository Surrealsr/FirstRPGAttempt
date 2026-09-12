
using UnityEngine;
using UnityEngine.AI;

public class RangedEnemyMovement : MonoBehaviour
{
    public NavMeshAgent agent;
    public float waitTime = 2f;
    private float waitimer = 0;
    private int currentPatrolPoint = 0;
    public Transform[] patrolPoints;
    public RangedEnemy rangedEnemyScript;
    public PlayerDetection playerDetection;
   

    private void Update()
    {
        if (!rangedEnemyScript.sawPlayer)
        {
            Patrol();
        }
        else if (playerDetection.playerInRange)
        {
            agent.SetDestination(rangedEnemyScript.playerTarget.position);
        }
        
    }
    private void Start()
    {
        
        GoToNextPatrolPoint();// begins the patrol sequence
    }
    public void Patrol()//what the enemy does when not chasing player 
    {
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)// if the ai is not currently pathing to a player and has reached his destination(patrol point) do the following
        {
            waitimer += Time.deltaTime;// so this starts the timer that counts up 

            if (waitimer >= waitTime) // if the wait time has reached 2 seconds do the following 
            {
                GoToNextPatrolPoint();
                waitimer = 0;// we reset the timer for the next patrol point 
            }
        }
    }
    void GoToNextPatrolPoint()
    {
        if (patrolPoints.Length == 0)// .Length tells you how many things are inside an array. so if you have 10 patrol points then "patrolPoints.Length" is equal to 10 so this if is only true if there are no patrol points. 
        {
            return;
        }
        agent.SetDestination(patrolPoints[currentPatrolPoint].position);// tells the ai to move to the next point
        currentPatrolPoint++;// makes the ais current control point its current but +1 

        if (currentPatrolPoint >= patrolPoints.Length)//all this is resetting the patrol points once you have gone past the lenth of the array 
        {
            currentPatrolPoint = 0; // resets back to first patrol point
        }
    }
}
