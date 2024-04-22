using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pieChart : MonoBehaviour
{
    public Image imagePieChart;
    public float valeur;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        imagePieChart.fillAmount = valeur;
    }
}
