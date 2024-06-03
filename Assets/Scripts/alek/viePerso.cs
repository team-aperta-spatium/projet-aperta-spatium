using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class viePerso : MonoBehaviour
{
    public static float nbrViePerso;
    public GameObject perso;

    // Start is called before the first frame update
    void Start()
    {
        nbrViePerso = 6;
    }

    // Update is called once per frame
    void Update()
    {
        if (nbrViePerso <= 0)
        {
            SceneManager.LoadScene("mort");
        }
        //Debug.Log(nbrViePerso);
    }
}
