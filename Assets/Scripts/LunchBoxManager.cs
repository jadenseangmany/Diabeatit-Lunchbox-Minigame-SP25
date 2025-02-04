using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LunchBoxManager : MonoBehaviour
{
    public  FoodSlot[] FoodSlots;
    public GameObject inventoryItemPrefab;
    public static int totalPoints = 0; //keep track of points
    public Text totalPointsTxt; //update this to display final points

    // add coasterSlot
    public FoodSlot coasterSlot;
    

    public bool AddItem(Item item){
        // ADDED CODE HERE
        // If the item is a drink, force it into the coaster slot
        if (item.type == ItemType.Drink)
        {
            InventoryItem itemInCoaster = coasterSlot.GetComponentInChildren<InventoryItem>();
            if (itemInCoaster == null) // Ensure it's empty before placing
            {
                SpawnNewItem(item, coasterSlot);
                totalPoints += item.points; // Add points
                updateTotalPoints(); // Update total points visually
                Debug.Log($"Added {item.type} with {item.points} points to the coaster. Total points: {totalPoints}");
                sceneData.TotalPoints = totalPoints; // Pass the total points
                sceneData.foodInSlots.Add(item);
                return true;
            }
            else
            {
                Debug.Log("Coaster is already occupied!");
                return false; // Prevent multiple drinks on the coaster
            }
        }
        // END OF ADDED CODE

        //Find any empty slot
        for (int i = 0; i < FoodSlots.Length; i++){
            FoodSlot slot = FoodSlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot == null){
                SpawnNewItem(item, slot);
                totalPoints += item.points; //add points
                updateTotalPoints(); //update total points visually
                Debug.Log($"Added {item.type} with {item.points} points. Total points: {totalPoints}");
                sceneData.TotalPoints = totalPoints; // Pass the total points
                sceneData.foodInSlots.Add(item);
                return true;
            }
        }
        return false;
    }

    void SpawnNewItem(Item item, FoodSlot slot){
        GameObject newItemGo = Instantiate(inventoryItemPrefab, slot.transform);
        InventoryItem inventoryItem = newItemGo.GetComponent<InventoryItem>();
        inventoryItem.InitializeItem(item);
    }

    public void updateTotalPoints() {
        if (totalPointsTxt != null) { //update total points
            totalPointsTxt.text = ($"{totalPoints}");
            Debug.Log("set text");
        } else {
            Debug.Log("failed to set text");
            totalPointsTxt = GameObject.Find("tmpPoints").GetComponent<Text>(); //find text gameObject if u cannot find it manually
            totalPointsTxt.text = ($"{totalPoints}"); //then update total points
        }
    }


}
