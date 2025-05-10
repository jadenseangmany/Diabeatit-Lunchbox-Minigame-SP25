using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class delete : MonoBehaviour
{
    public FoodSlot[] FoodSlots;
    public GameObject inventoryItemPrefab;
    public Text totalPointsTxt; //update this to display final points
    public FoodSlot coasterSlot;

    private LunchBoxManager lunchBoxManager; // reference to LunchBoxManager

    void Start()
    {
        lunchBoxManager = FindObjectOfType<LunchBoxManager>(); // find LunchBoxManager in the scene
    }

    public void RemoveItem(int num)
    {
        FoodSlot slot = FoodSlots[num];
        InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
        if (itemInSlot != null)
        {
            sceneData.foodInSlots.Remove(itemInSlot.item);
            sceneData.receiptFood.Remove(itemInSlot.item.Food);
            sceneData.slotPositions.Remove(num);
            Destroy(itemInSlot.gameObject);
            lunchBoxManager.updateTotalPoints(); // call update from LunchBoxManager
            Debug.Log($"Remove Item: Deleted {itemInSlot.item.type} with {itemInSlot.item.points} points. Total points: {sceneData.TotalPoints}");
        }
    }

    public void RemoveDrink()
    {
        InventoryItem itemInSlot = coasterSlot.GetComponentInChildren<InventoryItem>();
        if (itemInSlot != null)
        {
            sceneData.drinkInSlot.Remove(itemInSlot.item);
            sceneData.receiptFood.Remove(itemInSlot.item.Food);
            Destroy(itemInSlot.gameObject);
            lunchBoxManager.updateTotalPoints(); // call update from LunchBoxManager
            Debug.Log($"Remove Drink: Deleted {itemInSlot.item.type} with {itemInSlot.item.points} points. Total points: {sceneData.TotalPoints}");
        }
    }
}