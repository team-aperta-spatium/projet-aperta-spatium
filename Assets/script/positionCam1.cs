using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class positionCam1 : MonoBehaviour
{

    public Transform positionCamera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = positionCamera.position;
    }
}
