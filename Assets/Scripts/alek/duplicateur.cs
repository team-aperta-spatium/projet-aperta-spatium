using UnityEngine;
using UnityEngine.UI;

public class duplicateur : MonoBehaviour
{
    public inventaire tripleSaut;
    public inventaire doubleDash;
    public inventaire attaqueTornade;
    public inventaire clonage;
    public inventaire dashRapide;
    public inventaire ralentiTemps;
    public GameObject tripleSautObj;
    public GameObject doubleDashObj;
    public GameObject attaqueTornadeObj;
    public GameObject clonageObj;
    public GameObject dashRapideObj;
    public GameObject ralentiTempsObj;
    public GameObject canvas;
    public GameObject obsN;
    public GameObject obsE;
    public GameObject obsS;
    public GameObject obsO;
    private GameObject cloneObsN;
    private GameObject cloneObsE;
    private GameObject cloneObsS;
    private GameObject cloneObsO;

    public GameObject canvasMiniJeu;
    public GameObject ctnMiniJeu;

    public GameObject laCamera;
    GameObject parentClone;
    GameObject camPerso;
    GameObject persoObj;
    Rigidbody persoRb;

    public RawImage cadenas;
    public Texture cadenasBrise;
    public Texture cadenasNormal;
    float vitesseObstacle;
    // Start is called before the first frame update
    void Start()
    {
        laCamera = GameObject.Find("cameraMiniJeu");
        camPerso = GameObject.Find("cameraPerso");
        persoObj = GameObject.Find("perso");
        persoRb = persoObj.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        parentClone = GameObject.Find("refClone");
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
        //laCamera.GetComponent<CRTCameraBehaviour>().enabled = false;
        laCamera.GetComponent<Camera>().enabled = false;
        laCamera.GetComponent<AudioListener>().enabled = false;
        camPerso.GetComponent<AudioListener>().enabled = false;
        camPerso.GetComponent<Camera>().enabled = true;
        coffre.canvasMiniJeuActif = false;
        InteractionCoffre.jeuActif = false;
        ClonageEquipement();
        persoRb.constraints = RigidbodyConstraints.None;
        persoRb.constraints = RigidbodyConstraints.FreezeRotation;
        Destroy(parentClone.transform.parent.gameObject);
        cadenas.texture = cadenasNormal;
    }

    public void Defaite()
    {
        CancelInvoke();
        //laCamera.GetComponent<CRTCameraBehaviour>().enabled = false;
        laCamera.GetComponent<Camera>().enabled = false;
        laCamera.GetComponent<AudioListener>().enabled = false;
        camPerso.GetComponent<Camera>().enabled = true;
        camPerso.GetComponent<AudioListener>().enabled = true;
        coffre.canvasMiniJeuActif = false;
        InteractionCoffre.jeuActif = false;
        persoRb.constraints = RigidbodyConstraints.None;
        persoRb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    void ClonageEquipement()
    {
        if (!tripleSaut.enPossesion && !doubleDash.enPossesion && !attaqueTornade.enPossesion && !clonage.enPossesion && !dashRapide.enPossesion && !ralentiTemps.enPossesion)
        {
            int nbrRandom = UnityEngine.Random.Range(1, 7);

            if (nbrRandom == 1)
            {
                GameObject cloneAmelioration = Instantiate(tripleSautObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 2)
            {
                GameObject cloneAmelioration = Instantiate(doubleDashObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 3)
            {
                GameObject cloneAmelioration = Instantiate(attaqueTornadeObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 4)
            {
                GameObject cloneAmelioration = Instantiate(clonageObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 5)
            {
                GameObject cloneAmelioration = Instantiate(dashRapideObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 6)
            {
                GameObject cloneAmelioration = Instantiate(ralentiTempsObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
        }
        else if (tripleSaut.enPossesion && !doubleDash.enPossesion && !attaqueTornade.enPossesion && !clonage.enPossesion && !dashRapide.enPossesion && !ralentiTemps.enPossesion)
        {
            int nbrRandom = UnityEngine.Random.Range(1, 6);

            if (nbrRandom == 1)
            {
                GameObject cloneAmelioration = Instantiate(ralentiTempsObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 2)
            {
                GameObject cloneAmelioration = Instantiate(doubleDashObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 3)
            {
                GameObject cloneAmelioration = Instantiate(attaqueTornadeObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 4)
            {
                GameObject cloneAmelioration = Instantiate(clonageObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 5)
            {
                GameObject cloneAmelioration = Instantiate(dashRapideObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
        }
        else if (!tripleSaut.enPossesion && doubleDash.enPossesion && !attaqueTornade.enPossesion && !clonage.enPossesion && !dashRapide.enPossesion && !ralentiTemps.enPossesion)
        {
            int nbrRandom = UnityEngine.Random.Range(1, 6);

            if (nbrRandom == 1)
            {
                GameObject cloneAmelioration = Instantiate(tripleSautObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 2)
            {
                GameObject cloneAmelioration = Instantiate(ralentiTempsObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 3)
            {
                GameObject cloneAmelioration = Instantiate(attaqueTornadeObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 4)
            {
                GameObject cloneAmelioration = Instantiate(clonageObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 5)
            {
                GameObject cloneAmelioration = Instantiate(dashRapideObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
        }
        else if (!tripleSaut.enPossesion && !doubleDash.enPossesion && attaqueTornade.enPossesion && !clonage.enPossesion && !dashRapide.enPossesion && !ralentiTemps.enPossesion)
        {
            int nbrRandom = UnityEngine.Random.Range(1, 6);

            if (nbrRandom == 1)
            {
                GameObject cloneAmelioration = Instantiate(tripleSautObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 2)
            {
                GameObject cloneAmelioration = Instantiate(doubleDashObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 3)
            {
                GameObject cloneAmelioration = Instantiate(ralentiTempsObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 4)
            {
                GameObject cloneAmelioration = Instantiate(clonageObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 5)
            {
                GameObject cloneAmelioration = Instantiate(dashRapideObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
        }
        else if (!tripleSaut.enPossesion && !doubleDash.enPossesion && !attaqueTornade.enPossesion && clonage.enPossesion && !dashRapide.enPossesion && !ralentiTemps.enPossesion)
        {
            int nbrRandom = UnityEngine.Random.Range(1, 6);

            if (nbrRandom == 1)
            {
                GameObject cloneAmelioration = Instantiate(tripleSautObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 2)
            {
                GameObject cloneAmelioration = Instantiate(doubleDashObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 3)
            {
                GameObject cloneAmelioration = Instantiate(attaqueTornadeObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 4)
            {
                GameObject cloneAmelioration = Instantiate(ralentiTempsObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 5)
            {
                GameObject cloneAmelioration = Instantiate(dashRapideObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
        }
        else if (!tripleSaut.enPossesion && !doubleDash.enPossesion && !attaqueTornade.enPossesion && !clonage.enPossesion && dashRapide.enPossesion && !ralentiTemps.enPossesion)
        {
            int nbrRandom = UnityEngine.Random.Range(1, 6);

            if (nbrRandom == 1)
            {
                GameObject cloneAmelioration = Instantiate(tripleSautObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 2)
            {
                GameObject cloneAmelioration = Instantiate(doubleDashObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 3)
            {
                GameObject cloneAmelioration = Instantiate(attaqueTornadeObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 4)
            {
                GameObject cloneAmelioration = Instantiate(clonageObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 5)
            {
                GameObject cloneAmelioration = Instantiate(ralentiTempsObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
        }
        else if (!tripleSaut.enPossesion && !doubleDash.enPossesion && !attaqueTornade.enPossesion && !clonage.enPossesion && !dashRapide.enPossesion && ralentiTemps.enPossesion)
        {
            int nbrRandom = UnityEngine.Random.Range(1, 6);

            if (nbrRandom == 1)
            {
                GameObject cloneAmelioration = Instantiate(tripleSautObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 2)
            {
                GameObject cloneAmelioration = Instantiate(doubleDashObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 3)
            {
                GameObject cloneAmelioration = Instantiate(attaqueTornadeObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 4)
            {
                GameObject cloneAmelioration = Instantiate(clonageObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 5)
            {
                GameObject cloneAmelioration = Instantiate(dashRapideObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
        }
        else if (tripleSaut.enPossesion && doubleDash.enPossesion && !attaqueTornade.enPossesion && !clonage.enPossesion && !dashRapide.enPossesion && !ralentiTemps.enPossesion)
        {
            int nbrRandom = UnityEngine.Random.Range(1, 5);

            if (nbrRandom == 1)
            {
                GameObject cloneAmelioration = Instantiate(dashRapideObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 2)
            {
                GameObject cloneAmelioration = Instantiate(ralentiTempsObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 3)
            {
                GameObject cloneAmelioration = Instantiate(attaqueTornadeObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 4)
            {
                GameObject cloneAmelioration = Instantiate(clonageObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
        }
        else if (tripleSaut.enPossesion && !doubleDash.enPossesion && attaqueTornade.enPossesion && !clonage.enPossesion && !dashRapide.enPossesion && !ralentiTemps.enPossesion)
        {
            int nbrRandom = UnityEngine.Random.Range(1, 5);

            if (nbrRandom == 1)
            {
                GameObject cloneAmelioration = Instantiate(dashRapideObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 2)
            {
                GameObject cloneAmelioration = Instantiate(doubleDashObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 3)
            {
                GameObject cloneAmelioration = Instantiate(ralentiTempsObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 4)
            {
                GameObject cloneAmelioration = Instantiate(clonageObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
        }
        else if (tripleSaut.enPossesion && !doubleDash.enPossesion && !attaqueTornade.enPossesion && clonage.enPossesion && !dashRapide.enPossesion && !ralentiTemps.enPossesion)
        {
            int nbrRandom = UnityEngine.Random.Range(1, 5);

            if (nbrRandom == 1)
            {
                GameObject cloneAmelioration = Instantiate(dashRapideObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 2)
            {
                GameObject cloneAmelioration = Instantiate(doubleDashObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 3)
            {
                GameObject cloneAmelioration = Instantiate(attaqueTornadeObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 4)
            {
                GameObject cloneAmelioration = Instantiate(ralentiTempsObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
        }
        else if (tripleSaut.enPossesion && !doubleDash.enPossesion && !attaqueTornade.enPossesion && !clonage.enPossesion && dashRapide.enPossesion && !ralentiTemps.enPossesion)
        {
            int nbrRandom = UnityEngine.Random.Range(1, 5);

            if (nbrRandom == 1)
            {
                GameObject cloneAmelioration = Instantiate(ralentiTempsObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 2)
            {
                GameObject cloneAmelioration = Instantiate(doubleDashObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 3)
            {
                GameObject cloneAmelioration = Instantiate(attaqueTornadeObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 4)
            {
                GameObject cloneAmelioration = Instantiate(clonageObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
        }
        else if (tripleSaut.enPossesion && !doubleDash.enPossesion && !attaqueTornade.enPossesion && !clonage.enPossesion && !dashRapide.enPossesion && ralentiTemps.enPossesion)
        {
            int nbrRandom = UnityEngine.Random.Range(1, 5);

            if (nbrRandom == 1)
            {
                GameObject cloneAmelioration = Instantiate(dashRapideObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 2)
            {
                GameObject cloneAmelioration = Instantiate(doubleDashObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 3)
            {
                GameObject cloneAmelioration = Instantiate(attaqueTornadeObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 4)
            {
                GameObject cloneAmelioration = Instantiate(clonageObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
        }
        else if (!tripleSaut.enPossesion && doubleDash.enPossesion && attaqueTornade.enPossesion && !clonage.enPossesion && !dashRapide.enPossesion && !ralentiTemps.enPossesion)
        {
            int nbrRandom = UnityEngine.Random.Range(1, 5);

            if (nbrRandom == 1)
            {
                GameObject cloneAmelioration = Instantiate(tripleSautObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 2)
            {
                GameObject cloneAmelioration = Instantiate(dashRapideObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 3)
            {
                GameObject cloneAmelioration = Instantiate(ralentiTempsObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 4)
            {
                GameObject cloneAmelioration = Instantiate(clonageObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
        }
        else if (!tripleSaut.enPossesion && doubleDash.enPossesion && !attaqueTornade.enPossesion && clonage.enPossesion && !dashRapide.enPossesion && !ralentiTemps.enPossesion)
        {
            int nbrRandom = UnityEngine.Random.Range(1, 5);

            if (nbrRandom == 1)
            {
                GameObject cloneAmelioration = Instantiate(tripleSautObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 2)
            {
                GameObject cloneAmelioration = Instantiate(dashRapideObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 3)
            {
                GameObject cloneAmelioration = Instantiate(attaqueTornadeObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 4)
            {
                GameObject cloneAmelioration = Instantiate(ralentiTempsObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
        }
        else if (!tripleSaut.enPossesion && doubleDash.enPossesion && !attaqueTornade.enPossesion && !clonage.enPossesion && dashRapide.enPossesion && !ralentiTemps.enPossesion)
        {
            int nbrRandom = UnityEngine.Random.Range(1, 5);

            if (nbrRandom == 1)
            {
                GameObject cloneAmelioration = Instantiate(tripleSautObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 2)
            {
                GameObject cloneAmelioration = Instantiate(ralentiTempsObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 3)
            {
                GameObject cloneAmelioration = Instantiate(attaqueTornadeObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 4)
            {
                GameObject cloneAmelioration = Instantiate(clonageObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
        }
        else if (!tripleSaut.enPossesion && doubleDash.enPossesion && !attaqueTornade.enPossesion && !clonage.enPossesion && !dashRapide.enPossesion && ralentiTemps.enPossesion)
        {
            int nbrRandom = UnityEngine.Random.Range(1, 5);

            if (nbrRandom == 1)
            {
                GameObject cloneAmelioration = Instantiate(tripleSautObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 2)
            {
                GameObject cloneAmelioration = Instantiate(dashRapideObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 3)
            {
                GameObject cloneAmelioration = Instantiate(attaqueTornadeObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 4)
            {
                GameObject cloneAmelioration = Instantiate(clonageObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
        }
        else if (!tripleSaut.enPossesion && !doubleDash.enPossesion && attaqueTornade.enPossesion && clonage.enPossesion && !dashRapide.enPossesion && !ralentiTemps.enPossesion)
        {
            int nbrRandom = UnityEngine.Random.Range(1, 5);

            if (nbrRandom == 1)
            {
                GameObject cloneAmelioration = Instantiate(tripleSautObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 2)
            {
                GameObject cloneAmelioration = Instantiate(doubleDashObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 3)
            {
                GameObject cloneAmelioration = Instantiate(dashRapideObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 4)
            {
                GameObject cloneAmelioration = Instantiate(ralentiTempsObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
        }
        else if (!tripleSaut.enPossesion && !doubleDash.enPossesion && attaqueTornade.enPossesion && !clonage.enPossesion && dashRapide.enPossesion && !ralentiTemps.enPossesion)
        {
            int nbrRandom = UnityEngine.Random.Range(1, 5);

            if (nbrRandom == 1)
            {
                GameObject cloneAmelioration = Instantiate(tripleSautObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 2)
            {
                GameObject cloneAmelioration = Instantiate(doubleDashObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 3)
            {
                GameObject cloneAmelioration = Instantiate(ralentiTempsObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 4)
            {
                GameObject cloneAmelioration = Instantiate(clonageObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
        }
        else if (!tripleSaut.enPossesion && !doubleDash.enPossesion && attaqueTornade.enPossesion && !clonage.enPossesion && !dashRapide.enPossesion && ralentiTemps.enPossesion)
        {
            int nbrRandom = UnityEngine.Random.Range(1, 5);

            if (nbrRandom == 1)
            {
                GameObject cloneAmelioration = Instantiate(tripleSautObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 2)
            {
                GameObject cloneAmelioration = Instantiate(doubleDashObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 3)
            {
                GameObject cloneAmelioration = Instantiate(dashRapideObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 4)
            {
                GameObject cloneAmelioration = Instantiate(clonageObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
        }
        else if (!tripleSaut.enPossesion && !doubleDash.enPossesion && !attaqueTornade.enPossesion && clonage.enPossesion && dashRapide.enPossesion && !ralentiTemps.enPossesion)
        {
            int nbrRandom = UnityEngine.Random.Range(1, 5);

            if (nbrRandom == 1)
            {
                GameObject cloneAmelioration = Instantiate(tripleSautObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 2)
            {
                GameObject cloneAmelioration = Instantiate(doubleDashObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 3)
            {
                GameObject cloneAmelioration = Instantiate(attaqueTornadeObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 4)
            {
                GameObject cloneAmelioration = Instantiate(ralentiTempsObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
        }
        else if (!tripleSaut.enPossesion && !doubleDash.enPossesion && !attaqueTornade.enPossesion && clonage.enPossesion && !dashRapide.enPossesion && ralentiTemps.enPossesion)
        {
            int nbrRandom = UnityEngine.Random.Range(1, 5);

            if (nbrRandom == 1)
            {
                GameObject cloneAmelioration = Instantiate(tripleSautObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 2)
            {
                GameObject cloneAmelioration = Instantiate(doubleDashObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 3)
            {
                GameObject cloneAmelioration = Instantiate(attaqueTornadeObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 4)
            {
                GameObject cloneAmelioration = Instantiate(dashRapideObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
        }
        else if (!tripleSaut.enPossesion && !doubleDash.enPossesion && !attaqueTornade.enPossesion && !clonage.enPossesion && dashRapide.enPossesion && ralentiTemps.enPossesion)
        {
            int nbrRandom = UnityEngine.Random.Range(1, 5);

            if (nbrRandom == 1)
            {
                GameObject cloneAmelioration = Instantiate(tripleSautObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 2)
            {
                GameObject cloneAmelioration = Instantiate(doubleDashObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 3)
            {
                GameObject cloneAmelioration = Instantiate(attaqueTornadeObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 4)
            {
                GameObject cloneAmelioration = Instantiate(clonageObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
        }
        else if (tripleSaut.enPossesion && doubleDash.enPossesion && attaqueTornade.enPossesion && !clonage.enPossesion && !dashRapide.enPossesion && !ralentiTemps.enPossesion)
        {
            int nbrRandom = UnityEngine.Random.Range(1, 4);

            if (nbrRandom == 1)
            {
                GameObject cloneAmelioration = Instantiate(clonageObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 2)
            {
                GameObject cloneAmelioration = Instantiate(dashRapideObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 3)
            {
                GameObject cloneAmelioration = Instantiate(ralentiTempsObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
        }
        else if (tripleSaut.enPossesion && doubleDash.enPossesion && !attaqueTornade.enPossesion && clonage.enPossesion && !dashRapide.enPossesion && !ralentiTemps.enPossesion)
        {
            int nbrRandom = UnityEngine.Random.Range(1, 4);

            if (nbrRandom == 1)
            {
                GameObject cloneAmelioration = Instantiate(dashRapideObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 2)
            {
                GameObject cloneAmelioration = Instantiate(ralentiTempsObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 3)
            {
                GameObject cloneAmelioration = Instantiate(attaqueTornadeObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
        }
        else if (tripleSaut.enPossesion && doubleDash.enPossesion && !attaqueTornade.enPossesion && !clonage.enPossesion && dashRapide.enPossesion && !ralentiTemps.enPossesion)
        {
            int nbrRandom = UnityEngine.Random.Range(1, 4);

            if (nbrRandom == 1)
            {
                GameObject cloneAmelioration = Instantiate(clonageObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 2)
            {
                GameObject cloneAmelioration = Instantiate(ralentiTempsObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 3)
            {
                GameObject cloneAmelioration = Instantiate(attaqueTornadeObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
        }
        else if (tripleSaut.enPossesion && doubleDash.enPossesion && !attaqueTornade.enPossesion && !clonage.enPossesion && !dashRapide.enPossesion && ralentiTemps.enPossesion)
        {
            int nbrRandom = UnityEngine.Random.Range(1, 4);

            if (nbrRandom == 1)
            {
                GameObject cloneAmelioration = Instantiate(clonageObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 2)
            {
                GameObject cloneAmelioration = Instantiate(dashRapideObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 3)
            {
                GameObject cloneAmelioration = Instantiate(attaqueTornadeObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
        }
        else if (tripleSaut.enPossesion && !doubleDash.enPossesion && attaqueTornade.enPossesion && clonage.enPossesion && !dashRapide.enPossesion && !ralentiTemps.enPossesion)
        {
            int nbrRandom = UnityEngine.Random.Range(1, 4);

            if (nbrRandom == 1)
            {
                GameObject cloneAmelioration = Instantiate(dashRapideObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 2)
            {
                GameObject cloneAmelioration = Instantiate(doubleDashObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 3)
            {
                GameObject cloneAmelioration = Instantiate(ralentiTempsObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
        }
        else if (tripleSaut.enPossesion && !doubleDash.enPossesion && attaqueTornade.enPossesion && !clonage.enPossesion && dashRapide.enPossesion && !ralentiTemps.enPossesion)
        {
            int nbrRandom = UnityEngine.Random.Range(1, 4);

            if (nbrRandom == 1)
            {
                GameObject cloneAmelioration = Instantiate(clonageObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 2)
            {
                GameObject cloneAmelioration = Instantiate(doubleDashObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 3)
            {
                GameObject cloneAmelioration = Instantiate(ralentiTempsObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
        }
        else if (tripleSaut.enPossesion && !doubleDash.enPossesion && attaqueTornade.enPossesion && !clonage.enPossesion && !dashRapide.enPossesion && ralentiTemps.enPossesion)
        {
            int nbrRandom = UnityEngine.Random.Range(1, 4);

            if (nbrRandom == 1)
            {
                GameObject cloneAmelioration = Instantiate(clonageObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 2)
            {
                GameObject cloneAmelioration = Instantiate(doubleDashObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 3)
            {
                GameObject cloneAmelioration = Instantiate(dashRapideObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
        }
        else if (tripleSaut.enPossesion && !doubleDash.enPossesion && !attaqueTornade.enPossesion && clonage.enPossesion && dashRapide.enPossesion && !ralentiTemps.enPossesion)
        {
            int nbrRandom = UnityEngine.Random.Range(1, 4);

            if (nbrRandom == 1)
            {
                GameObject cloneAmelioration = Instantiate(ralentiTempsObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 2)
            {
                GameObject cloneAmelioration = Instantiate(doubleDashObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 3)
            {
                GameObject cloneAmelioration = Instantiate(attaqueTornadeObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
        }
        else if (tripleSaut.enPossesion && !doubleDash.enPossesion && !attaqueTornade.enPossesion && clonage.enPossesion && !dashRapide.enPossesion && ralentiTemps.enPossesion)
        {
            int nbrRandom = UnityEngine.Random.Range(1, 4);

            if (nbrRandom == 1)
            {
                GameObject cloneAmelioration = Instantiate(dashRapideObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 2)
            {
                GameObject cloneAmelioration = Instantiate(doubleDashObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 3)
            {
                GameObject cloneAmelioration = Instantiate(attaqueTornadeObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
        }
        else if (tripleSaut.enPossesion && !doubleDash.enPossesion && !attaqueTornade.enPossesion && !clonage.enPossesion && dashRapide.enPossesion && ralentiTemps.enPossesion)
        {
            int nbrRandom = UnityEngine.Random.Range(1, 4);

            if (nbrRandom == 1)
            {
                GameObject cloneAmelioration = Instantiate(clonageObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 2)
            {
                GameObject cloneAmelioration = Instantiate(doubleDashObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 3)
            {
                GameObject cloneAmelioration = Instantiate(attaqueTornadeObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
        }
        else if (!tripleSaut.enPossesion && doubleDash.enPossesion && attaqueTornade.enPossesion && clonage.enPossesion && !dashRapide.enPossesion && !ralentiTemps.enPossesion)
        {
            int nbrRandom = UnityEngine.Random.Range(1, 4);

            if (nbrRandom == 1)
            {
                GameObject cloneAmelioration = Instantiate(tripleSautObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 2)
            {
                GameObject cloneAmelioration = Instantiate(dashRapideObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 3)
            {
                GameObject cloneAmelioration = Instantiate(ralentiTempsObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
        }
        else if (!tripleSaut.enPossesion && doubleDash.enPossesion && attaqueTornade.enPossesion && !clonage.enPossesion && dashRapide.enPossesion && !ralentiTemps.enPossesion)
        {
            int nbrRandom = UnityEngine.Random.Range(1, 4);

            if (nbrRandom == 1)
            {
                GameObject cloneAmelioration = Instantiate(tripleSautObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 2)
            {
                GameObject cloneAmelioration = Instantiate(clonageObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 3)
            {
                GameObject cloneAmelioration = Instantiate(ralentiTempsObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
        }
        else if (!tripleSaut.enPossesion && doubleDash.enPossesion && attaqueTornade.enPossesion && !clonage.enPossesion && !dashRapide.enPossesion && ralentiTemps.enPossesion)
        {
            int nbrRandom = UnityEngine.Random.Range(1, 4);

            if (nbrRandom == 1)
            {
                GameObject cloneAmelioration = Instantiate(tripleSautObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 2)
            {
                GameObject cloneAmelioration = Instantiate(clonageObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 3)
            {
                GameObject cloneAmelioration = Instantiate(dashRapideObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
        }
        else if (!tripleSaut.enPossesion && doubleDash.enPossesion && !attaqueTornade.enPossesion && clonage.enPossesion && dashRapide.enPossesion && !ralentiTemps.enPossesion)
        {
            int nbrRandom = UnityEngine.Random.Range(1, 4);

            if (nbrRandom == 1)
            {
                GameObject cloneAmelioration = Instantiate(tripleSautObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 2)
            {
                GameObject cloneAmelioration = Instantiate(ralentiTempsObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 3)
            {
                GameObject cloneAmelioration = Instantiate(attaqueTornadeObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
        }
        else if (!tripleSaut.enPossesion && doubleDash.enPossesion && !attaqueTornade.enPossesion && clonage.enPossesion && !dashRapide.enPossesion && ralentiTemps.enPossesion)
        {
            int nbrRandom = UnityEngine.Random.Range(1, 4);

            if (nbrRandom == 1)
            {
                GameObject cloneAmelioration = Instantiate(tripleSautObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 2)
            {
                GameObject cloneAmelioration = Instantiate(dashRapideObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 3)
            {
                GameObject cloneAmelioration = Instantiate(attaqueTornadeObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
        }
        else if (!tripleSaut.enPossesion && doubleDash.enPossesion && !attaqueTornade.enPossesion && !clonage.enPossesion && dashRapide.enPossesion && ralentiTemps.enPossesion)
        {
            int nbrRandom = UnityEngine.Random.Range(1, 4);

            if (nbrRandom == 1)
            {
                GameObject cloneAmelioration = Instantiate(tripleSautObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 2)
            {
                GameObject cloneAmelioration = Instantiate(clonageObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 3)
            {
                GameObject cloneAmelioration = Instantiate(attaqueTornadeObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
        }
        else if (!tripleSaut.enPossesion && !doubleDash.enPossesion && attaqueTornade.enPossesion && clonage.enPossesion && dashRapide.enPossesion && !ralentiTemps.enPossesion)
        {
            int nbrRandom = UnityEngine.Random.Range(1, 4);

            if (nbrRandom == 1)
            {
                GameObject cloneAmelioration = Instantiate(tripleSautObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 2)
            {
                GameObject cloneAmelioration = Instantiate(doubleDashObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 3)
            {
                GameObject cloneAmelioration = Instantiate(ralentiTempsObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
        }
        else if (!tripleSaut.enPossesion && !doubleDash.enPossesion && attaqueTornade.enPossesion && clonage.enPossesion && !dashRapide.enPossesion && ralentiTemps.enPossesion)
        {
            int nbrRandom = UnityEngine.Random.Range(1, 4);

            if (nbrRandom == 1)
            {
                GameObject cloneAmelioration = Instantiate(tripleSautObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 2)
            {
                GameObject cloneAmelioration = Instantiate(doubleDashObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 3)
            {
                GameObject cloneAmelioration = Instantiate(dashRapideObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
        }
        else if (!tripleSaut.enPossesion && !doubleDash.enPossesion && attaqueTornade.enPossesion && !clonage.enPossesion && dashRapide.enPossesion && ralentiTemps.enPossesion)
        {
            int nbrRandom = UnityEngine.Random.Range(1, 4);

            if (nbrRandom == 1)
            {
                GameObject cloneAmelioration = Instantiate(tripleSautObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 2)
            {
                GameObject cloneAmelioration = Instantiate(doubleDashObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 3)
            {
                GameObject cloneAmelioration = Instantiate(clonageObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
        }
        else if (!tripleSaut.enPossesion && !doubleDash.enPossesion && !attaqueTornade.enPossesion && clonage.enPossesion && dashRapide.enPossesion && ralentiTemps.enPossesion)
        {
            int nbrRandom = UnityEngine.Random.Range(1, 4);

            if (nbrRandom == 1)
            {
                GameObject cloneAmelioration = Instantiate(tripleSautObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 2)
            {
                GameObject cloneAmelioration = Instantiate(doubleDashObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 3)
            {
                GameObject cloneAmelioration = Instantiate(attaqueTornadeObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
        }
        else if (!tripleSaut.enPossesion && !doubleDash.enPossesion && attaqueTornade.enPossesion && clonage.enPossesion && dashRapide.enPossesion && ralentiTemps.enPossesion)
        {
            int nbrRandom = UnityEngine.Random.Range(1, 3);

            if (nbrRandom == 1)
            {
                GameObject cloneAmelioration = Instantiate(tripleSautObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 2)
            {
                GameObject cloneAmelioration = Instantiate(doubleDashObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
        }
        else if (!tripleSaut.enPossesion && doubleDash.enPossesion && !attaqueTornade.enPossesion && clonage.enPossesion && dashRapide.enPossesion && ralentiTemps.enPossesion)
        {
            int nbrRandom = UnityEngine.Random.Range(1, 3);

            if (nbrRandom == 1)
            {
                GameObject cloneAmelioration = Instantiate(tripleSautObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 2)
            {
                GameObject cloneAmelioration = Instantiate(attaqueTornadeObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
        }
        else if (!tripleSaut.enPossesion && doubleDash.enPossesion && attaqueTornade.enPossesion && !clonage.enPossesion && dashRapide.enPossesion && ralentiTemps.enPossesion)
        {
            int nbrRandom = UnityEngine.Random.Range(1, 3);

            if (nbrRandom == 1)
            {
                GameObject cloneAmelioration = Instantiate(tripleSautObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 2)
            {
                GameObject cloneAmelioration = Instantiate(clonageObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
        }
        else if (!tripleSaut.enPossesion && doubleDash.enPossesion && attaqueTornade.enPossesion && clonage.enPossesion && !dashRapide.enPossesion && ralentiTemps.enPossesion)
        {
            int nbrRandom = UnityEngine.Random.Range(1, 3);

            if (nbrRandom == 1)
            {
                GameObject cloneAmelioration = Instantiate(tripleSautObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 2)
            {
                GameObject cloneAmelioration = Instantiate(dashRapideObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
        }
        else if (!tripleSaut.enPossesion && doubleDash.enPossesion && attaqueTornade.enPossesion && clonage.enPossesion && dashRapide.enPossesion && !ralentiTemps.enPossesion)
        {
            int nbrRandom = UnityEngine.Random.Range(1, 3);

            if (nbrRandom == 1)
            {
                GameObject cloneAmelioration = Instantiate(tripleSautObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 2)
            {
                GameObject cloneAmelioration = Instantiate(ralentiTempsObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
        }
        else if (tripleSaut.enPossesion && !doubleDash.enPossesion && !attaqueTornade.enPossesion && clonage.enPossesion && dashRapide.enPossesion && ralentiTemps.enPossesion)
        {
            int nbrRandom = UnityEngine.Random.Range(1, 3);

            if (nbrRandom == 1)
            {
                GameObject cloneAmelioration = Instantiate(attaqueTornadeObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 2)
            {
                GameObject cloneAmelioration = Instantiate(doubleDashObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
        }
        else if (tripleSaut.enPossesion && !doubleDash.enPossesion && attaqueTornade.enPossesion && !clonage.enPossesion && dashRapide.enPossesion && ralentiTemps.enPossesion)
        {
            int nbrRandom = UnityEngine.Random.Range(1, 3);

            if (nbrRandom == 1)
            {
                GameObject cloneAmelioration = Instantiate(clonageObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 2)
            {
                GameObject cloneAmelioration = Instantiate(doubleDashObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
        }
        else if (tripleSaut.enPossesion && !doubleDash.enPossesion && attaqueTornade.enPossesion && clonage.enPossesion && !dashRapide.enPossesion && ralentiTemps.enPossesion)
        {
            int nbrRandom = UnityEngine.Random.Range(1, 3);

            if (nbrRandom == 1)
            {
                GameObject cloneAmelioration = Instantiate(dashRapideObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 2)
            {
                GameObject cloneAmelioration = Instantiate(doubleDashObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
        }
        else if (tripleSaut.enPossesion && !doubleDash.enPossesion && attaqueTornade.enPossesion && clonage.enPossesion && dashRapide.enPossesion && !ralentiTemps.enPossesion)
        {
            int nbrRandom = UnityEngine.Random.Range(1, 3);

            if (nbrRandom == 1)
            {
                GameObject cloneAmelioration = Instantiate(ralentiTempsObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 2)
            {
                GameObject cloneAmelioration = Instantiate(doubleDashObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
        }
        else if (tripleSaut.enPossesion && doubleDash.enPossesion && !attaqueTornade.enPossesion && !clonage.enPossesion && dashRapide.enPossesion && ralentiTemps.enPossesion)
        {
            int nbrRandom = UnityEngine.Random.Range(1, 3);

            if (nbrRandom == 1)
            {
                GameObject cloneAmelioration = Instantiate(attaqueTornadeObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 2)
            {
                GameObject cloneAmelioration = Instantiate(clonageObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
        }
        else if (tripleSaut.enPossesion && doubleDash.enPossesion && !attaqueTornade.enPossesion && clonage.enPossesion && !dashRapide.enPossesion && ralentiTemps.enPossesion)
        {
            int nbrRandom = UnityEngine.Random.Range(1, 3);

            if (nbrRandom == 1)
            {
                GameObject cloneAmelioration = Instantiate(attaqueTornadeObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 2)
            {
                GameObject cloneAmelioration = Instantiate(dashRapideObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
        }
        else if (tripleSaut.enPossesion && doubleDash.enPossesion && !attaqueTornade.enPossesion && clonage.enPossesion && dashRapide.enPossesion && !ralentiTemps.enPossesion)
        {
            int nbrRandom = UnityEngine.Random.Range(1, 3);

            if (nbrRandom == 1)
            {
                GameObject cloneAmelioration = Instantiate(attaqueTornadeObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 2)
            {
                GameObject cloneAmelioration = Instantiate(ralentiTempsObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
        }
        else if (tripleSaut.enPossesion && doubleDash.enPossesion && attaqueTornade.enPossesion && !clonage.enPossesion && !dashRapide.enPossesion && ralentiTemps.enPossesion)
        {
            int nbrRandom = UnityEngine.Random.Range(1, 3);

            if (nbrRandom == 1)
            {
                GameObject cloneAmelioration = Instantiate(clonageObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 2)
            {
                GameObject cloneAmelioration = Instantiate(dashRapideObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
        }
        else if (tripleSaut.enPossesion && doubleDash.enPossesion && attaqueTornade.enPossesion && !clonage.enPossesion && dashRapide.enPossesion && !ralentiTemps.enPossesion)
        {
            int nbrRandom = UnityEngine.Random.Range(1, 3);

            if (nbrRandom == 1)
            {
                GameObject cloneAmelioration = Instantiate(clonageObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 2)
            {
                GameObject cloneAmelioration = Instantiate(ralentiTempsObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
        }
        else if (tripleSaut.enPossesion && doubleDash.enPossesion && attaqueTornade.enPossesion && clonage.enPossesion && !dashRapide.enPossesion && !ralentiTemps.enPossesion)
        {
            int nbrRandom = UnityEngine.Random.Range(1, 3);

            if (nbrRandom == 1)
            {
                GameObject cloneAmelioration = Instantiate(dashRapideObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
            else if (nbrRandom == 2)
            {
                GameObject cloneAmelioration = Instantiate(ralentiTempsObj, parentClone.transform.position, parentClone.transform.rotation);
                cloneAmelioration.SetActive(true);
            }
        }
        else if (!tripleSaut.enPossesion && doubleDash.enPossesion && attaqueTornade.enPossesion && clonage.enPossesion && dashRapide.enPossesion && ralentiTemps.enPossesion)
        {
            GameObject cloneAmelioration = Instantiate(tripleSautObj, parentClone.transform.position, parentClone.transform.rotation);
            cloneAmelioration.SetActive(true);
        }
        else if (tripleSaut.enPossesion && !doubleDash.enPossesion && attaqueTornade.enPossesion && clonage.enPossesion && dashRapide.enPossesion && ralentiTemps.enPossesion)
        {
            GameObject cloneAmelioration = Instantiate(doubleDashObj, parentClone.transform.position, parentClone.transform.rotation);
            cloneAmelioration.SetActive(true);
        }
        else if (tripleSaut.enPossesion && doubleDash.enPossesion && !attaqueTornade.enPossesion && clonage.enPossesion && dashRapide.enPossesion && ralentiTemps.enPossesion)
        {
            GameObject cloneAmelioration = Instantiate(attaqueTornadeObj, parentClone.transform.position, parentClone.transform.rotation);
            cloneAmelioration.SetActive(true);
        }
        else if (tripleSaut.enPossesion && doubleDash.enPossesion && attaqueTornade.enPossesion && !clonage.enPossesion && dashRapide.enPossesion && ralentiTemps.enPossesion)
        {
            GameObject cloneAmelioration = Instantiate(clonageObj, parentClone.transform.position, parentClone.transform.rotation);
            cloneAmelioration.SetActive(true);
        }
        else if (tripleSaut.enPossesion && doubleDash.enPossesion && attaqueTornade.enPossesion && clonage.enPossesion && !dashRapide.enPossesion && ralentiTemps.enPossesion)
        {
            GameObject cloneAmelioration = Instantiate(dashRapideObj, parentClone.transform.position, parentClone.transform.rotation);
            cloneAmelioration.SetActive(true);
        }
        else if (tripleSaut.enPossesion && doubleDash.enPossesion && attaqueTornade.enPossesion && clonage.enPossesion && dashRapide.enPossesion && !ralentiTemps.enPossesion)
        {
            GameObject cloneAmelioration = Instantiate(ralentiTempsObj, parentClone.transform.position, parentClone.transform.rotation);
            cloneAmelioration.SetActive(true);
        }
    }
}
