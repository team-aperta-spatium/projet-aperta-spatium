using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouvement2 : MonoBehaviour
{
    [Header("Mouvement")]
    public float dragSol;
    public float vitesseMarche;
    public float vitesseCourse;
    public float vitesseDash;
    public float facteurChangeVitesseDash;
    public float vitesseYMax;

    [Header("saut")]
    public float forceSaut;
    public float cdSaut;
    public float multiplicateurAir;

    [Header("Accroupis")]
    public float vitesseAccroupi;
    public float echelleYAccroupi;

    [Header("Gestion pentes")]
    public float anglePentesMax;

    [Header("Verification sol")]
    public float hauteurPerso;
    public LayerMask quoiSol;
    public etatMouve etat;
    public enum etatMouve
    {
        marche,
        course,
        accroupi,
        dash,
        air
    }

    public bool enDash;

    public GameObject camPerso;

    RaycastHit hitPentes;

    bool toucheSol;
    bool pretSaut;
    bool sortPente;
    bool garderMomentum;
    bool peutBouger;

    public Transform orientation;

    float vitesse;
    float inputHorizontal;
    float inputVertical;
    float echelleYDebut;
    float vitesseDesiree;
    float derniereVitesseDesiree;
    float facteurChangeVitesse;
    float sautRestant;
    float dragAir;
    float massAir;

    etatMouve dernierEtat;

    Vector3 directionMouve;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        sautRestant = 2;

        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        pretSaut = true;

        echelleYDebut = transform.localScale.y;

        dragAir = dragSol / 6;
        peutBouger = true;
    }

    // Update is called once per frame
    void Update()
    {
        toucheSol = Physics.Raycast(transform.position, Vector3.down, hauteurPerso * 0.5f + 0.2f, quoiSol);

        if (peutBouger)
        {
            MesInputs();
        }
        ControleVitesse();
        ControlleurEtatMouve();

        //Debug.Log(dragAir);

        if (toucheSol)
        {
            //dragAir = dragSol / 6;
            //massAir = 2;

            if (sautRestant < 2)
            {
                ReiniSautDouble();

                Invoke("ReiniSaut", cdSaut);
            }
        }
        else
        {
            //if (dragAir >= 3)
            //{
            //    massAir++;
            //    dragAir = 3;
            //}
            //else
            //{
            //    dragAir += 0.01f;
            //}
        }

        if (etat == etatMouve.marche || etat == etatMouve.course || etat == etatMouve.accroupi)
        {
            rb.drag = dragSol;
        }
        else
        {
            rb.drag = 0;
            Invoke("DragAir", 1f);
        }

        if (toucheSol && dernierEtat == etatMouve.air)
        {
            
        }

        Debug.Log(peutBouger);
    }

    void FixedUpdate()
    {
        if (peutBouger)
        {
            MouvePerso();
        }
    }

    void ControlleurEtatMouve()
    {
        if (enDash)
        {
            etat = etatMouve.dash;
            vitesseDesiree = vitesseDash;
            facteurChangeVitesse = facteurChangeVitesseDash;
        }
        else if (Input.GetKey(KeyCode.C))
        {
            etat = etatMouve.accroupi;
            vitesseDesiree = vitesseAccroupi;
        }
        else if (toucheSol && Input.GetKey(KeyCode.LeftShift))
        {
            etat = etatMouve.course;
            vitesseDesiree = vitesseCourse;
        }
        else if (toucheSol)
        {
            etat = etatMouve.marche;
            vitesseDesiree = vitesseMarche;
        }
        else
        {
            etat = etatMouve.air;

            if (vitesseDesiree < vitesseCourse)
            {
                vitesseDesiree = vitesseMarche;
            }
            else
            {
                vitesseDesiree = vitesseCourse;
            }
        }

        bool vitesseDesireeAChanger = vitesseDesiree != derniereVitesseDesiree;

        if (dernierEtat == etatMouve.dash)
        {
            garderMomentum = true;
        }

        if (vitesseDesireeAChanger)
        {
            if (garderMomentum)
            {
                StopAllCoroutines();
                StartCoroutine(doucementLerpVitesse());
            }
            else
            {
                StopAllCoroutines();
                vitesse = vitesseDesiree;
            }
        }

        derniereVitesseDesiree = vitesseDesiree;
        dernierEtat = etat;
    }

    IEnumerator doucementLerpVitesse()
    {
        float temps = 0;
        float difference = Mathf.Abs(vitesseDesiree - vitesse);
        float valeurDepart = vitesse;

        float facteurBoost = facteurChangeVitesse;

        while (temps < difference)
        {
            vitesse = Mathf.Lerp(valeurDepart, vitesseDesiree, temps / difference);

            temps += Time.deltaTime * facteurBoost;

            yield return null;
        }

        vitesse = vitesseDesiree;
        facteurChangeVitesse = 1f;
        garderMomentum = false;
    }

    void MesInputs()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.Space) && sautRestant > 1)
        {
            sautRestant--;

            if (sautRestant <= 0)
            {
                sautRestant = 0;
            }

            if (pretSaut && toucheSol)
            {
                pretSaut = false;

                Saut();
            }
            else if (etat == etatMouve.air && sautRestant > 0)
            {
                Saut();
            }
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            transform.localScale = new Vector3(transform.localScale.x, echelleYAccroupi, transform.localScale.z);
            rb.AddForce(Vector3.down * 5f, ForceMode.Impulse);
        }
        else if (Input.GetKeyUp(KeyCode.C))
        {
            transform.localScale = new Vector3(transform.localScale.x, echelleYDebut, transform.localScale.z);
        }
    }

    void MouvePerso()
    {
        if (etat == etatMouve.dash)
        {
            return;
        }

        directionMouve = orientation.forward * inputVertical + orientation.right * inputHorizontal;

        if (SurPente() && !sortPente)
        {
            rb.AddForce(ObtenirDirectionMouvePente() * vitesse * 20f, ForceMode.Force);

            if (rb.velocity.y > 0)
            {
                rb.AddForce(Vector3.down * 80f, ForceMode.Force);
            }
        }
        else if (toucheSol)
        {
            rb.AddForce(directionMouve.normalized * vitesse * 10f, ForceMode.Force);
        }
        else if (!toucheSol)
        {
            rb.AddForce(directionMouve.normalized * vitesse * 10f * multiplicateurAir, ForceMode.Force);
        }

        rb.useGravity = !SurPente();
    }

    void ControleVitesse()
    {
        if (SurPente() && !sortPente)
        {
            if (rb.velocity.magnitude > vitesse)
            {
                rb.velocity = rb.velocity.normalized * vitesse;
            }
        }
        else
        {
            Vector3 velPlat = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

            if (velPlat.magnitude > vitesse)
            {
                Vector3 velLimite = velPlat.normalized * vitesse;
                rb.velocity = new Vector3(velLimite.x, rb.velocity.y, velLimite.z);
            }
        }

        if (vitesseYMax != 0 && rb.velocity.y > vitesseYMax)
        {
            rb.velocity = new Vector3(rb.velocity.x, vitesseYMax, rb.velocity.z);
        }
    }

    void Saut()
    {
        sortPente = true;

        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * forceSaut, ForceMode.Impulse);
    }

    void ReiniSaut()
    {
        pretSaut = true;

        sortPente = false;
    }

    void ReiniSautDouble()
    {
        sautRestant = 2;

        Invoke("ReiniMouve", 0f);
    }

    bool SurPente()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out hitPentes, hauteurPerso * 0.5f + 0.3f))
        {
            float angle = Vector3.Angle(Vector3.up, hitPentes.normal);
            return angle < anglePentesMax && angle != 0;
        }

        return false;
    }

    Vector3 ObtenirDirectionMouvePente()
    {
        return Vector3.ProjectOnPlane(directionMouve, hitPentes.normal).normalized;
    }

    void DragAir()
    {
        //rb.AddForce(-transform.up * 1f, ForceMode.Impulse);
    }

    void ReiniMouve()
    {
        peutBouger = false;
        Invoke("PeutBouger", 1f);
    }

    void PeutBouger()
    {
        peutBouger = true;
    }
}
