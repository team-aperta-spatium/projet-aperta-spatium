using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gestionAccueil : MonoBehaviour
{
    public void OnApplicationQuit()
    {
        Application.Quit();
    }

    public void commencerJeu()
    {
        SceneManager.LoadScene(1);
    }
}
