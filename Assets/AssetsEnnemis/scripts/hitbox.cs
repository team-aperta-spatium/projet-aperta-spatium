using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitbox : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.name == "perso")
        {
            print("ATTRAPER LE GOGO");
        }
    }
}
