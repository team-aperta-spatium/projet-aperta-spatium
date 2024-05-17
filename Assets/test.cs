using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public GameObject perso;
    // Update is called once per frame
    void Update()
    {
        transform.position = perso.transform.position;
    }
}
