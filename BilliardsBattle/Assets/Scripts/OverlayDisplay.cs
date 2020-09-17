using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OverlayDisplay : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // Start is called before the first frame update
    public bool isOver;
    public GameObject thisSlot;
    
    void Start()
    {
        isOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (transform.GetChild(1).gameObject.activeSelf)
        {
            isOver = true;
            transform.GetChild(2).GetComponent<Image>().enabled = true;
        }
    
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isOver = false;
        transform.GetChild(2).GetComponent<Image>().enabled = false;

    }
}
