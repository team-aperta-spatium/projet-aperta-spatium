using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gestionJeu : MonoBehaviour
{
    public inventaire artefact1;
    public inventaire artefact2;
    public inventaire artefact3;
    public GameObject colone1;
    public GameObject colone2;
    public GameObject colone3;
    public GameObject colone4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (artefact1.enPossesion)
        {
            Destroy(colone1);
        }

        if (artefact2.enPossesion)
        {
            Destroy(colone2);
        }

        if (artefact3.enPossesion)
        {
            Destroy(colone3);
        }
        
        if (artefact1.enPossesion && artefact2.enPossesion && artefact3.enPossesion)
        {
            Instantiate(colone4);
        }
    }
}
