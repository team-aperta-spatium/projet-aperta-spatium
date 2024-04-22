using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouvement2 : MonoBehaviour
{
    public static bool toucheSol;

    [Header("endurance")]
    public static float endurance;
    public static bool actionPossible;
    public static bool actionEnCours;
    public static bool attaqueEnCours;

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
    public GameObject uiEnergie;

    RaycastHit hitPentes;

    bool pretSaut;
    bool sortPente;
    bool garderMomentum;

    public Transform orientation;

    float vitesse;
    float inputHorizontal;
    float inputVertical;
    float echelleYDebut;
    float vitesseDesiree;
    float derniereVitesseDesiree;
    float facteurChangeVitesse;
    float sautRestant;

    etatMouve dernierEtat;

    Vector3 directionMouve;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        sautRestant = logiqueAmelioration.nbrSautMax;

        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        pretSaut = true;

        echelleYDebut = transform.localScale.y;
        endurance = 100;
        actionPossible = true;
    }

    // Update is called once per frame
    void Update()
    {
        toucheSol = Physics.Raycast(transform.position, Vector3.down, hauteurPerso * 0.5f + 0.2f, quoiSol);

        MesInputs();

        ControleVitesse();
        ControlleurEtatMouve();

        if (toucheSol)
        {
            if (sautRestant < logiqueAmelioration.nbrSautMax)
            {
                ReiniSautDouble();

                Invoke("ReiniSaut", cdSaut);
            }
        }

        if (etat == etatMouve.marche || etat == etatMouve.course || etat == etatMouve.accroupi)
        {
            rb.drag = dragSol;
        }
        else
        {
            rb.drag = 0;
        }

        if (etat == etatMouve.course)
        {
            endurance -= 0.05f;
            actionEnCours = true;
        }

        if (endurance <= 0)
        {
            endurance = 0;
            actionPossible = false;
            vitesseDesiree = vitesseMarche;
        }
        else if (endurance > 0 && endurance < 100 && !actionEnCours && Time.timeScale != 0 && !attaqueEnCours && actionPossible)
        {
            endurance += 0.06f;
        }

        if (!actionPossible)
        {
            endurance += 0.04f;

            if (endurance >= 100)
            {
                endurance = 100;
                actionPossible = true;
            }
        }

        uiEnergie.GetComponent<pieChart>().valeur = endurance / 100;
    }

    void FixedUpdate()
    {
        MouvePerso();
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
            if (actionPossible)
            {
                etat = etatMouve.course;
                vitesseDesiree = vitesseCourse;
            }
        }
        else if (toucheSol)
        {
            etat = etatMouve.marche;
            vitesseDesiree = vitesseMarche;

            if (!attaqueEnCours)
            {
                actionEnCours = false;
            }
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
        if (actionPossible)
        {
            sortPente = true;

            rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

            rb.AddForce(transform.up * forceSaut, ForceMode.Impulse);

            endurance -= 10;
            actionEnCours = true;
        }
    }

    void ReiniSaut()
    {
        pretSaut = true;

        sortPente = false;
    }

    void ReiniSautDouble()
    {
        sautRestant = logiqueAmelioration.nbrSautMax;
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
}