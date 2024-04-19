using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class comportementBoss : MonoBehaviour
{
    public NavMeshAgent navBoss;
    public GameObject joueur;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        navBoss.SetDestination(joueur.transform.position);
    }
}
