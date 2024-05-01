using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class obstacleSud : MonoBehaviour
{
    private float e;
    public float vitesseObstacle;
    float vitesseReel;
    public GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        e = canvas.GetComponent<RectTransform>().sizeDelta.x / canvas.GetComponent<RectTransform>().sizeDelta.y;
        vitesseReel = -vitesseObstacle * (canvas.GetComponent<RectTransform>().sizeDelta.y / canvas.GetComponent<RectTransform>().sizeDelta.x);
        //GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, -canvas.transform.position.y * 3 / 4);
    }

    // Update is called once per frame
    void Update()
    {
        RectTransform obstacle = GetComponent<RectTransform>();
        obstacle.anchoredPosition = new Vector2(obstacle.anchoredPosition.x, obstacle.anchoredPosition.y - -vitesseObstacle);
        obstacle.sizeDelta = new Vector2(-((e * obstacle.anchoredPosition.y) - (-e * obstacle.anchoredPosition.y)), 40f);
        GetComponent<BoxCollider2D>().size = new Vector2(-((e * obstacle.anchoredPosition.y) - (-e * obstacle.anchoredPosition.y)), 40f);
        if (GetComponent<RectTransform>().anchoredPosition.y > 0f)
        {
            Destroy(gameObject);
        }
    }
}
