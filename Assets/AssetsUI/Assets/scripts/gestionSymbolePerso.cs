using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gestionSymbolePerso : MonoBehaviour
{
    public float positionX;
    public float positionY;
    void Update()
    {
        gameObject.GetComponent<RectTransform>().position = new Vector2(positionX, positionY);
    }
}
