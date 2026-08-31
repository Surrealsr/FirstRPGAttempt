using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    //health publics
   public int maxHealth = 100;
   public int currentHealth;
    
    //stamina publics, floats and not ints because stamina drain works smoother with floats
    public float maxStamina = 100;
    public float currentStamina;
    public float staminaDrain = 20f;
    public float staminaRegen = 15f;
    public int jumpDrain = 15;

     HealthBar healthBar;
     StaminaBar staminaBar;


   public void Start()
    {
        healthBar = FindAnyObjectByType<HealthBar>();
        staminaBar = FindAnyObjectByType<StaminaBar>();


        currentHealth = maxHealth;//sets current health to max
        healthBar.setMaxHealth(maxHealth);

        currentStamina = maxStamina;//sets current stamina to max
        staminaBar.setMaxStamina(maxStamina);
    }

    public void Update()
    {

        healthBar.setHealth(currentHealth);

        if (currentStamina < 0) currentStamina = 0;//both these lines are just so Stamina can't get negative value from drain, and it can't go beyond max value because of regen.
        if (currentStamina > 100) currentStamina = 100;

    }

    public void drainStamina()//custom function for draining stamina
    {
        currentStamina -= staminaDrain * Time.deltaTime;
        staminaBar.setStamina(currentStamina);
    }

    public void regenStamina()//same thing but for regen
    {
        if(currentStamina < maxStamina)
        {
            currentStamina += staminaRegen * Time.deltaTime;
            staminaBar.setStamina(currentStamina);
        }

    }
    public void staminaJumpDrain()//separate drain for jump
    {
        currentStamina -= jumpDrain;
        staminaBar.setStamina(currentStamina);
    }

}
