using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uiToggleAmelioration : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (testUI.compteurAmelioration == 3)
        {
            GetComponent<Toggle>().interactable = false;
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
        if (testUI.tripleSautActif)
        {
            if (testUI.tripleSautActivee)
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
            if (testUI.doubleDashActivee)
            {
                testUI.compteurAmelioration -= 1;
            }
            else
            {
                testUI.compteurAmelioration += 1;
            }
        }

        Debug.Log(testUI.compteurAmelioration);
    }
}
