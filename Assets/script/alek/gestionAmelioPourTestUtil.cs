using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class gestionAmelioPourTestUtil : MonoBehaviour
{
    public float distanceDetection;
    public inventaire amelioration;
    public GameObject txtTripleSaut;
    public GameObject txtDoubleDash;
    GameObject perso;
    GameObject parentTxt;
    GameObject txtClone;
    bool clonageFait;

    // Start is called before the first frame update
    void Start()
    {
        perso = GameObject.FindWithTag("perso");
        parentTxt = GameObject.Find("txtProximite");
    }

    // Update is called once per frame
    void Update()
    {
        float distanceAuPerso = Vector3.Distance(transform.position, perso.transform.position);

        if (distanceAuPerso <= distanceDetection)
        {
            if (!clonageFait)
            {
                CloneTxt();
                clonageFait = true;
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                amelioration.enPossesion = true;
                amelioration.actif = true;
                Destroy(gameObject);
                Destroy(txtClone);
            }
        }
        else
        {
            Destroy(txtClone);
            clonageFait = false;
        }
    }

    void CloneTxt()
    {
        if (gameObject.tag == "prefabTripleSaut")
        {
            txtClone = Instantiate(txtTripleSaut);
        }
        else if (gameObject.tag == "prefabDoubleDash")
        {
            txtClone = Instantiate(txtDoubleDash);
        }

        txtClone.SetActive(true);
        txtClone.transform.SetParent(parentTxt.transform);
        txtClone.GetComponent<RectTransform>().sizeDelta = new Vector2(925, 50);
        txtClone.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 80, 0);
    }
}
