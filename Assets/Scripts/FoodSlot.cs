using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FoodSlot : MonoBehaviour
{
    private Item storedItem; // ScriptableObject storing the food's image & data
    private Image foodImage; // UI Image to display the food

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


    //Old code
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            InventoryItem draggableItem = eventData.pointerDrag.GetComponent<InventoryItem>();
            draggableItem.parentAfterDrag = transform;

        }

    }
}
