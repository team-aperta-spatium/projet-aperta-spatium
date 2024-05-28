using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class gestionVies : MonoBehaviour
{
    float nbVies = 6;
    public float vieActive;
    public GameObject persoObj;


    public GameObject vie1;
    public GameObject vie2;
    public GameObject vie3;
    public GameObject vie4;
    public GameObject vie5;
    public GameObject vie6;
    private void Start()
    {
        vie1.SetActive(true);
        vie2.SetActive(true);
        vie3.SetActive(true);
        vie4.SetActive(true);
        vie5.SetActive(true);
        vie6.SetActive(true);
    }
    void Update()
    {
        vieActive = viePerso.nbrViePerso;

        if (nbVies - vieActive > 0) { vie1.SetActive(false); }
        if (nbVies - vieActive > 1) { vie2.SetActive(false); }
        if (nbVies - vieActive > 2) { vie3.SetActive(false); }
        if (nbVies - vieActive > 3) { vie4.SetActive(false); }
        if (nbVies - vieActive > 4) { vie5.SetActive(false); }
        if (nbVies - vieActive > 5) { vie6.SetActive(false); }
    }
}
