using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    [Header("Valeurs autres")]
    public GameObject perso;
    public float multiPitch;

    private void Start()
    {
        sourceMusique.clip = musique;
        sourceMusique.Play();

        bruitPas.clip = footstep;
        bruitPas.Play();
    }
    private void Update()
    {
        if (perso.GetComponent<Rigidbody>().velocity != new Vector3(0,0,0) && (perso.GetComponent<mouvement2>().etat == mouvement2.etatMouve.marche || perso.GetComponent<mouvement2>().etat == mouvement2.etatMouve.course))
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
