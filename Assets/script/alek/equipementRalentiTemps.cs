using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class equipementRalentiTemps : MonoBehaviour
{
    public inventaire ralentiTemps;

    bool tempsEstRalenti;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ralentiTemps.actif)
        {
            if (Input.GetKeyUp(KeyCode.R) && !tempsEstRalenti)
            {
                Time.timeScale = 0.5f;

                tempsEstRalenti = true;

                Invoke("TempsNormale", 1.5f);
            }
        }
    }

    void TempsNormale()
    {
        Time.timeScale = 1.0f;

        tempsEstRalenti = false;
    }
}
