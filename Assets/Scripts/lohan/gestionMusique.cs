using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gestionMusique : MonoBehaviour
{
    [Header("AudioSources")]
    [SerializeField] AudioSource sourceMusique;
    [SerializeField] AudioSource sons;
    [SerializeField] AudioSource bruitPas;
    [Header("AudioClip")]
    public AudioClip musique;
    public AudioClip ok;
    public AudioClip footstep;
    [Header("valeurs autres")]
    public GameObject perso;
    public float multiPitch;

    private Scene scene;

    private void Start()
    {
        sourceMusique.clip = musique;
        sourceMusique.Play();

        bruitPas.clip = footstep;
        bruitPas.Play();

        DontDestroyOnLoad(gameObject);
        Scene scene = SceneManager.GetActiveScene();
    }
    private void Update()
    {
        if(SceneManager.GetActiveScene() != scene)
        {
            perso = GameObject.Find("/persoParent/perso");
            scene = SceneManager.GetActiveScene();
        }

        if (perso != null && perso.GetComponent<Rigidbody>().velocity != new Vector3(0,0,0) && (perso.GetComponent<mouvement2>().etat == mouvement2.etatMouve.marche || perso.GetComponent<mouvement2>().etat == mouvement2.etatMouve.course))
        {
            if(perso.GetComponent<Rigidbody>().velocity.x > perso.GetComponent<Rigidbody>().velocity.z)
            {
                bruitPas.pitch = perso.GetComponent<Rigidbody>().velocity.x / multiPitch;
            }
            else
            {
                bruitPas.pitch = perso.GetComponent<Rigidbody>().velocity.z / multiPitch;
            }

            if(bruitPas.isPlaying == false)
            {
                bruitPas.Play();
            }
        }
        else
        {
            bruitPas.Stop();
        }
    }

    public void jouerOk()
    {
        sons.PlayOneShot(ok);
    }
}
