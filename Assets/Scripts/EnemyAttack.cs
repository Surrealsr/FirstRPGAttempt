using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public Transform player;// player refernce 
    public float attacktRange = 2f;// how far the enemy needs to be to attack
    public int damage = 20; // the base damage of the enemy
    public float attackCooldown = 1f; //time inbetween attacks
    private float attacktimer;// what actually starts the timer
    private PlayerHealth playerHealth;// refrence to the players health 
    private Enemy enemyPatrol;// refrence to the base enemey script

    private void Start()
    {
        playerHealth = player.GetComponent<PlayerHealth>();// automaticlly gets the players health script on start

    }
    private void Update()
    {


        if (player == null)// this says if the player transform does not exist patrol the area
        {
            enemyPatrol.Patrol();
        }

        if (attacktimer > 0)// if the time on the attacktimer is greater than zero subtract from it
        {
            attacktimer -= Time.deltaTime;
        }

        float distanceFromPlayer = Vector3.Distance(transform.position, player.position);// gets the players position and the enemy position and converst that into a distance vector located in the "distancefromplayer" variable 
        
        if (distanceFromPlayer <= attacktRange && attacktimer <= 0)// this says if the distance from the player is less than the attack distance and the attack timer is less than or 0 run the attack command
        {
           Attack();
        }

    }
    void Attack()// creates a command named Attack
    {
        playerHealth.TakeDamage(damage);//runs the Takedamage in the player health script 
        attacktimer = attackCooldown;// starts the attack cooldown again 
        Debug.Log("Enemy Attacked the player!");// lets us know via the console if the enemy has attacked the player 
    }
}
