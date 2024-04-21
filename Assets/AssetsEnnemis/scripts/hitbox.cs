using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitbox : MonoBehaviour
{
    public bool attaque;
    public float nbrDmgEnnemi;

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.tag == "perso")
        {
            if (attaque)
            {
                collision.gameObject.GetComponent<viePerso>().nbrViePerso -= nbrDmgEnnemi;
            }
        }
    }
}
