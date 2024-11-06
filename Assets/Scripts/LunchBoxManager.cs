using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LunchBoxManager : MonoBehaviour
{
    public FoodSlot[] FoodSlots;
    public GameObject inventoryItemPrefab;

    public void AddItem(Item item){
        //Find any empty slot
        for (int i = 0; i < FoodSlots.Length; i++){
            FoodSlot slot = FoodSlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot == null){
                SpawnNewItem(item, slot);
                return;
            }
        }
    }

    void SpawnNewItem(Item item, FoodSlot slot){
        GameObject newItemGo = Instantiate(inventoryItemPrefab, slot.transform);
        InventoryItem inventoryItem = newItemGo.GetComponent<InventoryItem>();
        inventoryItem.InitializeItem(item);
    }
}
