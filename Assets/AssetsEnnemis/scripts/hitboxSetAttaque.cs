using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitboxSetAttaque : MonoBehaviour
{
    public GameObject chevre;
    private void OnTriggerStay(Collider collision)
    {
        if(collision.tag == "perso") 
        {
            chevre.GetComponent<aiChevre>().attaquer = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.tag == "perso")
        {
            chevre.GetComponent<aiChevre>().attaquer = false;
        }
    }
}
