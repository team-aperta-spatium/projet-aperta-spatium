using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coffre : MonoBehaviour
{
    GameObject perso;
    Rigidbody persoGO;

    public float distanceDetection;
    public GameObject canvasTxt;
    public GameObject refClone;

    public GameObject canvasMiniJeu;
    GameObject cameraPerso;
    GameObject parentTxt;
    GameObject cloneTxt;
    public GameObject cameraMiniJeu;
    bool clonageFait;

    static public bool canvasMiniJeuActif;

    // Start is called before the first frame update
    void Start()
    {
        canvasMiniJeuActif = false;
        perso = GameObject.Find("perso");
        persoGO = perso.GetComponent<Rigidbody>();
        cameraPerso = GameObject.Find("cameraPerso");
        parentTxt = GameObject.Find("txtProximite");
    }

    // Update is called once per frame
    void Update()
    {
        float distanceAuPerso = Vector3.Distance(transform.position, perso.transform.position);

        if (distanceAuPerso <= distanceDetection)
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                canvasMiniJeu.SetActive(true);
                cameraPerso.GetComponent<Camera>().enabled = false;
                cameraPerso.GetComponent<AudioListener>().enabled = false;
                cameraMiniJeu.SetActive(true);
                cameraMiniJeu.GetComponent<AudioListener>().enabled = true;
                canvasMiniJeuActif = true;
                refClone.SetActive(true);
            }

            if (canvasMiniJeuActif == true)
            {
                persoGO.constraints = RigidbodyConstraints.FreezeAll;
                Destroy(cloneTxt);
                clonageFait = false;
                GetComponent<InteractionCoffre>().enabled = true;
            }
            else
            {
                if (!clonageFait)
                {
                    cloneTxt = Instantiate(canvasTxt);
                    cloneTxt.SetActive(true);
                    cloneTxt.transform.SetParent(parentTxt.transform);
                    cloneTxt.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 80, 0);
                    clonageFait = true;
                }
                GetComponent<InteractionCoffre>().enabled = false;
            }
        }
        else
        {
            Destroy(cloneTxt);
            clonageFait = false;
        }
    }
}
