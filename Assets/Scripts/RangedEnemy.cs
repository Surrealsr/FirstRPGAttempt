using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
    public Transform playerTarget;
    public Transform firepoint;
    public GameObject projectilePrefab;
    public float attackRange = 15;
    public float fireCooldown = 1f;
    public LayerMask sightLayers;
    private float fireTimer;

    private void Update()
    {
        float distancetoplayer = Vector3.Distance(playerTarget.position, transform.position);
        
        if (fireTimer > 0)
        {
            fireTimer -= Time.deltaTime;
        }
        if (distancetoplayer <= attackRange)
        {
            if (CanSeePlayer())
            {
                LookAtPlayer();

                if(fireTimer <= 0)
                {
                    Shoot();
                    fireTimer = fireCooldown;
                }
            }
        }
    }
    bool CanSeePlayer()
    {
        Vector3 direction = playerTarget.position - firepoint.position;

        float distance = direction.magnitude;

        direction.Normalize();

        Debug.DrawRay(firepoint.position,direction * distance);

        if (Physics.Raycast(firepoint.position,direction, out RaycastHit hit, distance, sightLayers))
        {
            if (hit.transform.CompareTag("Player"))
            {
                return true;
            }
        }
        return false;
    }
    void LookAtPlayer()
    {
        Vector3 direction = playerTarget.position - transform.position;
        direction.y = 0;
        transform.rotation = Quaternion.LookRotation(direction);
    }
    void Shoot()
    {
        Instantiate(projectilePrefab, firepoint.position, firepoint.rotation);
    }
}
