using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

public class gestionItem : MonoBehaviour
{
    public Canvas canvas;
    public GameObject parent;
    private float y;
    public float tailleCanvas;
    void Update()
    {
        y = parent.GetComponent<RectTransform>().position.y;
        //GetComponent<RectTransform>().position = new Vector3(-0.001f * Mathf.Pow(-y + 350f, 2) + 700f, GetComponent<RectTransform>().position.y, GetComponent<RectTransform>().position.z);
        GetComponent<RawImage>().uvRect = new Rect(y / 200, 0, 1, 1);
    }
}
