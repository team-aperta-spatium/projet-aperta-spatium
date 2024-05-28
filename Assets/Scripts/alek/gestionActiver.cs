using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gestionActiver : MonoBehaviour
{
    public GameObject ctn1;
    public GameObject ctn2;
    public GameObject ctn3;
    public GameObject ctn4;
    public GameObject ctn5;
    public GameObject ctn6;

    public inventaire tripleSaut;
    public inventaire doubleDash;
    public inventaire attaqueTornade;
    public inventaire dashRapide;
    public inventaire ralentiTemps;
    public inventaire clonage;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (ctn1.tag == tripleSaut.nom)
        {
            if (!tripleSaut.enPossesion)
            {
                ctn1.SetActive(false);
            }
            else
            {
                ctn1.SetActive(true);
            }
        }

        if (ctn2.tag == doubleDash.nom)
        {
            if (!doubleDash.enPossesion)
            {
                ctn2.SetActive(false);
            }
            else
            {
                ctn2.SetActive(true);
            }
        }

        if (ctn3.tag == attaqueTornade.nom)
        {
            if (!attaqueTornade.enPossesion)
            {
                ctn3.SetActive(false);
            }
            else
            {
                ctn3.SetActive(true);
            }
        }

        if (ctn4.tag == dashRapide.nom)
        {
            if (!dashRapide.enPossesion)
            {
                ctn4.SetActive(false);
            }
            else
            {
                ctn4.SetActive(true);
            }
        }

        if (ctn5.tag == ralentiTemps.nom)
        {
            if (!ralentiTemps.enPossesion)
            {
                ctn5.SetActive(false);
            }
            else
            {
                ctn5.SetActive(true);
            }
        }

        if (ctn6.tag == clonage.nom)
        {
            if (!clonage.enPossesion)
            {
                ctn6.SetActive(false);
            }
            else
            {
                ctn6.SetActive(true);
            }
        }
    }
}
