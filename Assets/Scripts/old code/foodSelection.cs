using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foodSelection : MonoBehaviour
{
    public slotManager SlotManager;  // Reference to the SlotManager

    public void OnFoodClicked()
    {
        // Check if there is an available slot and add the food item to it
        if (SlotManager != null)
        {
            SlotManager.AddFoodToSlot(gameObject);
        }
        else
        {
            Debug.LogWarning("SlotManager reference is not set in FoodSelection script.");
        }
    }
}
