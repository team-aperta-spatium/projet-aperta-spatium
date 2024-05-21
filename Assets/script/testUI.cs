using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class testUI : MonoBehaviour
{
    public GameObject ctn;
    public GameObject toggle;
    public GameObject parent;
    public GameObject nom;
    public GameObject description;
    public TMP_Text txtNom;
    public TMP_Text txtDescription;
    public inventaire doubleDash;
    public inventaire tripleSaut;
    public inventaire attaqueTornade;
    public inventaire dashRapide;
    public inventaire ralentiTemps;
    public inventaire clonage;

    public static bool tripleSautActif;
    public static bool doubleDashActif;
    public static bool attaqueTornadeActif;
    public static bool dashRapideActif;
    public static bool ralentiTempsActif;
    public static bool clonageActif;

    public static bool toggleBool;
    public static bool tripleSautActivee;
    public static bool doubleDashActivee;
    public static bool attaqueTornadeActivee;
    public static bool dashRapideActivee;
    public static bool ralentiTempsActivee;
    public static bool clonageActivee;

    public static float compteurAmelioration;

    // Start is called before the first frame update
    void Start()
    {
        compteurAmelioration = 0;

        if (tripleSaut.actif)
        {
            compteurAmelioration += 1;
        }
        
        if (doubleDash.actif)
        {
            compteurAmelioration += 1;
        }
        
        if (attaqueTornade.actif)
        {
            compteurAmelioration += 1;
        }
        
        if (dashRapide.actif)
        {
            compteurAmelioration += 1;
        }
        
        if (ralentiTemps.actif)
        {
            compteurAmelioration += 1;
        }
        
        if (clonage.actif)
        {
            compteurAmelioration += 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        SetBoolAmelioration();

        if (tripleSaut.actif)
        {
            tripleSautActivee = true;
        }
        else
        {
            tripleSautActivee = false;
        }

        if (doubleDash.actif)
        {
            doubleDashActivee = true;
        }
        else
        {
            doubleDashActivee = false;
        }
        
        if (attaqueTornade.actif)
        {
            attaqueTornadeActivee = true;
        }
        else
        {
            attaqueTornadeActivee = false;
        }
        
        if (dashRapide.actif)
        {
            dashRapideActivee = true;
        }
        else
        {
            dashRapideActivee = false;
        }
        
        if (ralentiTemps.actif)
        {
            ralentiTempsActivee = true;
        }
        else
        {
            ralentiTempsActivee = false;
        }
        
        if (clonage.actif)
        {
            clonageActivee = true;
        }
        else
        {
            clonageActivee = false;
        }
    }

    public void SetActif()
    {
        nom.GetComponent<TextMeshProUGUI>().enabled = true;
        description.GetComponent<TextMeshProUGUI>().enabled = true;
        Destroy(GameObject.FindWithTag("toggle"));
        tripleSautActif = false;
        doubleDashActif = false;
        attaqueTornadeActif = false;
        dashRapideActif = false;
        ralentiTempsActif = false;
        clonageActif = false;
        ctn.SetActive(true);
    }

    public void AfficherTripleSaut()
    {
        GameObject toggleObj = GameObject.Find("toggle");
        Destroy(toggleObj);

        toggleBool = tripleSautActivee;
        txtNom.text = tripleSaut.nom;
        txtDescription.text = tripleSaut.description;
        tripleSautActif = true;


        GameObject toggleClone = Instantiate(toggle);

        toggleClone.SetActive(true);

        toggleClone.transform.SetParent(parent.transform, false);

        if (tripleSautActivee)
        {
            toggleClone.GetComponent<Toggle>().isOn = true;
        }
        else
        {
            toggleClone.GetComponent<Toggle>().isOn = false;
        }
    }
    
    public void AfficherDoubleDash()
    {
        GameObject toggleObj = GameObject.Find("toggle");
        Destroy(toggleObj);

        toggleBool = doubleDashActivee;
        txtNom.text = doubleDash.nom;
        txtDescription.text = doubleDash.description;
        doubleDashActif = true;


        GameObject toggleClone = Instantiate(toggle);

        toggleClone.SetActive(true);

        toggleClone.transform.SetParent(parent.transform, false);

        if (doubleDashActivee)
        {
            toggleClone.GetComponent<Toggle>().isOn = true;
        }
        else
        {
            toggleClone.GetComponent<Toggle>().isOn = false;
        }
    }

    public void AfficherAttaqueTornade()
    {
        GameObject toggleObj = GameObject.Find("toggle");
        Destroy(toggleObj);

        toggleBool = attaqueTornadeActivee;
        txtNom.text = attaqueTornade.nom;
        txtDescription.text = attaqueTornade.description;
        attaqueTornadeActif = true;


        GameObject toggleClone = Instantiate(toggle);

        toggleClone.SetActive(true);

        toggleClone.transform.SetParent(parent.transform, false);

        if (attaqueTornadeActivee)
        {
            toggleClone.GetComponent<Toggle>().isOn = true;
        }
        else
        {
            toggleClone.GetComponent<Toggle>().isOn = false;
        }
    }
    
    public void AfficherDashRapide()
    {
        GameObject toggleObj = GameObject.Find("toggle");
        Destroy(toggleObj);

        toggleBool = dashRapideActivee;
        txtNom.text = dashRapide.nom;
        txtDescription.text = dashRapide.description;
        dashRapideActif = true;


        GameObject toggleClone = Instantiate(toggle);

        toggleClone.SetActive(true);

        toggleClone.transform.SetParent(parent.transform, false);

        if (dashRapideActivee)
        {
            toggleClone.GetComponent<Toggle>().isOn = true;
        }
        else
        {
            toggleClone.GetComponent<Toggle>().isOn = false;
        }
    }
    
    public void AfficherRalentiTemps()
    {
        GameObject toggleObj = GameObject.Find("toggle");
        Destroy(toggleObj);

        toggleBool = ralentiTempsActivee;
        txtNom.text = ralentiTemps.nom;
        txtDescription.text = ralentiTemps.description;
        ralentiTempsActif = true;


        GameObject toggleClone = Instantiate(toggle);

        toggleClone.SetActive(true);

        toggleClone.transform.SetParent(parent.transform, false);

        if (ralentiTempsActivee)
        {
            toggleClone.GetComponent<Toggle>().isOn = true;
        }
        else
        {
            toggleClone.GetComponent<Toggle>().isOn = false;
        }
    }
    
    public void AfficherClonage()
    {
        GameObject toggleObj = GameObject.Find("toggle");
        Destroy(toggleObj);

        toggleBool = clonageActivee;
        txtNom.text = clonage.nom;
        txtDescription.text = clonage.description;
        clonageActif = true;


        GameObject toggleClone = Instantiate(toggle);

        toggleClone.SetActive(true);

        toggleClone.transform.SetParent(parent.transform, false);

        if (clonageActivee)
        {
            toggleClone.GetComponent<Toggle>().isOn = true;
        }
        else
        {
            toggleClone.GetComponent<Toggle>().isOn = false;
        }
    }

    public void SetBoolAmelioration()
    {
        if (tripleSautActif)
        {
            tripleSaut.actif = toggleBool;
        }

        if (doubleDashActif)
        {
            doubleDash.actif = toggleBool;
        }
        
        if (attaqueTornadeActif)
        {
            attaqueTornade.actif = toggleBool;
        }
        
        if (dashRapideActif)
        {
            dashRapide.actif = toggleBool;
        }
        
        if (ralentiTempsActif)
        {
            ralentiTemps.actif = toggleBool;
        }
        
        if (clonageActif)
        {
            clonage.actif = toggleBool;
        }
    }
}
