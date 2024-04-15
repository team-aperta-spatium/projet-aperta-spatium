using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uiToggleAmelioration : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnToggleChanged(bool toggle)
    {
        testUI.toggleBool = toggle;
        
    }
}
