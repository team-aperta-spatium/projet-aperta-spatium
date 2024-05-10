using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class aiChevre : MonoBehaviour
{
    public NavMeshAgent ennemie;
    public GameObject joueur;

    public bool trouverPerso;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
            else
            {
                ennemie.destination = ennemie.transform.position;
                ennemie.transform.LookAt(new Vector3(joueur.transform.position.x, 0, joueur.transform.position.z));
            }
        }
    }


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "perso")
        {
            print("collision on");
            trouverPerso = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.tag == "perso")
        {
            print("collision off");
            trouverPerso = false;
        }
    }

    public void trouverNouvelleDest()
    {
        Vector3 randomDirection = Random.insideUnitSphere * 35f;
        randomDirection += transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, 100f, 1);
        Vector3 finalPosition = hit.position;
        ennemie.destination = finalPosition;
    }
}
