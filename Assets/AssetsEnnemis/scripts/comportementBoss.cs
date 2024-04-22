using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class comportementBoss : MonoBehaviour
{
    public GameObject boss;
    public NavMeshAgent navBoss;
    public GameObject joueur;
    public Animator animator;

    public GameObject baseProjectiles;
    public GameObject projectile;
    public List<GameObject> groupeProj;

    Vector3 Q1;
    Vector3 Q2;
    Vector3 Q3;
    Vector3 Q4;

    int dernierQ;

    public bool onStop;
    public bool animOn;

    // Start is called before the first frame update
    void Start()
    {
        onStop = false;
        animOn = false;

        Q1 = new Vector3(12.5f, 4.25f, 12.5f);
        Q2 = new Vector3(12.5f, 4.25f, -12.5f);
        Q3 = new Vector3(-12.5f, 4.25f, -12.5f);
        Q4 = new Vector3(-12.5f, 4.25f, 12.5f);

        nextDestination();

        
    }

    // Update is called once per frame
    void Update()
    {
        if (navBoss.remainingDistance <= 0.2)
        {
            onStop = true;
            boss.transform.LookAt(joueur.transform.position);


            int nbAle = UnityEngine.Random.Range(0, 1000000);
            if(nbAle >= 999550)
            {
                grosseAttaque();
            }
            else if(nbAle <= 500)
            {
                lanceProjectile();
            }            
        }

        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.8 && animOn)
        {
            onStop = false;
            animOn = false;
            nextDestination();
        }
    }

    public void grosseAttaque()
    {
        animator.SetTrigger("grosseAttaque");
        Invoke("checkAnim", 1f);
    }

    public void nextDestination()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
        boss.transform.rotation = Quaternion.Euler(0, 0, 0);

        int qAle = UnityEngine.Random.Range(0, 4);

        if (qAle == 0 && dernierQ != 1)
        {
            navBoss.SetDestination(Q1);
            dernierQ = 1;
        }
        else if (qAle == 1 && dernierQ != 2)
        {
            navBoss.SetDestination(Q2);
            dernierQ = 2;
        }
        else if (qAle == 2 && dernierQ != 3)
        {
            navBoss.SetDestination(Q3);
            dernierQ = 3;
        }
        else if(qAle == 3 && dernierQ != 4)
        {
            navBoss.SetDestination(Q4);
            dernierQ = 4;
        }
        else
        {
            nextDestination();
        }
    }

    public void checkAnim()
    {
        animOn = true;
    }

    public void lanceProjectile()
    {
        groupeProj = new List<GameObject>();
        for (int i = 0; i < 5; i++)
        {
            float floatI = i;
            groupeProj.Add(Instantiate(projectile, baseProjectiles.transform.position, Quaternion.identity));
            StartCoroutine(TireProj(groupeProj[i], floatI));
        }
    }

    IEnumerator TireProj(GameObject projActif, float i)
    {
        yield return new WaitForSeconds(i/10f);
        projActif.AddComponent<Rigidbody>();
        projActif.AddComponent<projDestroy>();
        projActif.SetActive(true);
        projActif.GetComponent<Rigidbody>().AddForce((boss.transform.forward + new Vector3(i/2 - 1f, 0, 0)) * 1000);
    }
}
