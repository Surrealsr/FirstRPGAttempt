using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    public bool playerInRange;// makes bool public so it can used elsewhere

    void OnTriggerEnter(Collider other)// when enetered 
    {
        if (other.CompareTag("Player"))//true if player is detected 
        {
            playerInRange = true;// sets bool to be true
        }
    }
    private void OnTriggerExit(Collider other)// when exited 
    {
        if (other.CompareTag("Player"))//true if player exits
        {
            playerInRange = false;// sets bool to false
        }
    }

}
