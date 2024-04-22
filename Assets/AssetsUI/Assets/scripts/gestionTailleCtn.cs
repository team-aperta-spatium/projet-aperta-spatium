using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class gestionTailleCtn : MonoBehaviour
{
    public int nbItems;

    public GameObject ctnItem;

    // Start is called before the first frame update
    void Start()
    {
        nouveauItem("test");
        nbItems = gameObject.transform.childCount;
        gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(700f, nbItems * 300f);
        
    }

    public void nouveauItem(string nom)
    {
        GameObject ctnItemClone = Instantiate(ctnItem);
        ctnItemClone.transform.parent = gameObject.transform;
        ctnItemClone.transform.localScale = new Vector3(1f, 1f, 1f);
        GameObject nomEquip = ctnItemClone.transform.GetChild(0).GetChild(0).gameObject;
        nomEquip.GetComponent<TMP_Text>().SetText(nom); 
    }
}
