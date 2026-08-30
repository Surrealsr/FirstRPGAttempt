using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int playerMaxHealth = 100;
    [SerializeField] private int currentPlayerHealth;
    
    void Start()
    {
        currentPlayerHealth = playerMaxHealth;
    }
    public void TakeDamage(int damage)
    {
        currentPlayerHealth -= damage;

        

        if (currentPlayerHealth <= 0)
        {
            currentPlayerHealth = 0;
            Die();
        }
        Debug.Log("Player HP:" + currentPlayerHealth);
    }
    void Die()
    {
        Destroy(gameObject);
    }
}
