using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class aiChevre : MonoBehaviour
{
    public NavMeshAgent ennemie;
    public GameObject joueur;
    public GameObject zoneAggro;
    public GameObject hitboxAttaque;
    public Animator animator;

    public bool trouverPerso;
    public bool attaquer;
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
        if (!confu && !etatMort)
        {
            ennemie.isStopped = false;
            if (!trouverPerso && !attaquer)
            {
                if (ennemie.pathPending || !ennemie.isOnNavMesh || ennemie.remainingDistance > 0.1f)
                    return;
                trouverNouvelleDest();
                animator.SetBool("trouverPerso", false);
            }
            else if(trouverPerso && !attaquer)
            {
                ennemie.destination = ennemie.transform.position;
                ennemie.transform.LookAt(new Vector3(joueur.transform.position.x, 0, joueur.transform.position.z));
                setDirection = false;
                animator.SetBool("trouverPerso", true);
            }
            else if(attaquer)
            {
                if (!setDirection)
                {
                    direction = ennemie.transform.forward;
                    setDirection = true;
                }
                ennemie.updateRotation = false;
                ennemie.Move(direction/2f);
            }
        }
        else
        {
            ennemie.isStopped = true;
            animator.SetBool("trouverPerso", false);
            hitboxAttaque.SetActive(false);
            if (etatMort)
            {
                CancelInvoke();
            }
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

    public void annuleConfu()
    {
        ennemie.updateRotation = true;
        ennemie.transform.LookAt(new Vector3(joueur.transform.position.x, 0, joueur.transform.position.z));
        setDirection = false;
        confu = false;
        zoneAggro.GetComponent<hitboxSetAttaque>().confu = false;
    }

    public void setAttaque()
    {
        animator.SetTrigger("preAttaque");
        animator.SetBool("Attaque", true);
        Invoke("attaque", 1f);
    }

    public void attaque()
    {
        attaquer = true;
    }

    public void mort()
    {
        animator.SetBool("mort", true);
        etatMort = true;
        StartCoroutine(destroy());
    }

    IEnumerator destroy()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
