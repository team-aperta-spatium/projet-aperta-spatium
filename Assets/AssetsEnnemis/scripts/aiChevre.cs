using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class aiChevre : MonoBehaviour
{
    public NavMeshAgent ennemie;
    public GameObject joueur;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Linecast(transform.position, joueur.transform.position, out RaycastHit hitInfo))
        {
            if (ennemie.pathPending || !ennemie.isOnNavMesh || ennemie.remainingDistance > 0.1f)
                return;

            trouverNouvelleDest();
            ennemie.speed = 4f;
            ennemie.angularSpeed = 300f;
        }
    }

    public void trouverNouvelleDest()
    {
        Vector3 randomDirection = Random.insideUnitSphere * 20f;
        randomDirection += transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, 100f, 1);
        Vector3 finalPosition = hit.position;
        ennemie.destination = finalPosition;
    }
}
