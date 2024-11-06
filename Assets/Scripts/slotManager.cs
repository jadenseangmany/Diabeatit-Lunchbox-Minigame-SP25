using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class slotManager : MonoBehaviour
{
    public GameObject[] slots;  // Array of slot objects in the lunchbox
    private int currentSlotIndex = 0;  // Tracks the next available slot

    public void AddFoodToSlot(GameObject foodItem)
    {
        if (currentSlotIndex < slots.Length)
        {
            // Move food item to the next available slot
            foodItem.transform.SetParent(slots[currentSlotIndex].transform);
            foodItem.transform.localPosition = Vector3.zero; // Center it within the slot
            
            currentSlotIndex++;  // Update to the next slot
        }
        else
        {
            Debug.Log("Lunchbox is full!");
        }
    }
}
