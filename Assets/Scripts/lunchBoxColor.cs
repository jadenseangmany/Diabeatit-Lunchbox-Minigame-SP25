using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lunchBoxColor : MonoBehaviour
{
    public Image lunchBoxImage;
    public Sprite[] color;
    public static int lunchBoxInt = 0;
    void Start()
    {
        ChangeLunchBoxColor(lunchBoxInt);
    }
    public void ChangeLunchBoxColor(int index)
    {
        if (index >= 0 && index < color.Length)
        {
            lunchBoxImage.sprite = color[index];

        }
        else
        {
            Debug.LogWarning("Invalid index.");
        }
    }
    public void changeColor(int index)
    {
        lunchBoxColor.lunchBoxInt = index;
    }
}
