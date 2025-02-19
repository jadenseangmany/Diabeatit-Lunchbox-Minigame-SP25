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
    public Text scriptName; //"local" variable you're updating
    public GameObject speechBubble; // Reference to the speech bubble GameObject
    public Text allFoodText; // Reference to the allFood Text component
    private bool hasProteinItem = false;

    

    public bool AddItem(Item item){
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
                scriptName = GameObject.Find("allFood").GetComponent<Text>(); //JOANN EDIT 
                scriptName.text = item.script;

                if (item.type == ItemType.Protein)

                {
                    hasProteinItem = true;
                    EnableSpeechBubbleAndText(true);
                }

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
