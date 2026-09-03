using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
    public Transform playerTarget;// refences a collidor located around the chest of the player
    public Transform firepoint;// location where the projectile instantiates
    public GameObject projectilePrefab;// refrence to projectile prefab
    public float attackRange = 15;// range in where the enemy can shoot the player
    public float fireCooldown = 1f;// time inbetween attacks
    public LayerMask sightLayers;//what the raycast can see
    private float fireTimer;//what is used to start the attack cooldown

    private void Update()
    {
        float distancetoplayer = Vector3.Distance(playerTarget.position, transform.position);// calculates distance to player
        
        if (fireTimer > 0)// if the fire timer is anything above 0 reduce its time in seconds
        {
            fireTimer -= Time.deltaTime;
        }
        if (distancetoplayer <= attackRange)// if player is when attackrange do the following
        {
            if (CanSeePlayer())// if the can see player bool is true
            {
                LookAtPlayer();// rotates enemy to look at the player

                if(fireTimer <= 0)// if the cooldown for attacking is not active do the following
                {
                    Shoot();// runs shoot func
                    fireTimer = fireCooldown;//begins attack cooldown
                }
            }
        }
    }
    bool CanSeePlayer()// creates a bool named canseeplayer
    {
        Vector3 direction = playerTarget.position - firepoint.position;//calculates direction to playertarget

        float distance = direction.magnitude;// turns direction into a length so turn our vector into the distance inbetween the player and enemy

        direction.Normalize();//removes the length from direction and makes its length 1, while keeping the same direction.

        Debug.DrawRay(firepoint.position,direction * distance);// makes the raycast show up in unity so you can see it

        if (Physics.Raycast(firepoint.position,direction, out RaycastHit hit, distance, sightLayers))//This is the raycast that effectively attaches the enemy to the player and once the enemy gets LOS
        {
            if (hit.transform.CompareTag("Player"))//if raycast hits the player without hitting anything else
            {
                return true;//makes bool true
            }
        }
        return false;//makes bool false if raycast does not hit player
    }
    void LookAtPlayer()// creates function named lookatplayer
    {
        Vector3 direction = playerTarget.position - transform.position;// gets direction to player
        direction.y = 0;//makes y 0 so enemy doesint look up to down
        transform.rotation = Quaternion.LookRotation(direction); // makes enemy rotate to look at player
    }
    void Shoot()// makes function called Shoot
    {
        Instantiate(projectilePrefab, firepoint.position, firepoint.rotation);// spawns in a projectile first in the "()" is the prefab itself then the spawnpoint, then the last one is rotaion in this scenerio this is important because in the projectile prefab the projectile just travels forward so when spawned it needs to have correct orientation.
    }
}
