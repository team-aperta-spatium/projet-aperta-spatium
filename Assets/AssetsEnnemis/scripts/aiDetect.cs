using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class aiDetect : MonoBehaviour
{
    public GameObject ennemie;
    public GameObject joueur;
    Vector3 posEnnemie;
    Vector3 posJoueur;

    NavMeshAgent m_Agent;

    public float m_Range = 25.0f;
    
    bool persoInRange;
    // Start is called before the first frame update
    void Start()
    {
        

        m_Agent = GetComponent<NavMeshAgent>();
        persoInRange = false;
    }

    // Update is called once per frame
    void Update()
    {
       // posEnnemie = ennemie.transform.position;
        posJoueur = joueur.transform.position;
        Debug.DrawRay(transform.localPosition, posJoueur, Color.red);


        print(persoInRange);
        if (persoInRange == false /*&& !Physics.Raycast(ennemie.GetComponent<Transform>().position, joueur.GetComponent<Transform>().position, 25f, 0, 0)*/)
        {
            if (m_Agent.pathPending || !m_Agent.isOnNavMesh || m_Agent.remainingDistance > 0.1f)
                return;

            m_Agent.destination = m_Range * Random.insideUnitCircle;
           // Debug.DrawRay(posEnnemie, posJoueur, Color.red);
        }
        else
        {
            m_Agent.SetDestination(joueur.GetComponent<Transform>().position);
            //Debug.DrawRay(posEnnemie, posJoueur, Color.green);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.name == "perso")
        {
            persoInRange = true;
        }
    }
}

