using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class controleArtefact : MonoBehaviour
{
    public Transform perso;
    public float distanceDetection;
    public GameObject txt;

    // Start is called before the first frame update
    void Start()
    {
        txt.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        float distanceAuPerso = Vector3.Distance(transform.position, perso.position);

        if (distanceAuPerso <= distanceDetection)
        {
            txt.SetActive(true);

            Debug.Log("true");

            if (Input.GetKeyDown(KeyCode.P))
            {
                SceneManager.LoadScene("boss");
            }
        }
        else
        {
            txt.SetActive(false);
        }
    }
}
