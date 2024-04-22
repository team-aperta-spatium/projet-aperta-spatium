using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera3 : MonoBehaviour
{

    public Transform orientation;
    public Transform perso;
    public Transform persoObj;
    public Transform cibleCameraCombat;
    public Rigidbody rb;

    public float vitesseRotation;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 dirVue = perso.position - new Vector3(transform.position.x, perso.position.y, transform.position.z);
        //orientation.forward = dirVue.normalized;
        //
        //float h = Input.GetAxis("Horizontal");
        //float v = Input.GetAxis("Vertical");
        //Vector3 dirInput = orientation.forward * v + orientation.right * h;
        //
        //if (dirInput != Vector3.zero)
        //{
        //    persoObj.forward = Vector3.Slerp(persoObj.forward, dirInput.normalized, Time.deltaTime * vitesseRotation);
        //}

        Vector3 dirVueCombat = cibleCameraCombat.position - new Vector3(transform.position.x, cibleCameraCombat.position.y, transform.position.z);
        orientation.forward = dirVueCombat.normalized;

        persoObj.forward = dirVueCombat.normalized;
    }
}
