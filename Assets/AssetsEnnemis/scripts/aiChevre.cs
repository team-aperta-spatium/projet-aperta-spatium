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
                ennemie.Move(direction/2);
            }
        }
        else
        {
            ennemie.isStopped = true;
        }

        if (attaquer && !confu)
        {
            hitboxAttaque.SetActive(true);
        }
        else
        {
            hitboxAttaque.SetActive(false);
        }

        if (hit)
        {
            confu = true;
            //hitboxAttaque.GetComponent<attaqueChevre>().isHit = true;
            Invoke("annuleConfu", 5f);
            hit = false;
        }
    }


    private void OnTriggerStay(Collider collision)
    {
        if (collision.tag == "perso")
        {   
            trouverPerso = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.tag == "perso")
        {
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

    public void mort()
    {
        etatMort = true;
        Destroy(gameObject);
    }
}
