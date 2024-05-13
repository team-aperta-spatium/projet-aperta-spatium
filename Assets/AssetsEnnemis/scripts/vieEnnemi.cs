using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vieEnnemi : MonoBehaviour
{
    public float nbrVie;
    public GameObject ennemie;

    void Update()
    {
        if (nbrVie <= 0)
        {
            if (ennemie.name.Contains("ennemie"))
            {
                ennemie.GetComponent<AI>().mort();
            }
            else if (ennemie.name.Contains("chevre"))
            {
                ennemie.GetComponent<aiChevre>().mort();
            }
            
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.name == "nodachi" && ennemie.name.Contains("ennemie"))
        {
            ennemie.GetComponent<AI>().trouverPerso = true;
        }
    }
}
