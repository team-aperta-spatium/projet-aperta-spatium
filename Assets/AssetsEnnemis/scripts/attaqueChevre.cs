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
    private void OnTriggerEnter(Collider collision)
    {
        chevre.GetComponent<aiChevre>().hit = true;
        if (collision.tag == "perso")
        {
            collision.GetComponent<viePerso>().nbrViePerso -= 1;
        }
    }
}
