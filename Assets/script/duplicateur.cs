using BrewedInk.CRT;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;
using UnityEngine.UI;

public class duplicateur : MonoBehaviour
{
    public GameObject canvas;
    public GameObject obsN;
    public GameObject obsE;
    public GameObject obsS;
    public GameObject obsO;
    private GameObject cloneObsN;
    private GameObject cloneObsE;
    private GameObject cloneObsS;
    private GameObject cloneObsO;

    public GameObject laCamera;
    public GameObject camPerso;
    public GameObject canvasMiniJeu;
    public Rigidbody perso;
    public GameObject ctnMiniJeu;

    public RawImage cadenas;
    public Texture cadenasBrise;
    float vitesseObstacle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void debutJeu(int[][] table, float vObs, float vRounds)
    {
        vitesseObstacle = vObs;
        for(int i = 0; i < table.Length; i++)
        {
            if (table[i][0] == 1)
            {
                Invoke("DupliqueObsN", vRounds * i);
                print("nord");
            }

            if (table[i][1] == 1)
            {
                Invoke("DupliqueObsE", vRounds * i);
                print("est");
            }

            if (table[i][2] == 1)
            {
                Invoke("DupliqueObsS", vRounds * i);
                print("sud");
            }

            if (table[i][3] == 1)
            {
                Invoke("DupliqueObsO", vRounds * i);
                print("ouest");
            }

            if (i == table.Length - 1)
            {
                Invoke("Victoire", vRounds * i + vRounds + 1);
            }
        }
    }


    void DupliqueObsN()
    {
        cloneObsN = Instantiate(obsN);
        cloneObsN.transform.SetParent(canvas.transform, false);
        cloneObsN.GetComponent<obstacleNord>().vitesseObstacle = vitesseObstacle;
        cloneObsN.SetActive(true);
    }

    void DupliqueObsE()
    {
        cloneObsE = Instantiate(obsE);
        cloneObsE.transform.SetParent(canvas.transform, false);
        cloneObsE.GetComponent<obstacleEst>().vitesseObstacle = vitesseObstacle;
        cloneObsE.SetActive(true);
    }

    void DupliqueObsS()
    {
        cloneObsS = Instantiate(obsS);
        cloneObsS.transform.SetParent(canvas.transform, false);
        cloneObsS.GetComponent<obstacleSud>().vitesseObstacle = vitesseObstacle;
        cloneObsS.SetActive(true);
    }

    void DupliqueObsO()
    {
        cloneObsO = Instantiate(obsO);
        cloneObsO.transform.SetParent(canvas.transform, false);
        cloneObsO.GetComponent<obstacleOuest>().vitesseObstacle = vitesseObstacle;
        cloneObsO.SetActive(true);
    }

    void Victoire()
    {
        cadenas.texture = cadenasBrise;
        Invoke("FermerMiniJeu", 2f);
    }

    void FermerMiniJeu()
    {
        laCamera.GetComponent<CRTCameraBehaviour>().enabled = false;
        ctnMiniJeu.SetActive(false);
        laCamera.SetActive(false);
        camPerso.SetActive(true);
        coffre.canvasMiniJeuActif = false;
        InteractionCoffre.jeuActif = false;
        perso.constraints = RigidbodyConstraints.None;
        perso.constraints = RigidbodyConstraints.FreezeRotation;
    }

    public void Defaite()
    {
        CancelInvoke();
        laCamera.GetComponent<CRTCameraBehaviour>().enabled = false;
        ctnMiniJeu.SetActive(false);
        laCamera.SetActive(false);
        camPerso.SetActive(true);
        coffre.canvasMiniJeuActif = false;
        InteractionCoffre.jeuActif = false;
        perso.constraints = RigidbodyConstraints.None;
        perso.constraints = RigidbodyConstraints.FreezeRotation;
    }
}
