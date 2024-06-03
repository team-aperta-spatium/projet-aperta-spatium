using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clonageScript : MonoBehaviour
{
    public inventaire clonage;
    public GameObject clonePerso;
    public static float nbrClone;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject perso = GameObject.Find("perso");

        if (clonage.actif)
        {
            if (nbrClone < 2)
            {
                if (Input.GetKeyDown(KeyCode.T))
                {
                    GameObject clone = Instantiate(clonePerso, new Vector3(perso.transform.position.x + 5, perso.transform.position.y, perso.transform.position.z) , perso.transform.rotation);
                    nbrClone += 1;
                }
            }
        }
    }
}
