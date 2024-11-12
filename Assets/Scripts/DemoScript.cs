using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoScript : MonoBehaviour
{
    public LunchBoxManager lunchBoxManager;
    public Item[] itemsToPickup;

    public void PickupItem(int id)
    {
        bool result = lunchBoxManager.AddItem(itemsToPickup[id]);
        if (result == true)
        {
            Debug.Log("item added");
        }
        else
        {
            Debug.Log("Item not added");
        }
    }
}
