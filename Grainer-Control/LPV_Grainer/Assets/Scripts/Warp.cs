using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Warp : MonoBehaviour

{

	public Transform warpTarget;
	public bool inTrigger;

	GameObject player;
	Animator anim;
	SimpleCharacterControl characterControl;
	//AudioSource audio;

	void Start()

	{
		characterControl = GameObject.Find("Player").GetComponent<SimpleCharacterControl>();
		anim = GameObject.Find("Player").GetComponent<Animator>();
		//audio = gameObject.GetComponent<AudioSource>();
		player = GameObject.Find("Player");

		inTrigger = false;
	}

	void Update()

	{

		if (inTrigger == true && Input.GetKeyDown(KeyCode.E))

		{
			//audio.Play();

			characterControl.enabled = false;

			anim.enabled = false;

			player.transform.position = warpTarget.position;

			//audio.Play();

			anim.enabled = true;

			characterControl.enabled = true;
		}
	}

	void OnTriggerEnter(Collider other)

	{
		if (other.tag == "Player")

		{
			inTrigger = true;
		}
	}

	void OnTriggerStay(Collider other)

	{
		if (other.tag == "Player")

		{
			inTrigger = true;

		}
	}

	void OnTriggerExit(Collider other)

	{
		if (other.tag == "Player")

		{
			inTrigger = false;

		}
	}
}