using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foodSelection : MonoBehaviour
{
    public LunchBoxManager lunchBoxManager; // Changed SlotManager to LunchBoxManager for clarity

    public void OnFoodClicked()
    {
        Item item = GetComponent<Item>(); // Get the item component

        if (item == null)
        {
            Debug.LogWarning("No Item component found on foodSelection object!");
            return;
        }

        // Check if the item is a drink
        if (item.type == ItemType.Drink)
        {
            // Place it in the coaster slot
            bool placed = lunchBoxManager.AddItem(item);
            if (!placed)
            {
                Debug.Log("Failed to place the drink. Coaster may be full!");
            }
        }
        else
        {
            // Place in a normal slot
            bool placed = lunchBoxManager.AddItem(item);
            if (!placed)
            {
                Debug.Log("No available food slots left!");
            }
        }
    }
}