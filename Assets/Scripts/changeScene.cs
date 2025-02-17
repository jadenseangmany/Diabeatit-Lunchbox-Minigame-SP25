using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class changeScene : MonoBehaviour
{
    public FoodSlot[] FoodSlotsFinal; //food slots to update finishScene
    public GameObject inventoryItemPrefab;
    public Text totalPointsTxt;
    public void GoToSceneTwo() {
        sceneData.TotalPoints = 0;
        sceneData.receiptFood.Clear();
        sceneData.slotPositions.Clear();
        sceneData.foodInSlots.Clear();
        SceneManager.LoadScene("mainMenu");
    }

    public void GoToSelectionMenu() {
        SceneManager.LoadScene("SelectionMenu");
    }

    public void GoToSceneFour() {
        SceneManager.LoadScene("finishScene");
        SceneManager.sceneLoaded += OnSceneLoaded; //check scene is loaded
    }

    public void GoToPickBox()
    {
        SceneManager.LoadScene("pickBox");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
    if (scene.name == "finishScene") {
        totalPointsTxt = GameObject.Find("finalPoints").GetComponent<Text>();
        displayTotalPoints();
        displayFinalFoods();
        SceneManager.sceneLoaded -= OnSceneLoaded; // Unsubscribe after handling
    }
}
    
    //NOTE: EVERY METHOD BELOW IS FOR finishScene
    public void displayTotalPoints() { //show final points in finishScene
        if (totalPointsTxt != null) {
            totalPointsTxt.text = ($"{sceneData.TotalPoints}");
            Debug.Log("FINAL POINTS SUCCESS!");
        } else {
            Debug.Log("finalPoints is not assigned in the Inspector");
        }
    }

    public void displayFinalFoods() { //show all foods chosen
        foreach(var item in sceneData.foodInSlots ) {
            AddItem(item);
            Debug.Log("added items"); //check if loop was run
        }
    }

    public bool AddItem(Item item){ //same as lunchBoxManager
        //Find any empty slot
        for (int i = 0; i < FoodSlotsFinal.Length; i++){
            FoodSlot slot = FoodSlotsFinal[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot == null){
                SpawnNewItem(item, slot);
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

}