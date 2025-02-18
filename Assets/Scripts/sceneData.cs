using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class sceneData
{
    public static int TotalPoints = 0;
    public static List<int> slotPositions = new List<int>();
    public static List<Item> foodInSlots = new List<Item>(); //to keep track of chosen foods to transfer to finishScene
    public static List<string> receiptFood = new List<string>();

}