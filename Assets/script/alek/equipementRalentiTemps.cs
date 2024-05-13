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
            if (Input.GetKey(KeyCode.R))
            {
                Time.timeScale = 0.5f;

                tempsEstRalenti = true;

                mouvement2.endurance -= 0.2f;

                //Invoke("TempsNormale", 1.5f);
            }
            else if (Input.GetKeyUp(KeyCode.R))
            {
                Time.timeScale = 1f;
                tempsEstRalenti = false;
            }
        }
    }

    void TempsNormale()
    {
        Time.timeScale = 1.0f;

        tempsEstRalenti = false;
    }
}
