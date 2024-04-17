using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using TMPro;

public class Click : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
	public GameObject descTripleSaut;
	public TMP_Text nom;
	public void OnPointerEnter(PointerEventData eventData)
	{
		descTripleSaut.SetActive(true);
		nom.color = new Color(0.7529f, 0.5607f, 0.9607f, 1f);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		descTripleSaut.SetActive(false);
		nom.color = Color.yellow;
	}
}