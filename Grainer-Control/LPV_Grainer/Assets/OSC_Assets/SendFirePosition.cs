using System.Collections;
using UnityEngine;

public class SendFirePosition : MonoBehaviour
{

	public OSC osc;


	// Update is called once per frame
	void Update()
	{


		OscMessage message = new OscMessage();

		message.address = "/KnobSizeXYZ";
		message.values.Add(transform.position.x);
		message.values.Add(transform.position.y);
		message.values.Add(transform.position.z);
		osc.Send(message);

		message = new OscMessage();
		message.address = "/KnobSizeX";
		message.values.Add(transform.position.x);
		osc.Send(message);

		message = new OscMessage();
		message.address = "/KnobSizeY";
		message.values.Add(transform.position.y);
		osc.Send(message);

		message = new OscMessage();
		message.address = "/KnobSizeZ";
		message.values.Add(transform.position.z);
		osc.Send(message);

	}
}

