using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class debugRaycast : MonoBehaviour
{
    public GameObject mur;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, mur.transform.position, Color.red);
    }
}
