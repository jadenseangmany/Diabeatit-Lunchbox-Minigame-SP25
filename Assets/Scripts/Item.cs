using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Scriptable object/Item")]
public class Item : ScriptableObject {
    public ItemType type;
    public Vector2Int range = new Vector2Int(5, 4);

    [Header("Both")]
    public Sprite image;

}

public enum ItemType
{
    Protein, Vegetable, Snack, Drink, Dairy, Fruit
}