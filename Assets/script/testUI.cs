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
        nom.GetComponent<TextMeshProUGUI>().enabled = true;
        description.GetComponent<TextMeshProUGUI>().enabled = true;
        Destroy(GameObject.FindWithTag("toggle"));
    }

    public void AfficherTripleSaut()
    {
        txtNom.text = tripleSaut.nom;
        txtDescription.text = tripleSaut.description;
        tripleSautActif = true;
        doubleDashActif = false;

        GameObject toggleClone = Instantiate(toggle);

        toggleClone.SetActive(true);

        toggleClone.transform.SetParent(parent.transform, false);

        if (tripleSaut.actif)
        {
            toggle.GetComponent<Toggle>().isOn = true;
        }
        else
        {
            toggle.GetComponent<Toggle>().isOn = false;
        }
    }
    
    public void AfficherDoubleDash()
    {
        txtNom.text = doubleDash.nom;
        txtDescription.text = doubleDash.description;
        doubleDashActif = true;
        tripleSautActif = false;

        GameObject toggleClone = Instantiate(toggle);

        toggleClone.SetActive(true);

        toggleClone.transform.SetParent(parent.transform, false);

        if (doubleDash.actif)
        {
            toggle.GetComponent<Toggle>().isOn = true;
        }
        else
        {
            toggle.GetComponent<Toggle>().isOn = false;
        }
    }

    public void SetBoolAmelioration()
    {
        if (tripleSautActif)
        {
            tripleSaut.actif = toggleBool;
        }
        else if (doubleDashActif)
        {
            doubleDash.actif = toggleBool;
        }
    }
}
