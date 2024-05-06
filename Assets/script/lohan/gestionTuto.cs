using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class gestionTuto : MonoBehaviour
{
    public TMP_Text text1;
    public TMP_Text text2;
    public TMP_Text text3;
    public GameObject pouce1;
    public GameObject pouce2;
    public GameObject pouce3;

    bool onBouge;
    bool onDash;
    bool onCrouch;
    bool onAttaque;

    bool onAlt;
    // Start is called before the first frame update
    void Start()
    {
        onBouge = true;
        onDash = false;
        onCrouch = false;
        onAttaque = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (onBouge)
        {
            if(Input.GetKeyDown(KeyCode.W))
            {
                pouce1.SetActive(true);
            }

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                pouce2.SetActive(true);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                pouce3.SetActive(true);
            }
        }
        else if (onDash)
        {
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                pouce1.SetActive(true);
            }
        }
        else if (onCrouch)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                pouce1.SetActive(true);
            }
        }
        else if(onAttaque)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && !onAlt)
            {
                pouce1.SetActive(true);
            }

            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                pouce2.SetActive(true);
            }

            if (Input.GetKey(KeyCode.LeftAlt))
            {
                Invoke("setAlt",0.5f);
                if (Input.GetKeyDown(KeyCode.Mouse0) && onAlt)
                {
                    pouce3.SetActive(true);
                }
            }
            else if(Input.GetKeyUp(KeyCode.LeftAlt))
            {
                CancelInvoke("setAlt");
                onAlt = false;
            }
        }
    }

    public void nextTuto(string nomTuto)
    {
        if(nomTuto == "Dash")
        {
            setDash();
        }
        else if(nomTuto == "Crouch")
        {
            setCrouch();
        }
        else if(nomTuto == "Attaque")
        {
            setAttaque();
        }
    }

    void setDash()
    {
        onBouge = false;
        onDash = true;
        text1.SetText("\u2022 Ctrl pour dasher");
        text2.SetText("");
        text3.SetText("");
        pouce1.SetActive(false);
        pouce2.SetActive(false);
        pouce3.SetActive(false);
    }

    void setCrouch()
    {
        onDash = false;
        onCrouch = true;
        text1.SetText("\u2022 touche C pour s'accroupir");
        text2.SetText("");
        text3.SetText("");
        pouce1.SetActive(false);
        pouce2.SetActive(false);
        pouce3.SetActive(false);
    }

    void setAttaque()
    {
        onCrouch = false;
        onAttaque = true;
        text1.fontSize = 14;
        text2.fontSize = 14;
        text3.fontSize = 14;
        text1.SetText("\u2022 Clique gauche pour l'attaque de base (combo de 3)");
        text2.SetText("\u2022 Clique droit pour l'attaque lourde (combo de 2)");
        text3.SetText("\u2022 Alt gauche pour charger et clique gauche pour attaquer");
        pouce1.SetActive(false);
        pouce2.SetActive(false);
        pouce3.SetActive(false);
    }

    public void setAlt()
    {
        onAlt = true;
        print(onAlt);
    }
}
