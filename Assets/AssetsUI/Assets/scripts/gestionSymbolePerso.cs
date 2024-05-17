using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gestionSymbolePerso : MonoBehaviour
{
    private RectTransform rectTransform = null;
    [SerializeField][Range(-200, 200)] private float offsetX = 0f;
    [SerializeField][Range(-200, 200)] private float offsetY = 0f;
    [SerializeField][Range(0, 200)] private float width = 0f;
    [SerializeField][Range(0, 200)] private float height = 0f;
    [Tooltip("If checked then height variable will not be used.")]
    [SerializeField] private bool preserveAspect = false;

    public GameObject perso;
    Vector3 posPerso;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        rectTransform.pivot = Vector2.zero;
        rectTransform.anchorMax = Vector2.zero;
        rectTransform.anchorMin = Vector2.zero;
        posPerso = perso.transform.position;
    }
    void Update()
    {
        rectTransform.sizeDelta = new Vector2(Screen.width * width / 100, ((preserveAspect) ? Screen.width * width : Screen.height * height) / 100);
        rectTransform.anchoredPosition = new Vector2(Screen.width * offsetX / 100, Screen.height * offsetY / 100);
    }
}
