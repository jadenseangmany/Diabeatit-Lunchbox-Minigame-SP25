using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class LunchBoxDisplay : MonoBehaviour
{
    public FoodSlot coasterSlot;
    public FoodSlot[] FoodSlots;  // Array of the FoodSlots in finalScene
    public GameObject inventoryItemPrefab; // Prefab for InventoryItem
    public Text food1, food2, food3, food4, food5, food6; //declare foods
    public Text finalPointsText; // Reference to the final score text UI element

    void Start() { LoadDrink(); LoadItemsFromSceneData(); ApplyFinalScoreWithBonus(); }

    private LunchBoxManager lunchBoxManager;

    void LoadDrink()
    {
        //make sure there is a item in the slot
        if (sceneData.drinkInSlot.Count == 1)
            SpawnDrinkInSlot(sceneData.drinkInSlot[0], coasterSlot);
    }

    void LoadItemsFromSceneData()
    {
        // Make sure the number of items matches the number of slots
        if (sceneData.foodInSlots.Count == sceneData.slotPositions.Count)
        {
            for (int i = 0; i < sceneData.foodInSlots.Count; i++)
            {
                // Get the index of the slot where the item was placed
                int slotIndex = sceneData.slotPositions[i];
                // Ensure the slot exists and the index is valid
                if (slotIndex >= 0 && slotIndex < FoodSlots.Length)
                {
                    FoodSlot slot = FoodSlots[slotIndex]; // Get the corresponding slot
                    // Instantiate and place the item in the slot
                    SpawnItemInSlot(sceneData.foodInSlots[i], slot);
                }
            }

            //print in receipt
            if (sceneData.foodInSlots.Count == sceneData.slotPositions.Count)
            {
                List<Item> receiptItems = new List<Item>();
                receiptItems.AddRange(sceneData.foodInSlots);
                receiptItems.AddRange(sceneData.drinkInSlot); // add drink if any

                for (int i = 0; i < sceneData.receiptFood.Count; i++)
                {
                    string foodObjectName = $"food{i + 1}_txt"; //dynamically build food1_txt, food2_txt, etc.
                    Text foodText = GameObject.Find(foodObjectName)?.GetComponent<Text>(); //find text gameObject if u cannot find it manually
                    if (foodText == null) { Debug.LogError($"{foodObjectName} not found in scene!"); continue; }

                    string foodName = sceneData.receiptFood[i];
                    Item currentItem = receiptItems.Find(item => foodName.StartsWith(item.Food));
                    bool isPenalized = false;

                    if (currentItem != null && currentItem.type != ItemType.Drink)
                    {
                        for (int j = 0; j < i; j++)
                        {
                            string prevFoodName = sceneData.receiptFood[j];
                            Item previousItem = receiptItems.Find(item => prevFoodName.StartsWith(item.Food));
                            if (previousItem != null && previousItem.type == currentItem.type)
                            {
                                isPenalized = true;
                                break;
                            }
                        }
                    }

                    if (isPenalized)
                    {
                        foodText.text = foodName + " (penalized)";
                        foodText.color = Color.red;
                    }
                    else
                    {
                        foodText.text = foodName;
                        foodText.color = Color.black;
                    }
                }
            }
        }
        else
        {
            Debug.LogError($"Mismatch between number of items and slot positions! foodInSlots.Count: {sceneData.foodInSlots.Count}, slotPositions.Count: {sceneData.slotPositions.Count}");
        }
    }

    void ApplyFinalScoreWithBonus()
    {

        int bonus = CalculateBonusPairingPoints();
        int finalTotal = sceneData.TotalPoints + bonus;

        if (totalPointsTxt != null)
            totalPointsTxt.text = finalTotal.ToString();
        else
            Debug.LogWarning("finalPointsText is not assigned in inspector!");

        Debug.Log($"Base: {sceneData.TotalPoints}, Bonus: {bonus}, Final: {finalTotal}");
    }

    /* 
    This is a function created to implement bonus points for lunch boxes with strategic food pairings.
    This is done to encourage combining foods with complementary nutrients.
    */
    int CalculateBonusPairingPoints()
    {
        int bonus = 0;
        List<string> selected = sceneData.receiptFood;

        for (int i = 0; i < selected.Count; i++)
        {
            for (int j = i + 1; j < selected.Count; j++)
            {
                string a = selected[i];
                string b = selected[j];

                if ((a.StartsWith("Steak") && b.StartsWith("Bell Pepper")) || (a.StartsWith("Bell Pepper") && b.StartsWith("Steak")))
                    bonus += 3;
                else if ((a.StartsWith("Tofu") && b.StartsWith("Orange")) || (a.StartsWith("Orange") && b.StartsWith("Tofu")))
                    bonus += 3;
                else if ((a.StartsWith("Avocado") && b.StartsWith("Carrots")) || (a.StartsWith("Carrots") && b.StartsWith("Avocado")))
                    bonus += 3;
                else if ((a.StartsWith("Cheese") && b.StartsWith("Whole Grain Bread")) || (a.StartsWith("Whole Grain Bread") && b.StartsWith("Cheese")))
                    bonus += 3;
                else if ((a.StartsWith("Eggs") && b.StartsWith("Quinoa")) || (a.StartsWith("Quinoa") && b.StartsWith("Eggs")))
                    bonus += 3;
                else if ((a.StartsWith("Yogurt") && b.StartsWith("Banana")) || (a.StartsWith("Banana") && b.StartsWith("Yogurt")))
                    bonus += 3;
                else if ((a.StartsWith("Banana") && b.StartsWith("Water")) || (a.StartsWith("Water") && b.StartsWith("Banana")))
                    bonus += 3;
                else if ((a.StartsWith("Fish") && b.StartsWith("Grapes")) || (a.StartsWith("Grapes") && b.StartsWith("Fish")))
                    bonus += 3;
            }
        }

        return bonus;
    }

    void SpawnItemInSlot(Item item, FoodSlot slot)
    {
        GameObject newItemGo = Instantiate(inventoryItemPrefab, slot.transform);
        InventoryItem inventoryItem = newItemGo.GetComponent<InventoryItem>();
        inventoryItem.InitializeItem(item); // Initialize the item in the slot
        newItemGo.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
    }

    void SpawnDrinkInSlot(Item item, FoodSlot slot)
    {
        GameObject newItemGo = Instantiate(inventoryItemPrefab, slot.transform);
        InventoryItem inventoryItem = newItemGo.GetComponent<InventoryItem>();
        inventoryItem.InitializeItem(item); // Initialize the item in the slot
        newItemGo.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
    }
}
