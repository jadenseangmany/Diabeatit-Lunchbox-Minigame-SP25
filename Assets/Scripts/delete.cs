using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class delete : MonoBehaviour
{
    public  FoodSlot[] FoodSlots;
    public GameObject inventoryItemPrefab;
    public Text totalPointsTxt; //update this to display final points


   public void RemoveItem(int num) {
        FoodSlot slot = FoodSlots[num];
        InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
        if (itemInSlot != null) {
            sceneData.TotalPoints -= itemInSlot.item.points;
            updateTotalPoints();
            Debug.Log($"Deleted {itemInSlot.item.type} with {itemInSlot.item.points} points. Total points: {sceneData.TotalPoints}");
            sceneData.foodInSlots.Remove(itemInSlot.item);
            sceneData.receiptFood.Remove(itemInSlot.item.Food);
            sceneData.slotPositions.Remove(num);
            Destroy(itemInSlot.gameObject);
        }
    }

    public void updateTotalPoints() {
        if (totalPointsTxt != null) { //update total points
            totalPointsTxt.text = ($"{sceneData.TotalPoints}");
            Debug.Log("set text");
        } else {
            Debug.Log("failed to set text");
            totalPointsTxt = GameObject.Find("tmpPoints").GetComponent<Text>(); //find text gameObject if u cannot find it manually
            totalPointsTxt.text = ($"{sceneData.TotalPoints}"); //then update total points
        }
    }

}