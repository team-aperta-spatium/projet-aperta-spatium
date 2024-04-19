using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class comportementBoss : MonoBehaviour
{
    public GameObject boss;
    public NavMeshAgent navBoss;
    public GameObject joueur;
    public Vector3 direction;

    Vector3 Q1;
    Vector3 Q2;
    Vector3 Q3;
    Vector3 Q4;

    public bool onStop;

    // Start is called before the first frame update
    void Start()
    {
        onStop = true;

        int qAle = Random.Range(0, 4);

        Q1 = new Vector3(12.5f, 4.25f, 12.5f);
        Q2 = new Vector3(12.5f, 4.25f, -12.5f);
        Q3 = new Vector3(-12.5f, 4.25f, -12.5f);
        Q4 = new Vector3(-12.5f, 4.25f, 12.5f);
        
        if(qAle == 0)
        {
            navBoss.SetDestination(Q1);
        }
        else if(qAle == 1)
        {
            navBoss.SetDestination(Q2);
        }
        else if (qAle == 2)
        {
            navBoss.SetDestination(Q3);
        }
        else
        {
            navBoss.SetDestination(Q4);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit ray;
        Physics.Linecast(boss.transform.position, joueur.transform.position, out ray);
        Debug.DrawLine(boss.transform.position, joueur.transform.position, Color.red);
        Vector3 v3RayDirection = ray.point - boss.transform.position;

        if (onStop == true && navBoss.remainingDistance <= 0.2)
        {
            //float angle = Vector3.Angle(v3RayDirection, transform.forward);
            //boss.transform.rotation = Quaternion.Euler(0, angle + 45, 0);

            boss.transform.LookAt(joueur.transform.position);


            int nbAle = Random.Range(0, 1000000);
            if(nbAle >= 999550)
            {
                
            }
        }

        /*
        if(navBoss.destination == Q1 && navBoss.remainingDistance <= 0.1)
        {
            navBoss.SetDestination(Q2);
        }
        else if(navBoss.destination == Q2 && navBoss.remainingDistance <= 0.1)
        {
            navBoss.SetDestination(Q3);
        }
        else if (navBoss.destination == Q3 && navBoss.remainingDistance <= 0.1)
        {
            navBoss.SetDestination(Q4);
        }
        else if (navBoss.destination == Q4 && navBoss.remainingDistance <= 0.1)
        {
            navBoss.SetDestination(Q1);
        }
        print(navBoss.destination);
        */

    }
}
