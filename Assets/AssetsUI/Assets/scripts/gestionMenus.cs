using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class gestionMenus : MonoBehaviour
{
    public GameObject menuPause;
    public GameObject menuEquip;
    public GameObject menuMap;

    public GameObject mapNW;
    public GameObject mapNE;
    public GameObject mapSW;
    public GameObject mapSE;
    public GameObject etoile1;
    public GameObject etoile2;
    public TMP_Text nomPartieMap;
    public TMP_Text quete1;
    public TMP_Text quete2;
    public TMP_Text quete3;

    public float posPause;
    public float posEquip;
    public float posMap;

    public Texture2D imgMapNW;
    public Texture2D imgMapNE;
    public Texture2D imgMapSW;
    public Texture2D imgMapSE;

    public GameObject menu;

    public static bool enPause;

    public TextAsset infoMap;

    public GameObject conteneur;
    public GameObject equipement;
    public TextMeshPro nomDescEquip;
    public TextMeshPro DescEquip;
    int nbItems;

    [System.Serializable]
    public class DonneeMap
    {
        public string donneeNomPartieMap;
        public string donneeQuete1;
        public string donneeQuete2;
        public string donneeQuete3;
    }
    [System.Serializable]
    public class DonneeMapList
    {
        public DonneeMap[] map;
    }
    public DonneeMapList mapList = new DonneeMapList();

    // Start is called before the first frame update
    void Start()
    {
        menu.SetActive(false);
        Time.timeScale = 1f;
        enPause = false;

        posPause = 0;
        posEquip = 1920;
        posMap = -1920;

        mapList = JsonUtility.FromJson<DonneeMapList>(infoMap.text);
    }
    private void Update()
    {
        menuPause.GetComponent<RectTransform>().anchoredPosition = new Vector2(posPause, 0);
        menuEquip.GetComponent<RectTransform>().anchoredPosition = new Vector2(posEquip, 0);
        menuMap.GetComponent<RectTransform>().anchoredPosition = new Vector2(posMap, 0);

        nbItems = conteneur.GetComponentsInChildren<Animator>().GetLength(0);
        conteneur.GetComponent<RectTransform>().sizeDelta = new Vector2(700f, nbItems * 300f);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (enPause)
            {
                depause();
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            else
            {
                pause();
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            ajoutEquip("test");
        }
    }

    public void Gauche()
    {
        posPause = posPause + 1920;
        posEquip = posEquip + 1920;
        posMap = posMap + 1920;
    }

    public void Droite()
    {
        posPause = posPause - 1920;
        posEquip = posEquip - 1920;
        posMap = posMap - 1920;
    }

    public void hoverMap(GameObject cible)
    {
        int nbMap = 0;
        if(cible.name == "NW")
        {
            nbMap = 0;
            cible.GetComponent<RawImage>().texture = imgMapNW;
            etoile1.SetActive(true);
            etoile2.SetActive(false);
        }
        else if (cible.name == "NE")
        {
            nbMap = 1;
            cible.GetComponent<RawImage>().texture = imgMapNE;
            etoile1.SetActive(false);
            etoile2.SetActive(false);
        }
        else if (cible.name == "SW")
        {
            nbMap = 2;
            cible.GetComponent<RawImage>().texture = imgMapSW;
            etoile1.SetActive(true);
            etoile2.SetActive(true);
        }
        else
        {
            nbMap = 3;
            cible.GetComponent<RawImage>().texture = imgMapSE;
            etoile1.SetActive(false);
            etoile2.SetActive(false);
        }
        nomPartieMap.SetText(mapList.map[nbMap].donneeNomPartieMap);
        quete1.SetText(mapList.map[nbMap].donneeQuete1);
        quete2.SetText(mapList.map[nbMap].donneeQuete2);
        quete3.SetText(mapList.map[nbMap].donneeQuete3);
        
    }

    public void deHoverMap(GameObject cible)
    {
        nomPartieMap.SetText("Aperta Spatium");
        quete1.SetText("");
        quete2.SetText("");
        quete3.SetText("");
    }

    public void ajoutEquip(string nom)
    {
        GameObject ctnItemClone = Instantiate(equipement);
        ctnItemClone.transform.parent = conteneur.transform;
        ctnItemClone.transform.localScale = new Vector3(1f, 1f, 1f);
        GameObject nomEquip = ctnItemClone.transform.GetChild(0).GetChild(0).gameObject;
        nomEquip.GetComponent<TMP_Text>().SetText(nom);
    }

    public void depause()
    {
        menu.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        enPause = false;
    }

    public void pause()
    {
        menu.SetActive(true);
        Time.timeScale = 0f;
        enPause = true;
    }

    public void quitter()
    {
        SceneManager.LoadScene(0);
    }
}
