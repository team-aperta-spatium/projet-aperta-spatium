using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitboxSetAttaque : MonoBehaviour
{
    public GameObject chevre;
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.tag == "perso") 
        {
            chevre.GetComponent<aiChevre>().setAttaque();
        }
    }

   //private void OnTriggerExit(Collider collision)
   //{
   //    if (collision.tag == "perso")
   //    {
   //        print("attaque exit");
   //        chevre.GetComponent<aiChevre>().animator.SetBool("Attaque", false);
   //        chevre.GetComponent<aiChevre>().attaquer = false;
   //        chevre.GetComponent<aiChevre>().confu = true;
   //        chevre.GetComponent<aiChevre>().Invoke("annuleConfu", 5f);
   //    }
   //}
}
