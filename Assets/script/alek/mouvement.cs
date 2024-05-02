using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class mouvement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RectTransform boite = GetComponent<RectTransform>();
        /*
        if (Input.GetKey("w"))
        {
           boite.anchoredPosition = new Vector2(boite.anchoredPosition.x, boite.anchoredPosition.y + 1f);
        }
        else if(Input.GetKey("s"))
        {
            boite.anchoredPosition = new Vector2(boite.anchoredPosition.x, boite.anchoredPosition.y + -1f);
        }
        else if (Input.GetKey("a"))
        {
            boite.anchoredPosition = new Vector2(boite.anchoredPosition.x + -1f, boite.anchoredPosition.y);
        }
        else if (Input.GetKey("d"))
        {
            boite.anchoredPosition = new Vector2(boite.anchoredPosition.x + 1f, boite.anchoredPosition.y);
        }*/


        if (Input.GetKey("a"))
        {
            boite.Rotate(0f, 0f, 0.75f);
        }
        else if (Input.GetKey("d"))
        {
            boite.Rotate(0f, 0f, -0.75f);
        }
    }
}
