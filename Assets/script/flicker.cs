using UnityEngine;

public class flicker : MonoBehaviour
{
    public float intensite;
    public int raritee;
    bool allumee = true;
    void Update()
    {
        int randomNb = Random.Range(1, raritee);
        if(randomNb == 1)
        {
            fermer();
            Invoke("gererFlick", 0.1f);
        }
    }

    void gererFlick()
    {
        if(intensite <= 20)
        {
            allumer();
            Invoke("fermer", 0.3f); 
        }
        else
        {
            allumer();
        }
    }

    void allumer()
    {
        gameObject.GetComponent<Light>().intensity = intensite;
    }

    void fermer()
    {
        gameObject.GetComponent<Light>().intensity = 0;
    }
}
