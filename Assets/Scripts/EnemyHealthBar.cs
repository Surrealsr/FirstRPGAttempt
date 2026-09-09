using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public Slider slider;
    public Transform playerCamera;

    public void Update()
    {
        LookAtPlayer();
    }


    public void setMaxHealth(int health) //this creates a variable function for health that holds a integer value
    {
        slider.maxValue = health;
        slider.value = health;
    }


    public void setHealth(int health) //creates a variable function for setting the health to a certain value
    {
        slider.value = health;
    }
    
    void LookAtPlayer()// creates function named lookatplayer
    {
        Vector3 direction = playerCamera.position - transform.position;// gets direction to player
        direction.y = 0;//makes y 0 so health bar doesint move up or down
        transform.rotation = Quaternion.LookRotation(direction); // makes healthbar rotate to look at player
    }
}
