using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TitleBar : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public Canvas canvas;
    public RectTransform RectTransform;

    private void Awake()
    {
        
        RectTransform = transform.parent.GetComponent<RectTransform>();
    }

    private void Start()
    {
        canvas = UIManager.Instance.MainCanvas;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Clicked on Titlebar");
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Is dragging ");
        RectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Beginning to drag");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("Ending Drag");
    }

}
