using UnityEngine;

public class Chest : MonoBehaviour, Interactable

{
    public Animator chestAnimator;


    public void Start()
    {
        chestAnimator.GetBool("isChestOpen");//These two lines just ensure the chest is closed at the start of game
        chestAnimator.SetBool("isChestOpen", false);

    }





    public void Interact()
    {
        if (chestAnimator.GetBool("isChestOpen") == false)//Checks for the custom bool made in the Animator Tool is set to false, if so
        {
            chestAnimator.SetBool("isChestOpen", true);//Sets the bool to true, which executes animation for opening chest
            Debug.Log("Chest Opened");
        }
        else
        {
            chestAnimator.SetBool("isChestOpen", false);//Otherwise, it will set bool to false which will execute animation for closing chest
            Debug.Log("Chest Closed");
        }
        
    }

}