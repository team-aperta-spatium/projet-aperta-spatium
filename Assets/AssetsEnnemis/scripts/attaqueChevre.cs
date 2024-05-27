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
        if (Physics.Linecast(chevre.transform.position, joueur.transform.position, out RaycastHit hitInfo) && isHit)
        {
            Vector3 forceChevre = hitInfo.point - joueur.transform.position;
            joueur.GetComponent<Rigidbody>().AddForce(-forceChevre.normalized * 2000f);
            isHit = false;
        }
    }
    private void OnTriggerStay(Collider collision)
    {
        if(collision.tag != "ennemi")
        {
            print(collision.gameObject.name);
            chevre.GetComponent<aiChevre>().confu = true;
            chevre.GetComponent<aiChevre>().hit = false;
            chevre.GetComponent<aiChevre>().animator.SetBool("Attaque", false);
            chevre.GetComponent<aiChevre>().Invoke("annuleConfu", 5f);
            if (collision.tag == "perso")
            {
                isHit = true;
                collision.GetComponent<viePerso>().nbrViePerso -= 1;
            }
        }
    }
}
