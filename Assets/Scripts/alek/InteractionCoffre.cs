//using BrewedInk.CRT;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InteractionCoffre : MonoBehaviour
{
    GameObject duplicateur;
    int[][] table;
    public float vitesseRound;
    public float vitesseObstacle;

    public GameObject laCamera;
    public GameObject ctnMiniJeu;

    static public bool jeuActif;

    // Update is called once per frame
    private void Start()
    {
        table = new int[10][];
        table[0] = new int[4];
        table[1] = new int[4];
        table[2] = new int[4];
        table[3] = new int[4];
        table[4] = new int[4];
        table[5] = new int[4];
        table[6] = new int[4];
        table[7] = new int[4];
        table[8] = new int[4];
        table[9] = new int[4];
        table[0][0] = 1; table[0][1] = 0; table[0][2] = 0; table[0][3] = 0;
        table[1][0] = 0; table[1][1] = 1; table[1][2] = 0; table[1][3] = 0;
        table[2][0] = 0; table[2][1] = 0; table[2][2] = 1; table[2][3] = 1;
        table[3][0] = 0; table[3][1] = 1; table[3][2] = 0; table[3][3] = 1;
        table[4][0] = 0; table[4][1] = 0; table[4][2] = 1; table[4][3] = 0;
        table[5][0] = 1; table[5][1] = 0; table[5][2] = 1; table[5][3] = 0;
        table[6][0] = 1; table[6][1] = 1; table[6][2] = 1; table[6][3] = 0;
        table[7][0] = 1; table[7][1] = 0; table[7][2] = 0; table[7][3] = 1;
        table[8][0] = 0; table[8][1] = 1; table[8][2] = 1; table[8][3] = 0;
        table[9][0] = 1; table[9][1] = 0; table[9][2] = 1; table[9][3] = 0;
        jeuActif = false;

        duplicateur = GameObject.Find("duplicateur");

        laCamera = GameObject.Find("cameraMiniJeu");
        ctnMiniJeu = GameObject.Find("ctnMiniJeu");
    }

    void Update()
    {
        if (jeuActif == false)
        {
            if (Input.GetKeyDown("e"))
            {
                //laCamera.GetComponent<CRTCameraBehaviour>().enabled = true;
                ctnMiniJeu.SetActive(true);
                jeuActif = true;
                Invoke("activerJeu", 2f);
                print("ok");
            }
        }
    }

    void activerJeu()
    {
        duplicateur.GetComponent<duplicateur>().debutJeu(table, vitesseObstacle, vitesseRound);
    }
}
