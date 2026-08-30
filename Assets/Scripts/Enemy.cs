using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform playerTransform; //Player Reference 
    public Transform[] patrolPoints; // These are the locations the AI will move to when the player is not within detection range the "[]" after transform makes it a list of Transforms or an "array"
    private float detectionRange = 10f; //Radious around the enemy in which it can detect the player
    public float waitTime = 2f;//the amount a time the enemy stays at each patrol point
    private float waitimer = 0;// second variable needed to make timer work/start
    private NavMeshAgent agent;// refrence for NavMeshAgent aka the actual brains of the AI 
    private int currentPatrolPoint = 0;// makes a variable for which patrol point the enemy is at

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>(); //gets the nav mesh agent from the enemies compnents could just drag and drop it but this also works 
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
    public void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);//calculates distance from enemy to player in a vector 3 then it puts it into the float variable "distanceToPlayer"

        if (distanceToPlayer <= detectionRange)// if the distance to the player is less than or equal to the detection range of the enemy it will run the chasePlayer func.
        {
            ChasePlayer();
        }
        else //if it does not have player in its detection range it runs the Patrol func.
        {
            Patrol();
        }
        void ChasePlayer()// makes a func named ChasePlayer that only runs when that previous "if" statement is met.
        {
            agent.SetDestination(playerTransform.position);// just says to set the position of the ai to the player
            waitimer = 0;// we set the wait timer to this because lets say the enemy was at like 1.8 seconds into his wait timer when he started the chase, after the chase if we dont reset the timer he will only wait at his patrol point for 0.2 seconds thats why we set it to 0 at start of chase 
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
            currentPatrolPoint = 0; 
        }
    }









}
