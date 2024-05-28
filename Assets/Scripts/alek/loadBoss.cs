using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadBoss : MonoBehaviour
{
    public inventaire artefact1;
    public inventaire artefact2;
    public inventaire artefact3;

    bool peutCharger;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (artefact1.enPossesion &&  artefact2.enPossesion && artefact3.enPossesion)
        {
            peutCharger = true;
        }
        else
        {
            peutCharger = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("perso"))
        {
            if (peutCharger)
            {
                SceneManager.LoadScene(2);
            }
        }
    }
}
