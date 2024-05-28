using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitboxSetAttaque : MonoBehaviour
{
    public GameObject chevre;
    public bool confu;

    private void Start()
    {
        confu = false;
    }
    private void OnTriggerStay(Collider collision)
    {
        if(collision.tag == "perso" && !confu) 
        {
            chevre.GetComponent<aiChevre>().setAttaque();
            confu = true;
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
