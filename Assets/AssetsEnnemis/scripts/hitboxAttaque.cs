using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitboxAttaque : MonoBehaviour
{
    public GameObject chevre;
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.tag == "perso") 
        {
            chevre.GetComponent<aiChevre>().attaquer = true;
        }
    }
}
