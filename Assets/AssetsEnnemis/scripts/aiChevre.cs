using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class aiChevre : MonoBehaviour
{
    public NavMeshAgent ennemie;
    public GameObject joueur;

    public bool trouverPerso;
    public bool attaquer;

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
        if (Physics.Linecast(transform.position, joueur.transform.position, out RaycastHit hitInfo))
        {
            if (!trouverPerso)
            {
                if (ennemie.pathPending || !ennemie.isOnNavMesh || ennemie.remainingDistance > 0.1f)
                    return;
                trouverNouvelleDest();
            }
            if(!attaquer)
            {
                ennemie.destination = ennemie.transform.position;
                ennemie.transform.LookAt(new Vector3(joueur.transform.position.x, 0, joueur.transform.position.z));
            }
            else
            {
                if (!setDirection)
                {
                    direction = ennemie.transform.forward;
                    setDirection = true;
                }
                ennemie.Move(direction);
                if(hitInfo.distance > 50f)
                {
                    attaquer = false;
                    setDirection = false;
                    print("ok");
                }
            }
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
}
