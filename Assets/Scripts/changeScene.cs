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
    public static bool hasPlayed = false;
    public void GoToSceneTwo() {
        hasPlayed = true;
        sceneData.TotalPoints = 0;
        sceneData.receiptFood.Clear();
        sceneData.slotPositions.Clear();
        sceneData.foodInSlots.Clear();
        sceneData.drinkInSlot.Clear();
        SceneManager.LoadScene("mainMenu");
    }

        // Transition from main menu to tutorial1 when "Play Game" is clicked
    public void GoToTutorial1() {
        if (!hasPlayed) {
            SceneManager.LoadScene("Tutorial1");
        } else {
            SceneManager.LoadScene("pickBox");
        }
        
    }

    public void LoadTutorial2()
    {
        SceneManager.LoadScene("Tutorial2");
    }

     public void LoadTutorial3()
    {
        SceneManager.LoadScene("Tutorial3");
    }

      public void LoadTutorial4()
    {
        SceneManager.LoadScene("Tutorial4");
    }

      public void LoadTutorial5()
    {
        SceneManager.LoadScene("Tutorial5");
    }
          public void LoadTutorial6()
    {
        SceneManager.LoadScene("Tutorial6");
    }




    public void GoToSelectionMenu() { //unused now
        SceneManager.LoadScene("SelectionMenu");
    }
    
    public void GotoBoxRed() {
        SceneManager.LoadScene("BoxRed");
    }

    public void GotoBoxYellow() {
        SceneManager.LoadScene("BoxYellow");
    }

    public void GotoBoxBlue() {
        SceneManager.LoadScene("BoxBlue");
    }

    public void GotoBoxPurple() {
        SceneManager.LoadScene("BoxPurple");
    }

    public void GotoBoxPink() {
        SceneManager.LoadScene("BoxPink");
    }

    public void GotoFinishBlue() {
        SceneManager.LoadScene("FinishBlue");
    }

    public void GotoFinishRed() {
        SceneManager.LoadScene("FinishRed");
    }

    public void GotoFinishYellow() {
        SceneManager.LoadScene("FinishYellow");
    }

    public void GotoFinishPink() {
        SceneManager.LoadScene("FinishPink");
    }

    public void GotoFinishPurple() {
        SceneManager.LoadScene("FinishPurple");
    }

    public void GoToSceneFour() { // unsused now
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