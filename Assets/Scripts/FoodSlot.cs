using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FoodSlot : MonoBehaviour
{
    private Item storedItem; // ScriptableObject storing the food's image & data
    private Image foodImage; // UI Image to display the food
    public bool isCoaster = false; // Mark this slot as a coaster if true

    void Awake()
    {
        foodImage = GetComponentInChildren<Image>();
        foodImage.enabled = false; // Hide it by default
    }

    // Set the food item in this slot (called when a food is added)
    public void SetItem(Item item)
    {
        if (item != null)
        {
            storedItem = item;
            foodImage.sprite = item.image; // Assign sprite from the ScriptableObject
            foodImage.enabled = true; // Make the image visible
        }
    }

    // Get the item stored in this slot (optional, useful for further logic)
    public Item GetItem()
    {
        return storedItem;
    }


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