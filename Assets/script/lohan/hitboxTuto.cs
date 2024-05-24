using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitboxTuto : MonoBehaviour
{
    public GameObject gestionTuto;
    public string nomTuto;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "perso")
        {
            gestionTuto.GetComponent<gestionTuto>().nextTuto(nomTuto);
        }
    }
}
