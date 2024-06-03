using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class mouvementClonePerso : MonoBehaviour
{
    bool ennemieDetecter;

    public bool peutAttaquer;
    public float distanceDetection;
    public float distanceAttaque;
    public inventaire clonage;
    public int nbrAttaque;
    float timerMort;
    public GameObject jondo;

    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        timerMort = 20f;
        peutAttaquer = true;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] ennemies = GameObject.FindGameObjectsWithTag("ennemi");

        timerMort -= Time.deltaTime;

        foreach (GameObject ennemie in ennemies)
        {
            float distanceAUnEnnemie = Vector3.Distance(transform.position, ennemie.transform.position);

            if (distanceAUnEnnemie <= distanceDetection)
            {
                if (distanceAUnEnnemie <= distanceAttaque)
                {
                    //agent.isStopped = true;


                    if (peutAttaquer)
                    {
                        if (clonage.actif)
                        {
                            nbrAttaque = Random.Range(1, 4);
                        }
                        else
                        {
                            nbrAttaque = Random.Range(1, 3);
                        }
                    }
                    else
                    {
                        nbrAttaque = 0;
                    }
                }
                else
                {
                    agent.isStopped = false;
                    nbrAttaque = 0;
                    agent.destination = ennemie.transform.position;
                }
            }
            else
            {
                //agent.isStopped = true;
            }
        }

        if (timerMort <= 0)
        {
            Destroy(gameObject);
            clonageScript.nbrClone -= 1;
        }

        if (GetComponent<NavMeshAgent>().velocity.magnitude > 0.1)
        {
            jondo.GetComponent<Animator>().SetBool("cours", true);
        }
        else
        {
            jondo.GetComponent<Animator>().SetBool("cours", false);
        }
    }
}
