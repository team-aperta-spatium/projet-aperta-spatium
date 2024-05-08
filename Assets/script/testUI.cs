using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class testUI : MonoBehaviour
{
    public GameObject toggle;
    public GameObject parent;
    public GameObject nom;
    public GameObject description;
    public TMP_Text txtNom;
    public TMP_Text txtDescription;
    public inventaire doubleDash;
    public inventaire tripleSaut;
    public inventaire attaqueTornade;

    public static bool tripleSautActif;
    public static bool doubleDashActif;
    public static bool attaqueTornadeActif;

    public static bool toggleBool;
    public static bool tripleSautActivee;
    public static bool doubleDashActivee;
    public static bool attaqueTornadeActivee;

    float timerInvokeTripleSaut;
    float timerInvokeDoubleDash;

    bool invokeTripleSaut;
    bool invokeDoubleDash;

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

        if (timerInvokeTripleSaut > 0)
        {
            timerInvokeTripleSaut -= 0.005f;
        }
        else
        {
            if (invokeTripleSaut)
            {
                AfficherTripleSautDelai();
                invokeTripleSaut = false;
            }
        }
        
        if (timerInvokeDoubleDash > 0)
        {
            timerInvokeDoubleDash -= 0.001f;
        }
        else
        {
            if (invokeDoubleDash)
            {
                AfficherDoubleDashDelai();
                invokeDoubleDash = false;
            }
        }

        Debug.Log(compteurAmelioration);
    }

    public void SetActif()
    {
        nom.GetComponent<TextMeshProUGUI>().enabled = true;
        description.GetComponent<TextMeshProUGUI>().enabled = true;
        Destroy(GameObject.FindWithTag("toggle"));
    }

    public void AfficherTripleSaut()
    {
        doubleDashActif = false;
        attaqueTornadeActif = false;

        GameObject toggleObj = GameObject.Find("toggle");
        Destroy(toggleObj);

        timerInvokeTripleSaut = 0.01f;
        invokeTripleSaut = true;
    }
    
    public void AfficherDoubleDash()
    {
        tripleSautActif = false;
        attaqueTornadeActif = false;

        GameObject toggleObj = GameObject.Find("toggle");
        Destroy(toggleObj);

        timerInvokeDoubleDash = 0.01f;
        invokeDoubleDash = true;
    }

    public void AfficherAttaqueTornade()
    {
        tripleSautActif = false;
        doubleDashActif = false;

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
    }

    void AfficherTripleSautDelai()
    {
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
    
    void AfficherDoubleDashDelai()
    {
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
}
