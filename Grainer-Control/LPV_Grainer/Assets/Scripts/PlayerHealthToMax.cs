using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthToMax : MonoBehaviour {

    public OSC osc;

    public PlayerHealth playerHealth;
    //public int playerCurrentHealth;

	// Use this for initialization
	void Start () {

        playerHealth = gameObject.GetComponent<PlayerHealth>();
        //playerCurrentHealth = playerHealth.currentHealth;

	}
	
	// Update is called once per frame
	void Update () {
		
        OscMessage message = new OscMessage();

		message.address = "/CurrentHealth";
        message.values.Add(playerHealth.currentHealth);
        osc.Send(message);

	}
}
