using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public void setMaxHealth(int health) //this creates a variable function for health that holds a integer value
    {
        slider.maxValue = health;
        slider.value = health;
    }

    
    public void setHealth(int health) //creates a variable function for setting the health to a certain value
    {
        slider.value = health;
    }

}