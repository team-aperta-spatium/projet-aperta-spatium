using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class gererThumb : MonoBehaviour
{
    public GameObject ctnTexte;
    public TMP_Text texte;
    public Animator animator;

    bool debut;
    bool WASD;
    bool M1;
    bool M2;
    bool alt;
    bool espace;
    bool shift;
    bool ctrl;
    // Start is called before the first frame update
    void Start()
    {
        animator.enabled = false;
        debut = true;
        WASD = false;
        M1 = false;
        M2 = false;
        alt = false;
        espace = false;
        shift = false;
        ctrl = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale != 0)
        {
            if(debut && Input.GetKeyDown(KeyCode.W))
            {
                debut = false;
                animator.enabled = true;
                Invoke("completeWASD", 3f);
            }
            else if(WASD && Input.GetKeyDown(KeyCode.Mouse0))
            {
                WASD = false;
                animator.SetTrigger("fini");
                Invoke("completeM1", 3f);
            }
            else if (M1 && Input.GetKeyDown(KeyCode.Mouse1))
            {
                M1 = false;
                animator.SetTrigger("fini");
                Invoke("completeM2", 3f);
            }
            else if (M2 && Input.GetKey(KeyCode.LeftAlt) && Input.GetKeyDown(KeyCode.Mouse0))
            {
                M2 = false;
                animator.SetTrigger("fini");
                Invoke("completeAlt", 3f);
            }
            else if (alt && Input.GetKeyDown(KeyCode.Space))
            {
                alt = false;
                animator.SetTrigger("fini");
                Invoke("completeEspace", 3f);
            }
            else if (espace && Input.GetKeyDown(KeyCode.LeftShift))
            {
                espace = false;
                animator.SetTrigger("fini");
                Invoke("completeShift", 3f);
            }
            else if (shift && Input.GetKeyDown(KeyCode.LeftControl))
            {
                shift = false;
                animator.SetTrigger("fini");
                Invoke("completeCtrl", 3f);
            }
        }
    }

    public void completeWASD()
    {
        WASD = true;
        texte.SetText("Fait un clique gauche pour trois attaques de base");
    }

    public void completeM1()
    {
        M1 = true;
        texte.SetText("Fait un clique droit pour deux attaques puissantes");
    }

    public void completeM2()
    {
        M2 = true;
        texte.SetText("Maintient alt pour charger une attaque surpuissante puis clique gauche");
    }

    public void completeAlt()
    {
        alt = true;
        texte.SetText("Appuis sur espace pour sauter");
    }

    public void completeEspace()
    {
        espace = true;
        texte.SetText("Appuis sur shift pour courir");
    }

    public void completeShift()
    {
        shift = true;
        texte.SetText("Appuis sur CTRL pour dash");
    }

    public void completeCtrl()
    {
        ctrl = true;
        texte.SetText("fait attention a ta jauge d'énergie!");
        Invoke("finiTuto", 3f);
    }

    public void finiTuto()
    {
        Destroy(ctnTexte);
    }
}
