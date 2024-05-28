using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gestionJeu : MonoBehaviour
{
    public GameObject canvasUI;

    bool canvasUIActif;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (!canvasUIActif)
            {
                canvasUIActif = true;
                //canvasUI.GetComponent<Canvas>().enabled = true;
                canvasUI.SetActive(true);
                Time.timeScale = 0f;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                canvasUIActif = false;
                //canvasUI.GetComponent<Canvas>().enabled = false;
                canvasUI.SetActive(false);
                Time.timeScale = 1f;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }
}
