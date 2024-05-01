using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class obstacleEst : MonoBehaviour
{
    private float e;
    public float vitesseObstacle;
    float vitesseReel;
    public GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        e = canvas.GetComponent<RectTransform>().sizeDelta.y / canvas.GetComponent<RectTransform>().sizeDelta.x;
        vitesseReel = vitesseObstacle * (canvas.GetComponent<RectTransform>().sizeDelta.x / canvas.GetComponent<RectTransform>().sizeDelta.y);
        //GetComponent<RectTransform>().anchoredPosition = new Vector2(canvas.transform.position.x /2.5f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        RectTransform obstacle = GetComponent<RectTransform>();
        obstacle.anchoredPosition = new Vector2(obstacle.anchoredPosition.x - vitesseReel, obstacle.anchoredPosition.y);
        obstacle.sizeDelta = new Vector2(40f, (e*obstacle.anchoredPosition.x) - (-e*obstacle.anchoredPosition.x));
        GetComponent<BoxCollider2D>().size = new Vector2(40f, (e * obstacle.anchoredPosition.x) - (-e * obstacle.anchoredPosition.x));
        if (GetComponent<RectTransform>().anchoredPosition.x < 0f)
        {
            Destroy(gameObject);
        }
    }
}
