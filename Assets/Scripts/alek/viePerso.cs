using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class viePerso : MonoBehaviour
{
    public float nbrViePerso;
    public GameObject perso;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (nbrViePerso <= 0)
        {
            SceneManager.LoadScene("mort");
        }
    }
}
