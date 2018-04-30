using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPopUp : MonoBehaviour
{

	Image popUp;

	GameObject actionNotice;

	private void Awake()

	{
		actionNotice = GameObject.Find("ActionNotice");
		popUp = actionNotice.GetComponent<Image>();
		popUp.enabled = false;
	}

	void OnTriggerEnter(Collider other)

	{
		if (other.tag == "Player")

		{
			popUp.enabled = true;

		}

	}

	void OnTriggerExit(Collider other)

	{
		if (other.tag == "Player")

		{
			popUp.enabled = false;

		}

	}
}
