using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class controleArtefact : MonoBehaviour
{
    public GameObject perso;
    public float distanceDetection;
    public GameObject txt;
    public inventaire artefact;
    public GameObject parentTxt;
    GameObject cloneTxt;
    bool clonageFait;

    // Start is called before the first frame update
    void Start()
    {
        txt.SetActive(false);

        parentTxt = GameObject.Find("txtProximite");

        perso = GameObject.Find("perso");
    }

    // Update is called once per frame
    void Update()
    {
        float distanceAuPerso = Vector3.Distance(transform.position, perso.transform.position);

        if (distanceAuPerso <= distanceDetection)
        {
            if (!clonageFait)
            {
                cloneTxt = Instantiate(txt);
                cloneTxt.SetActive(true);
                cloneTxt.transform.SetParent(parentTxt.transform, false);
                clonageFait = true;
            }

            if (Input.GetKeyDown(KeyCode.P))
            {
                artefact.enPossesion = true;
                Destroy(gameObject);
                Destroy(cloneTxt);
            }
        }
        else
        {
            Destroy(cloneTxt);
            clonageFait = false;
        }
    }
}
