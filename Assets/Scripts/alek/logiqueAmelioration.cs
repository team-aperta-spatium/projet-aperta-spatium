using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class logiqueAmelioration : MonoBehaviour
{
    public inventaire tripleSaut;
    public inventaire doubleDash;
    public static float nbrSautMax;
    public static float nbrDashMax;

    // Start is called before the first frame update
    void Start()
    {
        nbrDashMax = 1;
        nbrSautMax = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (tripleSaut.enPossesion)
        {
            if (tripleSaut.actif)
            {
                nbrSautMax = 3;
            }
            else
            {
                nbrSautMax = 2;
            }
        }

        if (doubleDash.enPossesion)
        {
            if(doubleDash.actif)
            {
                nbrDashMax = 2;
            }
            else
            {
                nbrDashMax = 1;
            }
        }
    }
}
