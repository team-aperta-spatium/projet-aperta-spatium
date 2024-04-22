using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    public NavMeshAgent ennemie;
    public GameObject joueur;
    public GameObject hitbox;
    public bool trouverPerso;
    public bool attEnCours;

    float distanceStop;
    Vector3 v3RayDirection;

    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        trouverPerso = false;
        distanceStop = ennemie.stoppingDistance;
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Linecast(transform.position, joueur.transform.position, out RaycastHit hitInfo))
        {
            if (hitInfo.collider.name == "persoObj" && trouverPerso == true)
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

                ennemie.destination = 20f * Random.insideUnitCircle;
                ennemie.speed = 2f;
                ennemie.angularSpeed = 120f;
                animator.SetBool("marche", true);
            }

            if(ennemie.remainingDistance <= distanceStop && trouverPerso == true && attEnCours == false)
            {
                attEnCours = true;
                animator.SetBool("attaque", true);
                ennemie.speed = 0f;
                Invoke("cancelAttaque", 1.5f);
                Invoke("actionAttaque", 3f);
            }
        }

        if(animator.GetBool("attaque") == true && animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.4f && animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 0.65f)
        {
            hitbox.SetActive(true);
        }
        else
        {
            hitbox.SetActive(false);
        }

        v3RayDirection = joueur.transform.position - ennemie.transform.position;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.name == "persoObj")
        {
            trouverPerso = true;
            CancelInvoke("perduPerso");
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.name == "persoObj")
        {
            ennemie.speed = 4f;
            Invoke("perduPerso", 5f);
        }
    }

    void perduPerso()
    {
        trouverPerso = false;
        animator.SetBool("cours", false); ;
    }

    private void actionAttaque()
    {
        attEnCours = false;
    }

    private void cancelAttaque()
    {
        animator.SetBool("attaque", false);
    }
}
