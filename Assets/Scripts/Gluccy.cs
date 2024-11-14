using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Scriptable object/Gluccy")]
public class Gluccy : ScriptableObject {
    public Expression expression;

    [Header("Both")]
    public Sprite image;
}

public enum Expression
{
    happy, sad, excited
}