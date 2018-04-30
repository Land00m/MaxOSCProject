using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxTurnerOffer : MonoBehaviour
{

    public int appState;

    public OSC osc;


    // Use this for initialization
    void Start()
    {
        appState = 1;
        OscMessage message = new OscMessage();

		message.address = "/AppState";
        message.values.Add(appState);
		
		osc.Send(message);

		
		
    }

    private void OnApplicationQuit()
    {
        appState = 0;

		OscMessage message = new OscMessage();

		message.address = "/AppState";
		message.values.Add(appState);

		osc.Send(message);
    }

}
