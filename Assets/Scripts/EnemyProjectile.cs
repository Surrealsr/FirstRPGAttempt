using System.Xml.Serialization;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float speed = 15f;
    public float lifeTime = 5f;
    public int damage = 10;
    PlayerHealth playerhealth; 

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    private void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Projectile hit: " + other.gameObject.name);

        if (other.CompareTag("Player"))
        {
            Debug.Log("Player got Hit!" + damage);
            Destroy(gameObject);
            playerhealth.TakeDamage(damage);
        }
        else
        {
            Destroy(gameObject);
        } 

    }
}
