using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class gestionTailleCtn : MonoBehaviour
{
    public int nbItems;

    public GameObject ctnItem;

    // Start is called before the first frame update
    private void Update()
    {
        nbItems = transform.childCount;
    }
}
