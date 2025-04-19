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
    public Text totalPointsTxt; //update this to display final points
    public Text scriptName; //"local" variable you're updating
    public GameObject speechBubble; // Reference to the speech bubble GameObject
    public Text allFoodText; // Reference to the allFood Text component
    //private bool hasProteinItem = false;


    // add coasterSlot
    public FoodSlot coasterSlot;
    

    //Called in ButtonManager
    /*public bool AddItem(Item item){
        

        //Find any empty slot
        for (int i = 0; i < FoodSlots.Length; i++){
            FoodSlot slot = FoodSlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot == null){
                SpawnNewItem(item, slot); //add item to slot 
                totalPoints += item.points; //add points
                updateTotalPoints(); //update total points visually in THIS scene
                Debug.Log($"Added {item.type} with {item.points} points. Total points: {totalPoints}"); //debug
                sceneData.TotalPoints = totalPoints; // Pass the total points for NEXT scene
                sceneData.foodInSlots.Add(item); // Store the item globally for NEXT scene
                return true;
            }
        }
        return false;
    }
    */

    public bool AddItem(Item item)
    {
        // ADDED CODE HERE
        // If the item is a drink, force it into the coaster slot
        if (item.type == ItemType.Drink)
        {
            InventoryItem itemInCoaster = coasterSlot.GetComponentInChildren<InventoryItem>();
            if (itemInCoaster == null) // Ensure it's empty before placing
            {
                SpawnNewItem(item, coasterSlot);
                sceneData.TotalPoints += item.points; // Pass the total points
                updateTotalPoints(); // Update total points visually
                Debug.Log($"Added {item.type} with {item.points} points. Total points: {sceneData.TotalPoints}");
                Debug.Log($"Item text: {item.Food}");

                // Store data globally for NEXT scene
                sceneData.drinkInSlot.Add(item);
                sceneData.receiptFood.Add(item.Food);

                //Gluccy's script
                scriptName = GameObject.Find("allFood").GetComponent<Text>(); //JOANN EDIT 
                scriptName.text = item.script;

                return true;
            }
            else
            {
                Debug.Log("Coaster is already occupied!");
                return false; // Prevent multiple drinks on the coaster
            }
        }
        // END OF ADDED CODE
        // Find any empty slot
        for (int i = 0; i < FoodSlots.Length; i++)
        {
            FoodSlot slot = FoodSlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot == null)
            {
                // Store slot position
                sceneData.slotPositions.Add(i); // Save the index of the filled slot
                
                SpawnNewItem(item, slot); // Add item to the slot
                sceneData.TotalPoints += item.points; // Add points
                updateTotalPoints(); // Update total points visually in THIS scene

                Debug.Log($"Added {item.type} with {item.points} points. Total points: {sceneData.TotalPoints}");
                Debug.Log($"Item text: {item.Food}");

                // Store data globally for NEXT scene
                sceneData.foodInSlots.Add(item);
                sceneData.receiptFood.Add(item.Food);

                // Gluccy's script
                scriptName = GameObject.Find("allFood").GetComponent<Text>(); //JOANN EDIT 
                scriptName.text = item.script;

                /*if (item.type == ItemType.Protein)

                {
                    hasProteinItem = true;
                    EnableSpeechBubbleAndText(true);
                }*/

                return true;
            }
        }
        return false;
    }

    /*
    void SpawnNewItem(Item item, FoodSlot slot)
    need to drag the slot in the unity interface to use

    Instantiate
    spawns item at slot position

    GetComponent
    gets the spawned items characteristics

    Initialize 
    allocates the spawned items characteristics to the item
    */
    void SpawnNewItem(Item item, FoodSlot slot){
        GameObject newItemGo = Instantiate(inventoryItemPrefab, slot.transform);
        InventoryItem inventoryItem = newItemGo.GetComponent<InventoryItem>();
        inventoryItem.InitializeItem(item);
    }

    public void updateTotalPoints() {
        const int maxPoints = 95;
        int normalizedPoints = Mathf.RoundToInt((sceneData.TotalPoints / (float)maxPoints) * 100);

        if (totalPointsTxt != null) { //update total points
            totalPointsTxt.text = ($"{normalizedPoints}");
            Debug.Log("set text");
        } else {
            Debug.Log("failed to set text");
            totalPointsTxt = GameObject.Find("tmpPoints").GetComponent<Text>(); //find text gameObject if u cannot find it manually
            totalPointsTxt.text = ($"{normalizedPoints}"); //then update total points
        }
    }

    private void EnableSpeechBubbleAndText(bool enable)
    {
        if (speechBubble != null)
        {
            speechBubble.SetActive(enable); // Enable or disable the speech bubble
        }

        if (allFoodText != null)
        {
            allFoodText.gameObject.SetActive(enable);
        }
    }
}
