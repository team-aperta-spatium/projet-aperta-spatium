using UnityEngine;

public class hitboxBoss : MonoBehaviour
{
    public GameObject joueur;
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.tag == "perso")
        {
            collision.GetComponent<viePerso>().nbrViePerso -= 1;
            if (Physics.Linecast(transform.position, joueur.transform.position, out RaycastHit hitInfo))
            {
                Vector3 forceBoss = hitInfo.point - joueur.transform.position;
                print(forceBoss.normalized);
                joueur.GetComponent<Rigidbody>().AddForce(-forceBoss.normalized * 15000f);
            }
        }
    }
}
