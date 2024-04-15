using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class testUI : MonoBehaviour
{
    public GameObject toggle;
    public GameObject nom;
    public GameObject description;
    public TMP_Text txtNom;
    public TMP_Text txtDescription;
    public inventaire doubleDash;
    public inventaire tripleSaut;
    public static bool toggleBool;

    bool tripleSautActif;
    bool doubleDashActif;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SetBoolAmelioration();
    }

    public void SetActif()
    {
        toggle.SetActive(true);
        nom.GetComponent<TextMeshProUGUI>().enabled = true;
        description.GetComponent<TextMeshProUGUI>().enabled = true;
    }

    public void AfficherTripleSaut()
    {
        txtNom.text = tripleSaut.nom;
        txtDescription.text = tripleSaut.description;
        tripleSautActif = true;
        doubleDashActif = false;
    }
    
    public void AfficherDoubleDash()
    {
        txtNom.text = doubleDash.nom;
        txtDescription.text = doubleDash.description;
        tripleSautActif = false;
        doubleDashActif = true;
    }

    public void SetBoolAmelioration()
    {
        if (tripleSautActif)
        {
            tripleSaut.actif = toggleBool;
        }
        
        if(doubleDashActif)
        {
            doubleDashActif = toggleBool;
        }

        Debug.Log("triple saut:" + tripleSautActif);
        Debug.Log("double dash:" + doubleDashActif);
    }
}
