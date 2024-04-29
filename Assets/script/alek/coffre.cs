using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coffre : MonoBehaviour
{
    public Transform perso;
    public Rigidbody persoGO;
    public float distanceDetection;
    public GameObject canvasTxt;
    public GameObject canvasMiniJeu;
    public GameObject cameraPerso;
    public GameObject cameraMiniJeu;

    static public bool canvasMiniJeuActif;

    // Start is called before the first frame update
    void Start()
    {
        canvasMiniJeuActif = false;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceAuPerso = Vector3.Distance(transform.position, perso.position);

        if (distanceAuPerso <= distanceDetection)
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                canvasMiniJeu.SetActive(true);
                cameraPerso.SetActive(false);
                cameraMiniJeu.SetActive(true);
                canvasMiniJeuActif = true;
            }

            if (canvasMiniJeuActif == true)
            {
                persoGO.constraints = RigidbodyConstraints.FreezeAll;
                canvasTxt.SetActive(false);
                GetComponent<InteractionCoffre>().enabled = true;
            }
            else
            {
                canvasTxt.SetActive(true);
                GetComponent<InteractionCoffre>().enabled = false;
            }
        }
        else
        {
            canvasTxt.SetActive(false);
        }
    }
}
