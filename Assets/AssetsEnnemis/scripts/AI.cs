using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    public NavMeshAgent ennemie;
    GameObject joueur;
    public GameObject hitbox;
    public GameObject nav;
    public GameObject gestionMusique;
    public AudioClip bruitMonstre;
    public bool trouverPerso;
    public bool attEnCours;
    public bool etatMort;

    float distanceStop;
    Vector3 v3RayDirection;

    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        etatMort = false;
        trouverPerso = false;
        distanceStop = ennemie.stoppingDistance;
        joueur = GameObject.Find("perso");
        gestionMusique = GameObject.Find("gestionMusique");
    }

    // Update is called once per frame
    void Update()
    {
        if (!etatMort)
        {
            if (Physics.Linecast(transform.position, joueur.transform.position, out RaycastHit hitInfo))
            {
                if (hitInfo.collider.tag == "perso" && trouverPerso == true)
                {
                    ennemie.SetDestination(joueur.transform.position);
                    ennemie.speed = 10f;
                    ennemie.angularSpeed = 1000f;
                    animator.SetBool("cours", true);
                }
                else
                {
                    if (ennemie.pathPending || !ennemie.isOnNavMesh || ennemie.remainingDistance > distanceStop + 0.1f)
                        return;

                    trouverNouvelleDest();
                    ennemie.speed = 4f;
                    ennemie.angularSpeed = 300f;
                    animator.SetBool("marche", true);
                }

                if (ennemie.remainingDistance <= distanceStop && trouverPerso == true && attEnCours == false)
                {
                    attEnCours = true;
                    hitbox.GetComponent<hitbox>().aPerduVie = false;
                    animator.SetBool("attaque", true);
                    ennemie.speed = 0f;
                    gameObject.GetComponent<AudioSource>().PlayOneShot(bruitMonstre);
                    Invoke("cancelAttaque", 1.5f);
                    Invoke("actionAttaque", 5f);
                }
            }

            if (trouverPerso)
            {
                ennemie.transform.LookAt(new Vector3(joueur.transform.position.x, ennemie.transform.position.y, joueur.transform.position.z));
            }

            //if (animator.GetBool("attaque") == true && animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.4f && animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 0.65f)
            //{
            //    hitbox.SetActive(true);
            //}
            //else
            //{
            //    hitbox.SetActive(false);
            //}
        }
        

        v3RayDirection = joueur.transform.position - ennemie.transform.position;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.name == "persoObj")
        {
            if (!gestionMusique.GetComponent<gestionMusique>().sourceMusiqueEnnemi.isPlaying)
            {
                gestionMusique.GetComponent<gestionMusique>().jouerMusiqueEnnemi();
            } 
            trouverPerso = true;
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        if(collision.name == "persoObj")
        {
            CancelInvoke("perduPerso");
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.name == "persoObj")
        {
            Invoke("perduPerso", 5f);
        }
    }

    void perduPerso()
    {
        trouverPerso = false;
        animator.SetBool("cours", false);
        ennemie.destination = ennemie.transform.position;
        trouverNouvelleDest();
        gestionMusique.GetComponent<gestionMusique>().arreterMusiqueEnnemi();
    }

    private void actionAttaque()
    {
        attEnCours = false;
    }

    private void cancelAttaque()
    {
        animator.SetBool("attaque", false);
    }

    public void trouverNouvelleDest()
    {
        Vector3 randomDirection = Random.insideUnitSphere * 100f;
        randomDirection += transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, 100f, 1);
        Vector3 finalPosition = hit.position;
        ennemie.destination = finalPosition;
    }

    public void mort()
    {
        etatMort = true;
        ennemie.enabled = false;
        animator.SetBool("mort", true);
        gestionMusique.GetComponent<gestionMusique>().arreterMusiqueEnnemi();
        Invoke("detruire", 10f);
    }

    private void detruire()
    {
        Destroy(gameObject);
        //Destroy(nav);
    }
}
