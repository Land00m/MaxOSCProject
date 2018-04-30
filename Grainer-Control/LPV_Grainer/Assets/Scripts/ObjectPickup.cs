using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPickup : MonoBehaviour {


    public GameObject item;
    public GameObject tempParent;
    public Transform guide;
    public bool playerInRange;

	// Use this for initialization
	void Start () {

        item.GetComponent<Rigidbody>().useGravity = true;
	}
	
	// Update is called once per frame
	void Update () {

        if (playerInRange == true && Input.GetMouseButtonDown(0))
        {
            PickUp();
        }

        if (playerInRange == true && Input.GetMouseButtonUp(0))
		{
            PutDown();
		}

	}

    void PickUp()
    {
        item.GetComponent<Rigidbody>().useGravity = false;
        item.GetComponent<Rigidbody>().isKinematic = true;
        item.transform.position = guide.transform.position;
        item.transform.rotation = guide.transform.rotation;
        item.transform.parent = tempParent.transform;
    }

    void PutDown()
    {
		item.GetComponent<Rigidbody>().useGravity = true;
        item.GetComponent<Rigidbody>().isKinematic = false;
        item.transform.parent = null;
        item.transform.position = guide.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
		if (other.tag == "Player")
		{
            playerInRange = false;
		}
    }

}
