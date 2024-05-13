using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class aiChevre : MonoBehaviour
{
    public NavMeshAgent ennemie;
    public GameObject joueur;
    public GameObject hitboxAttaque;

    public bool trouverPerso;
    public bool attaquer;
    public bool hit;
    public bool confu;

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
            if (!trouverPerso)
            {
                if (ennemie.pathPending || !ennemie.isOnNavMesh || ennemie.remainingDistance > 0.1f)
                    return;
                trouverNouvelleDest();
            }
            if(trouverPerso && !attaquer)
            {
                ennemie.destination = ennemie.transform.position;
                ennemie.transform.LookAt(new Vector3(joueur.transform.position.x, 0, joueur.transform.position.z));
            }
            if(trouverPerso && attaquer)
            {
                if (!setDirection)
                {
                    direction = ennemie.transform.forward;
                    setDirection = true;
                }
                ennemie.Move(direction/2);
            }
        }
        else
        {
            ennemie.destination = ennemie.transform.position;
        }

        if (attaquer)
        {
            hitboxAttaque.SetActive(true);
        }
        else
        {
            hitboxAttaque.SetActive(false);
        }

        if (hit)
        {
            trouverPerso = false;
            attaquer = false;
            confu = true;
            hitboxAttaque.GetComponent<attaqueChevre>().isHit = true;
            Invoke("annuleConfu", 5f);
            hit = false;
        }
    }


    private void OnTriggerEnter(Collider collision)
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
        confu = false;
    }
}
