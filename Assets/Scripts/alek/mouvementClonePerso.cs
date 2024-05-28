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

    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] ennemies = GameObject.FindGameObjectsWithTag("ennemi");

        foreach (GameObject ennemie in ennemies)
        {
            float distanceAUnEnnemie = Vector3.Distance(transform.position, ennemie.transform.position);

            if (distanceAUnEnnemie <= distanceDetection)
            {
                if (distanceAUnEnnemie <= distanceAttaque)
                {
                    agent.isStopped = true;

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
                agent.isStopped =true;
            }
            
            if (ennemieDetecter)
            {
                
            }
        }

        Debug.Log(nbrAttaque);
    }
}
