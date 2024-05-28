using UnityEngine;

public class hitbox : MonoBehaviour
{
    public GameObject joueur;
    public GameObject renard;

    private bool isHit;
    private void Update()
    {
        if (Physics.Linecast(renard.transform.position, joueur.transform.position, out RaycastHit hitInfo) && isHit)
        {
            Vector3 forceRenard = hitInfo.point - joueur.transform.position;
            joueur.GetComponent<Rigidbody>().AddForce(-forceRenard.normalized * 1500f);
            isHit = false;
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.tag == "perso")
        {
            viePerso.nbrViePerso -= 1;
            isHit = true;
        }
    }
}
