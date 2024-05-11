using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uiToggleAmelioration : MonoBehaviour
{
    public inventaire tripleSaut;
    public inventaire doubleDash;
    public inventaire attaqueTornade;
    public inventaire dashRapide;
    public inventaire ralentiTemps;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (testUI.compteurAmelioration >= 3)
        {
            if (GetComponent<Toggle>().isOn)
            {
                GetComponent<Toggle>().interactable = true;
            }
            else
            {
                GetComponent<Toggle>().interactable = false;
            }

        }
        else if (testUI.compteurAmelioration < 3)
        {
            GetComponent<Toggle>().interactable = true;
        }
    }

    public void OnToggleChanged(bool toggle)
    {
        testUI.toggleBool = toggle; 
    }

    public void Onclick()
    {
        if (GetComponent <Toggle>().interactable)
        {
            if (testUI.tripleSautActif)
            {
                if (tripleSaut.actif)
                {
                    testUI.compteurAmelioration -= 1;
                }
                else
                {
                    testUI.compteurAmelioration += 1;
                }
            }
        
            if (testUI.doubleDashActif)
            {
                if (doubleDash.actif)
                {
                    testUI.compteurAmelioration -= 1;
                }
                else
                {
                    testUI.compteurAmelioration += 1;
                }
            }

            if (testUI.attaqueTornadeActif)
            {
                if (attaqueTornade.actif)
                {
                    testUI.compteurAmelioration -= 1;
                }
                else
                {
                    testUI.compteurAmelioration += 1;
                }
            }
            
            if (testUI.dashRapideActif)
            {
                if (dashRapide.actif)
                {
                    testUI.compteurAmelioration -= 1;
                }
                else
                {
                    testUI.compteurAmelioration += 1;
                }
            }
            
            if (testUI.ralentiTempsActif)
            {
                if (ralentiTemps.actif)
                {
                    testUI.compteurAmelioration -= 1;
                }
                else
                {
                    testUI.compteurAmelioration += 1;
                }
            }
        }
    }
}
