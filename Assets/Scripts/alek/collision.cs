using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour
{
    public GameObject duplicateur;
    void Start()
    {

    }

    private void Update()
    {
        /*
        Vector3[] v = new Vector3[4];
        boite.GetWorldCorners(v);

        Debug.Log("cornerPerso");
        for (var i = 0; i < 4; i++)
        {
            Debug.Log("cornerPerso " + i + " : " + v[i]);
        }
        
        boiteHaut = v[1] + v[2] - new Vector3((v[2].x- v[1].x)/2, v[1].y, 0f);
        print(boiteHaut);
        */
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        duplicateur.GetComponent<duplicateur>().Defaite();
    }
}
