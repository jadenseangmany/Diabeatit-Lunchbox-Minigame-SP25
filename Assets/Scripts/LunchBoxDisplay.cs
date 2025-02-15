using UnityEngine;
using UnityEngine.UI;

public class LunchBoxDisplay : MonoBehaviour
{
    public FoodSlot[] FoodSlots;  // Array of the FoodSlots in finalScene
    public GameObject inventoryItemPrefab; // Prefab for InventoryItem
    public Text food1, food2, food3, food4, food5, food6; //declare foods

    void Start()
    {
        LoadItemsFromSceneData();
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

            if (sceneData.foodInSlots.Count >= 1) {
                food1 = GameObject.Find("food1_txt").GetComponent<Text>(); //find text gameObject if u cannot find it manually
                if (food1 == null) Debug.LogError("food1_txt not found in scene!");
                food1.text = (sceneData.receiptFood[0]); //then update total points
            }
            if (sceneData.foodInSlots.Count >= 2) {
                food2 = GameObject.Find("food2_txt").GetComponent<Text>(); //find text gameObject if u cannot find it manually
                food2.text = (sceneData.receiptFood[1]); //then update total points
            }
            if (sceneData.foodInSlots.Count >= 3) {
                food3 = GameObject.Find("food3_txt").GetComponent<Text>(); //find text gameObject if u cannot find it manually
                food3.text = (sceneData.receiptFood[2]); //then update total points
            }
            if (sceneData.foodInSlots.Count >= 4) {
                food4 = GameObject.Find("food4_txt").GetComponent<Text>(); //find text gameObject if u cannot find it manually
                food4.text = (sceneData.receiptFood[3]); //then update total points
            }
            if (sceneData.foodInSlots.Count >= 5) {
                food5 = GameObject.Find("food5_txt").GetComponent<Text>(); //find text gameObject if u cannot find it manually
                food5.text = (sceneData.receiptFood[4]); //then update total points
            }
            if (sceneData.foodInSlots.Count >= 6) {
                food5 = GameObject.Find("food6_txt").GetComponent<Text>(); //find text gameObject if u cannot find it manually
                food5.text = (sceneData.receiptFood[5]); //then update total points
            }
            
        }
        else
        {
            Debug.LogError($"Mismatch between number of items and slot positions! foodInSlots.Count: {sceneData.foodInSlots.Count}, slotPositions.Count: {sceneData.slotPositions.Count}");

        }
    }

    void SpawnItemInSlot(Item item, FoodSlot slot)
    {
        GameObject newItemGo = Instantiate(inventoryItemPrefab, slot.transform);
        InventoryItem inventoryItem = newItemGo.GetComponent<InventoryItem>();
        inventoryItem.InitializeItem(item); // Initialize the item in the slot
        newItemGo.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
    }
}
