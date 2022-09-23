using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class HUDcontroller : MonoBehaviour
{
    //public static HUDcontroller instance;
    //public GameObject key;
    //public GameObject text;

    //public Text count;

    void Start()
    {
        Canvas canvas = FindObjectOfType<Canvas>();
 
        //float h = canvas.GetComponent<RectTransform>().rect.height;
        //float w = canvas.GetComponent<RectTransform>().rect.width;
        
        float minX = canvas.GetComponent<RectTransform>().position.x + canvas.GetComponent<RectTransform>().rect.xMin;
        float maxY = canvas.GetComponent<RectTransform>().position.y + canvas.GetComponent<RectTransform>().rect.yMax;
        
        //key.transform.position = new Vector3(minX + 35,maxY - 35,0);
        //text.transform.position = new Vector3(minX + 100,maxY - 35,0);
    }

    public void SetKeyUI(string _count)
    {
        //count.text = _count;
    }
}