using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FoodSlot : MonoBehaviour, IDropHandler
{

    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            InventoryItem draggableItem = eventData.pointerDrag.GetComponent<InventoryItem>();
            draggableItem.parentAfterDrag = transform;

        }

    }
}
