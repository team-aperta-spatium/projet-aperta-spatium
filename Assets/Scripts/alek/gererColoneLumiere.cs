using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gererColoneLumiere : MonoBehaviour
{
    public Material lumiere;
    GameObject perso;
    public float distanceMax;
    public float intensiteMax;

    private Renderer rend;
    private float distanceMin = 0f;

    // Start is called before the first frame update
    void Start()
    {
        perso = GameObject.Find("perso");
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, perso.transform.position);
        Debug.Log(distance);

        float intensite = distance * (distance/15);

        lumiere.SetColor("_EmissionColor", Color.cyan * intensite);

        //rend.material = lumiere;
    }
}
