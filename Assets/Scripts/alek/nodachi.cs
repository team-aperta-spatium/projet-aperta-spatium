using UnityEngine;

public class nodachi : MonoBehaviour
{
    public float tempCdAttaque;
    public inventaire equipementAttaque;
    public GameObject gestionMusique;

    bool attaque1EnCours;
    bool attaque2EnCours;
    bool attaque3EnCours;
    bool attaqueNormale;
    bool attaqueLourd1EnCours;
    bool attaqueLourd2EnCours;
    bool attaqueLourde;
    bool attaque2EnAttente;
    bool attaque3EnAttente;
    bool attaqueLourd2EnAttente;
    bool attaqueSpecialePrep;
    bool attaqueSpeciale1;
    bool attaqueSpeciale2;
    bool attaqueSpeciale1EnAttente;
    bool attaqueSpeciale2EnAttente;
    bool attaqueSpeciale;
    bool attaqueEquipementPrep;
    bool attaqueEquipement;
    bool enPause;

    float timerAttaque1;
    float timerAttaque2;
    float timerAttaqueLourd1;
    float timerAttaqueSpecialePrep;
    float cdAttaque;
    float dmgNormal;
    float dmgLourd;
    float dmgSpeciale;
    float dmgEquipement;

    // Start is called before the first frame update
    void Start()
    {
        gestionMusique = GameObject.Find("gestionMusique");

        attaque1EnCours = false;
        attaque2EnCours = false;
        attaque3EnCours = false;
        attaqueNormale = false;
        attaqueLourd1EnCours = false;
        attaqueLourd2EnCours = false;
        attaqueLourde = false;
        attaque2EnAttente = false;
        attaque3EnAttente = false;
        attaqueLourd2EnAttente = false;
        attaqueSpecialePrep = false;
        attaqueSpeciale1 = false;
        attaqueSpeciale2 = false;
        attaqueSpeciale1EnAttente = false;
        attaqueSpeciale2EnAttente = false;
        attaqueSpeciale = false;
        cdAttaque = 0;

        dmgNormal = 34;
        dmgLourd = 50;
        dmgSpeciale = 100;
        dmgEquipement = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !enPause)
        {
            enPause = true;
        }
        else
        {
            enPause = false;
        }

        if (!enPause)
        {
            if (attaqueNormale || attaqueLourde || attaqueSpeciale || attaqueEquipement)
            {
                mouvement2.attaqueEnCours = true;
            }
            else
            {
                mouvement2.attaqueEnCours = false;
            }

            if (mouvement2.actionPossible)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    if (cdAttaque <=  0)
                    {
                        if (!attaqueSpeciale && !attaqueLourde && !attaqueEquipement)
                        {
                            if (!attaque1EnCours && !attaque2EnCours && !attaque3EnCours)
                            {
                                GetComponent<Animator>().SetBool("attaque1", true);
                                gestionMusique.GetComponent<gestionMusique>().jouerEpeeFaible();
                                Invoke("ArretAttaque1", 1f);
                                attaque1EnCours = true;
                                timerAttaque1 = 1f;
                                attaqueNormale = true;
                                mouvement2.actionEnCours = true;
                            }
                            else if (attaque1EnCours && !attaque2EnCours && !attaque3EnCours)
                            {
                                attaque2EnAttente = true;
                            }
                            else if (attaque2EnCours && !attaque3EnCours)
                            {
                                attaque3EnAttente = true;
                            }               
                            else if (attaque2EnAttente)
                            {
                                attaque3EnAttente = true;
                            }
                        }
                    }
                }
        
                if (Input.GetKeyDown(KeyCode.Mouse1))
                {
                    if (cdAttaque <= 0)
                    {
                        if (!attaqueSpeciale && !attaqueNormale && !attaqueEquipement)
                        {
                            if (!attaqueLourd1EnCours && !attaqueLourd2EnCours)
                            {
                                GetComponent<Animator>().SetBool("attaqueLourd1", true);
                                gestionMusique.GetComponent<gestionMusique>().jouerEpeeFaible();
                                Invoke("ArretAttaqueLourd1", 2.5f);
                                attaqueLourd1EnCours = true;
                                timerAttaqueLourd1 = 2.5f;
                                attaqueLourde = true;
                                mouvement2.actionEnCours = true;
                            }
                            else if (attaqueLourd1EnCours && !attaqueLourd2EnCours)
                            {
                                attaqueLourd2EnAttente = true;
                            }
                        }
                    }
                }

                if (cdAttaque <= 0)
                {   
                    if (!attaqueNormale && !attaqueLourde && !attaqueEquipement)
                    {
                        if (Input.GetKey(KeyCode.LeftAlt))
                        {
                            if (Input.GetKeyDown(KeyCode.Mouse0) && attaqueSpeciale)
                            {
                                if (timerAttaqueSpecialePrep > 0)
                                {
                                    attaqueSpeciale1EnAttente = true;
                                }
                                else
                                {
                                    Invoke("AttaqueSpeciale1", 0f);
                                    Invoke("ArretAttaqueSpeciale1", 1f);
                                }
                            }
                            else if (Input.GetKeyDown(KeyCode.Mouse1) && attaqueSpeciale)
                            {
                                if (timerAttaqueSpecialePrep > 0)
                                {
                                    attaqueSpeciale2EnAttente = true;
                                }
                                else
                                {
                                    Invoke("AttaqueSpeciale2", 0f);
                                    Invoke("ArretAttaqueSpeciale2", 1f);
                                }
                            }
                            else if (!attaqueSpeciale)
                            {
                                attaqueSpecialePrep = true;
                                GetComponent<Animator>().SetBool("attaqueSpecialePrep", true);
                                timerAttaqueSpecialePrep = 0.67f;
                                attaqueSpeciale = true;
                            }
                        }
                        else if (Input.GetKeyUp(KeyCode.LeftAlt))
                        {
                            attaqueSpecialePrep = false;
                            GetComponent<Animator>().SetBool("attaqueSpecialePrep", false);
                            timerAttaqueSpecialePrep = 0;
                            attaqueSpeciale = false;
                        }
                    }
                }

                if (cdAttaque <= 0)
                {
                    if (!attaqueSpeciale && !attaqueNormale && !attaqueLourde)
                    {
                        if (equipementAttaque.actif)
                        {
                            if (Input.GetKeyDown(KeyCode.Q))
                            {
                                attaqueEquipementPrep = true;
                                GetComponent<Animator>().SetBool("attaqueEquipementPrep", true);
                            }
                            else if (Input.GetKeyUp(KeyCode.Q))
                            {
                                attaqueEquipementPrep = false;
                                attaqueEquipement = true;
                                GetComponent<Animator>().SetBool("attaqueEquipementPrep", false);
                                GetComponent<Animator>().SetBool("attaqueEquipement", true);
                                mouvement2.actionEnCours = true;
                                gestionMusique.GetComponent<gestionMusique>().jouerEpeeFort();
                                Invoke("ArretAttaqueEquipement", 1.59f);
                            }
                        }
                    }
                }
            }

            if (attaque2EnAttente && timerAttaque1 <= 0.25f)
            {
                CancelInvoke();
                Invoke("Attaque2", 0);
                Invoke("ArretAttaque2", 1f);
            }

            if (attaque3EnAttente && timerAttaque2 <= 0.41f)
            {
                CancelInvoke();
                Invoke("Attaque3", 0);
                Invoke("ArretAttaque3", 1.5f);
            }
        
            if (attaqueLourd2EnAttente && timerAttaqueLourd1 <= 0.75f)
            {
                CancelInvoke();
                Invoke("AttaqueLourd2", 0);
                Invoke("ArretAttaqueLourd2", 1.5f);
            }

            if (attaqueSpeciale1EnAttente && timerAttaqueSpecialePrep <= 0)
            {
                Invoke("AttaqueSpeciale1", 0f);
                Invoke("ArretAttaqueSpeciale1", 1f);
            }
        
            if (attaqueSpeciale2EnAttente && timerAttaqueSpecialePrep <= 0)
            {
                Invoke("AttaqueSpeciale2", 0f);
                Invoke("ArretAttaqueSpeciale2", 1f);
            }

            if (attaque1EnCours)
            {
                timerAttaque1 -= Time.deltaTime;
            }

            if (attaque2EnCours)
            {
                timerAttaque2 -= Time.deltaTime;
            }

            if (attaqueLourd1EnCours)
            {
                timerAttaqueLourd1 -= Time.deltaTime;
            }

            if (attaqueSpecialePrep)
            {
                timerAttaqueSpecialePrep -= Time.deltaTime;
            }

            if (attaqueEquipement && Time.timeScale != 0)
            {
                mouvement2.endurance -= 0.3f;
            }

            if (cdAttaque > 0)
            {
                cdAttaque -= Time.deltaTime;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ennemi") 
        {
            if (attaqueNormale)
            {
                other.gameObject.GetComponent<vieEnnemi>().nbrVie -= dmgNormal;
            }
            else if (attaqueLourde)
            {
                other.gameObject.GetComponent<vieEnnemi>().nbrVie -= dmgLourd;
            }
            else if (attaqueSpeciale)
            {
                other.gameObject.GetComponent<vieEnnemi>().nbrVie -= dmgSpeciale;
            }
            else if (attaqueEquipement)
            {
                other.gameObject.GetComponent<vieEnnemi>().nbrVie -= dmgEquipement;
            }
        }

        if (other.gameObject.tag == "boss")
        {
            if (attaqueNormale)
            {
                other.gameObject.GetComponentInParent<comportementBoss>().nbrVies -= dmgNormal;
            }
            else if (attaqueLourde)
            {
                other.gameObject.GetComponentInParent<comportementBoss>().nbrVies -= dmgLourd;
            }
            else if (attaqueSpeciale)
            {
                other.gameObject.GetComponentInParent<comportementBoss>().nbrVies -= dmgSpeciale;
            }
            else if (attaqueEquipement)
            {
                other.gameObject.GetComponentInParent<comportementBoss>().nbrVies -= dmgEquipement;
            }
        }
    }

    void Attaque2()
    {
        GetComponent<Animator>().SetBool("attaque2", true);
        attaque2EnCours = true;
        attaque1EnCours = false;
        attaque2EnAttente = false;
        GetComponent<Animator>().SetBool("attaque1", false);
        timerAttaque2 = 1f;
        timerAttaque1 = 0f;
        mouvement2.actionEnCours = true;
        gestionMusique.GetComponent<gestionMusique>().jouerEpeeFaible();
    }

    void Attaque3()
    {
        GetComponent<Animator>().SetBool("attaque3", true);
        attaque3EnCours = true;
        attaque2EnCours = false;
        attaque3EnAttente = false;
        GetComponent<Animator>().SetBool("attaque2", false);
        timerAttaque2 = 0f;
        mouvement2.actionEnCours = true;
        gestionMusique.GetComponent<gestionMusique>().jouerEpeeFaible();
    }
    
    void AttaqueLourd2()
    {
        GetComponent<Animator>().SetBool("attaqueLourd2", true);
        attaqueLourd2EnCours = true;
        attaqueLourd1EnCours = false;
        attaqueLourd2EnAttente = false;
        GetComponent<Animator>().SetBool("attaqueLourd1", false);
        timerAttaqueLourd1 = 0f;
        mouvement2.actionEnCours = true;
        gestionMusique.GetComponent<gestionMusique>().jouerEpeeFort();
    }

    void AttaqueSpeciale1()
    {
        attaqueSpeciale1EnAttente = false;
        attaqueSpeciale1 = true;
        attaqueSpecialePrep = false;
        GetComponent<Animator>().SetBool("attaqueSpecialePrep", false);
        GetComponent<Animator>().SetBool("attaqueSpeciale1", true);
        timerAttaqueSpecialePrep = 0f;
        mouvement2.endurance -= 5;
        mouvement2.actionEnCours = true;
        gestionMusique.GetComponent<gestionMusique>().jouerEpeeFort();
    }
    
    void AttaqueSpeciale2()
    {
        attaqueSpeciale2EnAttente = false;
        attaqueSpeciale2 = true;
        attaqueSpecialePrep = false;
        GetComponent<Animator>().SetBool("attaqueSpecialePrep", false);
        GetComponent<Animator>().SetBool("attaqueSpeciale2", true);
        timerAttaqueSpecialePrep = 0f;
        mouvement2.endurance -= 5;
        mouvement2.actionEnCours = true;
        gestionMusique.GetComponent<gestionMusique>().jouerEpeeFort();
    }

    void ArretAttaque1()
    {
        GetComponent<Animator>().SetBool("attaque1", false);
        attaque1EnCours = false;
        cdAttaque = tempCdAttaque;
        attaqueNormale = false;
        mouvement2.actionEnCours = false;
    }

    void ArretAttaque2()
    {
        GetComponent<Animator>().SetBool("attaque2", false);
        attaque2EnCours = false;
        cdAttaque = tempCdAttaque;
        attaqueNormale = false;
        mouvement2.actionEnCours = false;
    }

    void ArretAttaque3()
    {
        GetComponent<Animator>().SetBool("attaque3", false);
        attaque3EnCours = false;
        cdAttaque = tempCdAttaque;
        attaqueNormale = false;
        mouvement2.actionEnCours = false;
    }

    void ArretAttaqueLourd1()
    {
        GetComponent<Animator>().SetBool("attaqueLourd1", false);
        attaqueLourd1EnCours = false;
        cdAttaque = tempCdAttaque;
        attaqueLourde = false;
        mouvement2.actionEnCours = false;
    }

    void ArretAttaqueLourd2()
    {
        GetComponent<Animator>().SetBool("attaqueLourd2", false);
        attaqueLourd2EnCours = false;
        cdAttaque = tempCdAttaque;
        attaqueLourde = false;
        mouvement2.actionEnCours = false;
    }

    void ArretAttaqueSpeciale1()
    {
        GetComponent<Animator>().SetBool("attaqueSpeciale1", false);
        attaqueSpeciale1 = false;
        cdAttaque = tempCdAttaque;
        attaqueSpeciale = false;
        mouvement2.actionEnCours = false;
    }
    
    void ArretAttaqueSpeciale2()
    {
        GetComponent<Animator>().SetBool("attaqueSpeciale2", false);
        attaqueSpeciale2 = false;
        cdAttaque = tempCdAttaque;
        attaqueSpeciale = false;
        mouvement2.actionEnCours = false;
    }

    void ArretAttaqueEquipement()
    {
        GetComponent<Animator>().SetBool("attaqueEquipement", false);
        attaqueEquipement = false;
        mouvement2.actionEnCours = false;
    }
}