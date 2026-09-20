using UnityEngine;

public class Sword : MonoBehaviour, Interactable
{
    public PlayerInventory playerInventory;
    public Item item;
    

    public void Interact()
    {
        bool itemAdded = playerInventory.Additem(item);

        if (itemAdded)
        {
            Debug.Log("picked up" + item.itemName);
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Inventory Full!");
        }
    }

   
}
