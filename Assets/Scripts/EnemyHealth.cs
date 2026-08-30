using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;// sets max hp to 100
    [SerializeField]private int currentHealth; // this is the variable in which the current hp of the enemy is displayed 
    
    void Start()
    {
        currentHealth = maxHealth;// sets the current hp of the enemy to the max only does this once when the game is started or when the enemy spawns
    }
    public void TakeDamage(int damage)// this one aint to bad once you know what parameters are basically whenever this take damage is used you HAVE to put an int into the "()" whatever number you put in becomes a variable named damage which is used in the next line
    {
        currentHealth -= damage;// subtracts whatever damage the player did to the current health of the enemy 

        Debug.Log("Enemy HP:" + currentHealth);// displays current health of enemy in consle right after they take damage 

        if (currentHealth <= 0)// this condition is only met when enemys health is at or below 0
        {
            currentHealth = 0;// this is a redundancy line its technically not neccesary because lets say the enemy is at 10 hp and the player does 25 dmg now the enemys hp is -15 so we just make it zero if it ever goes below 0
            Die();// runs the die function call 
        }

    }
    void Die()// creats a function called die 
    {
        Destroy(gameObject);// deletes the player gameobject 
    }
 
}
