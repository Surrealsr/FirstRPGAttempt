using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float speed = 15f;// speed of projectile
    public float lifeTime = 5f;//how long the projectile is in the scene before deleting itself
    public int damage = 10; //how much dmg it does 
    PlayerHealth playerhealth; //ref to player script to do the damage

    private void Start()
    {
        Destroy(gameObject, lifeTime);// deletes the proj in 5 seconds according to our float
    }

    private void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;// what actually makes the projectile travel first is direction which is just forward from spawn the its the speed at which it travels then finally this makes it so diffrent framerates dont make it a diffrent speed.
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))// true if hits player
        {
            Debug.Log("Player got Hit!" + damage);//simple log 
            playerhealth.TakeDamage(damage);// deals damage to the player
            Destroy(gameObject);//deletes itself
        }
        else//if misses 
        {
            Destroy(gameObject);//deletes itself
        } 

    }
}
