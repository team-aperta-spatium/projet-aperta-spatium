using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class aiChevre : MonoBehaviour
{
    public NavMeshAgent ennemie;
    public GameObject joueur;
    public GameObject hitboxAttaque;
    public Animator animator;

    public bool trouverPerso;
    public bool attaquer;
    public bool hit;
    public bool confu;
    public bool etatMort;

    private bool setDirection;
    private Vector3 direction;
    
    void Start()
    {
        trouverPerso = false;
        attaquer = false;
        setDirection = false;
    }

    void Update()
    {
        if (!confu)
        {
            ennemie.isStopped = false;
            if (!trouverPerso)
            {
                if (ennemie.pathPending || !ennemie.isOnNavMesh || ennemie.remainingDistance > 0.1f)
                    return;
                trouverNouvelleDest();
            }
            else if(trouverPerso && !attaquer)
            {
                ennemie.destination = ennemie.transform.position;
                ennemie.transform.LookAt(new Vector3(joueur.transform.position.x, 0, joueur.transform.position.z));
                setDirection = false;
            }
            else if(trouverPerso && attaquer)
            {
                if (!setDirection)
                {
                    direction = ennemie.transform.forward;
                    setDirection = true;
                }
                ennemie.updateRotation = false;
                ennemie.Move(direction/8f);
            }
        }
        else
        {
            ennemie.isStopped = true;
            animator.SetBool("trouverPerso", true);
        }

        if (attaquer && !confu)
        {
            hitboxAttaque.SetActive(true);
        }
        else
        {
            hitboxAttaque.SetActive(false);
        }
    }


    private void OnTriggerStay(Collider collision)
    {
        if (collision.tag == "perso")
        {   
            trouverPerso = true;
            animator.SetBool("trouverPerso", true);
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.tag == "perso")
        {
            animator.SetBool("trouverPerso", false);
            trouverPerso = false;
            attaquer = false;
            setDirection = false;
        }
    }

    public void trouverNouvelleDest()
    {
        Vector3 randomDirection = Random.insideUnitSphere * 50f;
        randomDirection += transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, 100f, 1);
        Vector3 finalPosition = hit.position;
        ennemie.destination = finalPosition;
    }

    public void annuleConfu()
    {
        ennemie.updateRotation = true;
        ennemie.transform.LookAt(new Vector3(joueur.transform.position.x, 0, joueur.transform.position.z));
        setDirection = false;
        confu = false;
    }

    public void setAttaque()
    {
        animator.SetTrigger("preAttaque");
        Invoke("attaque", 1f);
    }

    public void attaque()
    {
        animator.SetBool("Attaque", true);
        attaquer = true;
    }

    public void mort()
    {
        animator.SetTrigger("morty");
        etatMort = true;
        Destroy(gameObject);
    }
}
