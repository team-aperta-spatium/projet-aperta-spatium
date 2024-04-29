using UnityEngine;

public class hitbox : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.tag == "perso")
        {
            collision.GetComponent<viePerso>().nbrViePerso -= 1;
        }
    }
}
