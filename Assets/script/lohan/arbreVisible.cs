using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arbreVisible : MonoBehaviour
{
    public float distance;
    void Start()
    {
        gameObject.GetComponent<Terrain>().treeDistance = distance;
    }

}
