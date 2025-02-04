using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FoodSlot : MonoBehaviour, IDropHandler
{
    public bool isCoaster = false; // Mark this slot as a coaster if true

    public void OnDrop(PointerEventData eventData)
    {
        // Regular logic here
        InventoryItem draggableItem = eventData.pointerDrag.GetComponent<InventoryItem>();

        // If this slot is a coaster, only allow drinks
        if (isCoaster)
        {
            if (draggableItem.item.type == ItemType.Drink)
            {
                if (transform.childCount == 0) // Ensure it's empty
                {
                    draggableItem.parentAfterDrag = transform;
                }
                else
                {
                    Debug.Log("Coaster already has a drink!");
                }
            }
            else
            {
                Debug.Log("Only drinks can go on the coaster!");
            }
        }
        else
        {
            // Prevent drinks from being placed in non-coaster slots
            if (draggableItem.item.type == ItemType.Drink)
            {
                Debug.Log("Drinks can only be placed on the coaster!");
            }
            else if (transform.childCount == 0) // Normal item placement
            {
                draggableItem.parentAfterDrag = transform;
            }
        }
    }
}