using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using TMPro;

public class Click : MonoBehaviour, IPointerClickHandler
{
	//public GameObject descEquip;
	//public TMP_Text nom;
	//public void OnPointerEnter(PointerEventData eventData)
	//{
	//	descEquip.SetActive(true);
	//	nom.color = new Color(0.7529f, 0.5607f, 0.9607f, 1f);
	//}
	//
	//public void OnPointerExit(PointerEventData eventData)
	//{
	//	descEquip.SetActive(false);
	//	nom.color = Color.yellow;
	//}

	public void OnPointerClick(PointerEventData eventData)
	{
		GetComponent<testUI>().SetActif();

		if (gameObject.name == "tripleSaut")
		{
			GetComponent<testUI>().AfficherTripleSaut();
		}
		else if (gameObject.name == "doubleDash")
		{
			GetComponent<testUI>().AfficherDoubleDash();
		}
		else if (gameObject.name == "dashRapide")
		{
			GetComponent<testUI>().AfficherDashRapide();
		}
		else if (gameObject.name == "ralentiTemps")
		{
			GetComponent<testUI>().AfficherRalentiTemps();
		}
		else if (gameObject.name == "clonage")
		{
			GetComponent<testUI>().AfficherClonage();
		}
		else if (gameObject.name == "attaqueTornade")
		{
			GetComponent<testUI>().AfficherAttaqueTornade();
		}
	}

}