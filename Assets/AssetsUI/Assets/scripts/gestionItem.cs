using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class gestionItem : MonoBehaviour
{
    public GameObject parent;
    private float y;
    // Update is called once per frame
    void Update()
    {
        y = parent.GetComponent<RectTransform>().position.y;
        GetComponent<RectTransform>().position = new Vector2(-0.001f * Mathf.Pow(-y + 150f, 2) + 500f, GetComponent<RectTransform>().position.y);
        GetComponent<RawImage>().uvRect = new Rect(y / 200, 0, 1, 1);
    }
}
