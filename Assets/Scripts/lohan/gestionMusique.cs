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
    [SerializeField] AudioSource sourceNarrateur;
    [SerializeField] AudioSource coupEpee;
    [Header("AudioClip")]
    public AudioClip musique;
    public AudioClip ok;
    public AudioClip footstep;
    public AudioClip narrateur;
    public AudioClip coupEpeeFaible1;
    public AudioClip coupEpeeFaible2;
    public AudioClip coupEpeeFaible3;
    public AudioClip coupEpeeFort1;
    public AudioClip coupEpeeFort2;
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
            if(scene.name == "tutoriel")
            {
                jouerNarrateur();
            }
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

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            jouerEpeeFaible();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            jouerEpeeFort();
        }
    }

    public void jouerOk()
    {
        sons.PlayOneShot(ok);
    }

    public void jouerNarrateur()
    {
        sourceNarrateur.PlayOneShot(narrateur);
        sourceMusique.volume = 0.15f;
        float length = narrateur.length;
        Invoke("resetSons", length);
    }

    public void resetSons()
    {
        sourceMusique.volume = 0.5f;
    }

    public void jouerEpeeFaible()
    {
        float valAle = Random.Range(1, 4);
        if(valAle == 1)
        {
            coupEpee.PlayOneShot(coupEpeeFaible1);
        }
        else if(valAle == 2)
        {
            coupEpee.PlayOneShot(coupEpeeFaible2);
        }
        else if (valAle == 3)
        {
            coupEpee.PlayOneShot(coupEpeeFaible3);
        }
    }

    public void jouerEpeeFort()
    {
        float valAle = Random.Range(1, 3);
        if (valAle == 1)
        {
            coupEpee.PlayOneShot(coupEpeeFort1);
        }
        else if (valAle == 2)
        {
            coupEpee.PlayOneShot(coupEpeeFort2);
        }
    }
}
