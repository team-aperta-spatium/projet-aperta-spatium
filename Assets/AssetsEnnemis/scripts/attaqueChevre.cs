using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attaqueChevre : MonoBehaviour
{
    public GameObject chevre;
    public GameObject joueur;

    public bool isHit;
    private void Update()
    {
        
    }
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.tag != "ennemi")
        {
            print(collision.gameObject.name);
            chevre.GetComponent<aiChevre>().confu = true;
            chevre.GetComponent<aiChevre>().attaquer = false;
            chevre.GetComponent<aiChevre>().animator.SetBool("Attaque", false);
            chevre.GetComponent<aiChevre>().Invoke("annuleConfu", 5f);
            if (collision.tag == "perso")
            {
                isHit = true;
                viePerso.nbrViePerso -= 1;
                if (Physics.Linecast(chevre.transform.position, joueur.transform.position, out RaycastHit hitInfo) && isHit)
                {
                    Vector3 forceChevre = hitInfo.point - joueur.transform.position;
                    joueur.GetComponent<Rigidbody>().AddForce(-forceChevre.normalized * 2500f);
                    isHit = false;
                }
            }
        }
    }
}
