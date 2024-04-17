using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class couleurBtn : MonoBehaviour
{
    public TextMeshProUGUI txtbtn;
    public void hover()
    {
        txtbtn.color = new Color(0.7529f, 0.5607f, 0.9607f, 1f);
    }

    public void exit()
    {
        txtbtn.color = Color.yellow;
    }
}
