using System.ComponentModel;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public Item[] inventory = new Item[5];// creats the inventory for our player
    
    public bool Additem(Item item) //making it a bool instead of a "void" is important here because after interacting we want to answer if an item got added or if not we do that by making this function a bool 
    {
        for (int i = 0; i < inventory.Length; i++)// this is a "for" loop what this does is checks every slot in the array for example it checks slot 0 if there is already something there it moves on to slot 1 and keeps doing that its a loop by it being a "for" loop it does it in 1 interaction instead of multiple 
        {
            if (inventory[i] == null)// if there is nothing in the slot do the following 
            {
                inventory[i] = item;// add whatever item we interacted with into that "null" slot 

                return true;// return the bool as true 
            }
        }
        return false;// return false if all slots are full.
    }
}
