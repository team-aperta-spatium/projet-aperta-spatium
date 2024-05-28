using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class camera1p : MonoBehaviour
{

    public float sensX;
    public float sensY;

    public Transform orientation;

    float rotationX;
    float rotationY;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float sourisX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float sourisY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        rotationY += sourisX;
        rotationX -= sourisY;

        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        transform.rotation = Quaternion.Euler(rotationX, rotationY, 0);
        orientation.rotation = Quaternion.Euler(0, rotationY, 0);
    }

    public void FaireFov(float valeurFin)
    {
        GetComponent<Camera>().DOFieldOfView(valeurFin, 0.25f);
    }
}
