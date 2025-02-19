using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
   
    [Header("UI")]
    public Image image;

    [HideInInspector] public Transform parentAfterDrag;
    [HideInInspector] public Item item;
   
    public void InitializeItem(Item newItem)
    {
        item = newItem;
        image.sprite = newItem.image;
    }

    //Ignore drag
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Begin Drag");
        if (image!= null)
        image.raycastTarget = false;
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("End Drag");
        image.raycastTarget = true;
        transform.SetParent(parentAfterDrag);
    }
}
