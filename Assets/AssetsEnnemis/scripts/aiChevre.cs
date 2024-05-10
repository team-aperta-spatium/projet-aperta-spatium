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

    //chatGPT
    public float chargeSpeed = 500f;
    public float chargeDuration = 2f; // Time to charge before resuming normal navigation
    public float resumeDistance = 5f; // Distance to resume navigation if player is not hit

    private bool isCharging = false;
    private float chargeTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        trouverPerso = false;
        attaquer = false;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Physics.Linecast(transform.position, joueur.transform.position, out RaycastHit hitInfo))
        {
            if (!trouverPerso)
            {
                if (ennemie.pathPending || !ennemie.isOnNavMesh || ennemie.remainingDistance > 0.1f)
                    return;
                trouverNouvelleDest();
            }
            else
            {
                if(!attaquer)
                {
                    ennemie.destination = ennemie.transform.position;
                    ennemie.transform.LookAt(new Vector3(joueur.transform.position.x, 0, joueur.transform.position.z));
                }
                else
                {
                    ennemie.speed = 20;
                    ennemie.acceleration = 20;
                    ennemie.destination = joueur.transform.position;
                }
            }
        }
        */
        //chatGPT
        if (!isCharging)
        {
            if (Vector3.Distance(transform.position, joueur.transform.position) < ennemie.stoppingDistance)
            {
                // Player is close, start charging
                isCharging = true;
                ennemie.isStopped = true;
                ChargeTowardsPlayer();
            }
            else
            {
                // Resume normal navigation
                ennemie.isStopped = false;
                ennemie.SetDestination(joueur.transform.position);
            }
        }
        else
        {
            // Charging towards player
            chargeTimer += Time.deltaTime;
            if (chargeTimer >= chargeDuration)
            {
                // Resume normal navigation after charge duration
                isCharging = false;
                chargeTimer = 0f;
                ennemie.isStopped = false;
                ennemie.SetDestination(joueur.transform.position);
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

    //chatGPT
    void ChargeTowardsPlayer()
    {
        Vector3 direction = (joueur.transform.position - transform.position).normalized;
        // Instead of directly moving the transform, adjust the NavMeshAgent's velocity
        ennemie.velocity = direction * chargeSpeed;
    }
}
