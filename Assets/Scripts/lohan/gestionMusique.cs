using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gestionMusique : MonoBehaviour
{
    [Header("AudioSources")]
    [SerializeField] AudioSource sourceMusique;
    [SerializeField] public AudioSource sourceMusiqueEnnemi;
    [SerializeField] AudioSource sons;
    [SerializeField] AudioSource bruitPas;
    [SerializeField] AudioSource sourceNarrateur;
    [SerializeField] AudioSource coupEpee;
    [SerializeField] AudioSource sourceDash;
    [SerializeField] AudioSource sourceHitEnnemi;
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
    public AudioClip musiqueEnnemi;
    public AudioClip musiqueBoss;
    public AudioClip dash;
    public AudioClip hitEnnemi;
    [Header("valeurs autres")]
    public GameObject perso;
    public float multiPitch;

    private Scene scene;
    private IEnumerator coroutineEnnemi;

    private void Start()
    {
        sourceMusique.clip = musique;
        StartCoroutine(PlayCustomLoop(sourceMusique, 22f));

        bruitPas.clip = footstep;
        bruitPas.Play();
        coroutineEnnemi = IEMusiqueEnnemi(sourceMusiqueEnnemi, 7f);

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
            else if(scene.name == "bossTrueModel")
            {
                jouerMusiqueBoss();
                StopAllCoroutines();
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

    public void jouerMusiqueEnnemi()
    {
        StartCoroutine(coroutineEnnemi);
        sourceMusique.volume = 0.2f;
    } 

    public IEnumerator IEMusiqueEnnemi(AudioSource sound, float endIntro)
    {
        sound.loop = false;
        float l = sound.clip.length - 27f;
        int t = 0;
        sound.Play();
        yield return new WaitForSeconds(endIntro);
        t = sound.timeSamples;
        yield return new WaitForSeconds(l - endIntro);
    LOOP:
        sound.timeSamples = t;
        sound.Play();
        yield return new WaitForSeconds(l - endIntro);
        goto LOOP;
    }

    public void arreterMusiqueEnnemi()
    {
        StopCoroutine(coroutineEnnemi);
        sourceMusiqueEnnemi.Stop();
        resetSons();
    }

    IEnumerator PlayCustomLoop(AudioSource sound, float endIntro)
    {
        sound.loop = false;
        float l = sound.clip.length - 27f;
        int t = 0;
        sound.Play();
        yield return new WaitForSeconds(endIntro);
        t = sound.timeSamples;
        yield return new WaitForSeconds(l - endIntro);
    LOOP:
        sound.timeSamples = t;
        sound.Play();
        yield return new WaitForSeconds(l - endIntro);
        goto LOOP;
    }

    public void jouerMusiqueBoss()
    {
        sourceMusique.clip = musiqueBoss;
        sourceMusique.loop = true;
        sourceMusique.Play();
    }

    public void jouerDash()
    {
        sourceDash.PlayOneShot(dash);
    }

    public void jouerHitEnnemi()
    {
        sourceHitEnnemi.PlayOneShot(hitEnnemi);
    }
}
