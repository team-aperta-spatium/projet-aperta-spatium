using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vieChevre : MonoBehaviour
{
    public float nbrVie;
    public GameObject ennemie;

    // Start is called before the first frame update
    void Start()
    {
        nbrVie = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (nbrVie <= 0)
        {
            ennemie.GetComponent<aiChevre>().mort();
        }
    }
}