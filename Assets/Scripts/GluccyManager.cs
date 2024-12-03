using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GluccyManager : MonoBehaviour
{
    public Image Gluccy;
    public Sprite[] emotion;
    public float resetTime = 0.25f;
    private float timer = 0f;
    void Start()
    {
        ChangeGluccy(0);
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= resetTime)
        {
            ChangeGluccy(0);
        }
    }
    public void ChangeGluccy(int index)
    {
        
        if (index >= 0 && index < emotion.Length)
        {
            Gluccy.sprite = emotion[index];
            timer = 0f;

        }
        else
        {
            Debug.LogWarning("Invalid index.");
        }

    }

}