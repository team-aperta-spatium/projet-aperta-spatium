using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class gestionAmelioPourTestUtil : MonoBehaviour
{
    public Transform perso;
    public float distanceDetection;
    public GameObject parentTxt;
    public GameObject txt;
    public inventaire amelioration;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distanceAuPerso = Vector3.Distance(transform.position, perso.position);

        if (distanceAuPerso <= distanceDetection)
        {
            GameObject cloneCanvas = Instantiate(parentTxt);
            cloneCanvas.SetActive(true);

            GameObject cloneTxt = Instantiate(txt);
            cloneTxt.SetActive(true);
            cloneTxt.transform.SetParent(cloneCanvas.transform, false);

            if (Input.GetKeyDown(KeyCode.E))
            {
                amelioration.enPossesion = true;
                amelioration.actif = true;
                Destroy(gameObject);
            }
        }
        else
        {
            txt.SetActive(false);
        }
    }
}
