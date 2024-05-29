using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gererInventaire : MonoBehaviour
{
    public inventaire i1;
    public inventaire i2;
    public inventaire i3;
    public inventaire i4;
    public inventaire i5;
    public inventaire i6;
    public inventaire i7;
    public inventaire i8;
    public inventaire i9;

    // Start is called before the first frame update
    void Start()
    {
        i1.enPossesion = false;
        i2.enPossesion = false;
        i3.enPossesion = false;
        i4.enPossesion = false;
        i5.enPossesion = false;
        i6.enPossesion = false;  
        i7.enPossesion = false;
        i8.enPossesion = false;
        i9.enPossesion = false;

        i1.actif = false;
        i2.actif = false;
        i3.actif = false;
        i4.actif = false;
        i5.actif = false;
        i6.actif = false;
        i7.actif = false;
        i8.actif = false;
        i9.actif = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
