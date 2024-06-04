using UnityEngine;

public class hitbox : MonoBehaviour
{
    public GameObject joueur;
    public GameObject renard;
    public GameObject gestionMusique;

    private bool isHit;
    public bool aPerduVie = false;
    private void Start()
    {
        gestionMusique = GameObject.Find("gestionMusique");
    }
    private void Update()
    {
        if (Physics.Linecast(renard.transform.position, joueur.transform.position, out RaycastHit hitInfo) && isHit)
        {
            Vector3 forceRenard = hitInfo.point - joueur.transform.position;
            joueur.GetComponent<Rigidbody>().AddForce(-forceRenard.normalized * 2500f);
            isHit = false;
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.tag == "perso" && !aPerduVie)
        {
            gestionMusique.GetComponent<gestionMusique>().jouerHitEnnemi();
            viePerso.nbrViePerso -= 1;
            isHit = true;
            aPerduVie = true;
        }
    }
}
