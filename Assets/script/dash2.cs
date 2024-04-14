using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dash2 : MonoBehaviour
{
    [Header("References")]
    public Transform orientation;
    public Transform cameraPerso;

    [Header("Dash")]
    public float forceDash;
    public float forceDashHaut;
    public float dureeDash;
    public float cdDash;
    public float vitesseDashYMax;

    [Header("Effet camera")]
    public camera1p cam;
    public float fovDash;

    [Header("Reglages")]
    public bool utiliseCameraAvant = true;
    public bool permettreTousDirections = true;
    public bool desactiverGravite = false;
    public bool reiniVel = false;

    float dureeCdDash;
    float dashRestant;

    Rigidbody rb;

    mouvement2 scriptMouve;

    // Start is called before the first frame update
    void Start()
    {
        dashRestant = logiqueAmelioration.nbrDashMax;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(mouvement2.toucheSol);

        rb = GetComponent<Rigidbody>();
        scriptMouve = GetComponent<mouvement2>();

        if (mouvement2.toucheSol)
        {
            if (dashRestant < logiqueAmelioration.nbrDashMax)
            {
                Invoke("ReiniDashAir", dureeCdDash);
            }
        }

        if (dashRestant > 0)
        {
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                if (dashRestant <= 0)
                {
                    dashRestant = 0;
                }

                dashRestant--;

                Dash();
            }
        }


        if (dureeCdDash > 0)
        {
            dureeCdDash -= Time.deltaTime;
        }
    }

    void Dash()
    {
        if (dureeCdDash > 0)
        {
            return;
        }
        else
        {
            dureeCdDash = cdDash;
        }

        scriptMouve.enDash = true;

        scriptMouve.vitesseYMax = vitesseDashYMax;

        cam.FaireFov(fovDash);

        Transform tAvant;

        if (utiliseCameraAvant)
        {
            tAvant = cameraPerso;
        }
        else
        {
            tAvant = orientation;
        }

        Vector3 direction = ObtenirDirection(tAvant);

        Vector3 forceAAppliquer = direction * forceDash + orientation.right * forceDashHaut;

        if (desactiverGravite)
        {
            rb.useGravity = false;
        }

        delaiForceAAppliquer = forceAAppliquer;

        Invoke("DelaiForceDash", 0.025f);

        Invoke("ReiniDash", dureeDash);
    }

    Vector3 delaiForceAAppliquer;

    void DelaiForceDash()
    {
        if (reiniVel)
        {
            rb.velocity = Vector3.zero;
        }

        rb.AddForce(delaiForceAAppliquer, ForceMode.Impulse);
    }

    void ReiniDash()
    {
        scriptMouve.enDash = false;

        scriptMouve.vitesseYMax = 0;

        cam.FaireFov(70f);

        if (desactiverGravite)
        {
            rb.useGravity = true;
        }
    }

    Vector3 ObtenirDirection(Transform tAvant)
    {
        float inputHorizontal = Input.GetAxisRaw("Horizontal");
        float inputVertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3();

        if (permettreTousDirections)
        {
            direction = tAvant.forward * inputVertical + tAvant.right * inputHorizontal;
        }
        else
        {
            direction = tAvant.forward;
        }

        if (inputVertical == 0 && inputHorizontal == 0)
        {
            direction = tAvant.forward;
        }

        return direction.normalized;
    }

    void ReiniDashAir()
    {
        dashRestant = logiqueAmelioration.nbrDashMax;
    }
}
