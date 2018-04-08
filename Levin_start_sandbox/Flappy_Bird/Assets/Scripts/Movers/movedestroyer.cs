using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movedestroyer : MonoBehaviour {

    public GameObject cam;

	// Use this for initialization
	void Start () 
    {
        cam = GameObject.Find("Main Camera");
        GetComponent<Rigidbody>().velocity = cam.GetComponent<Rigidbody>().velocity;
    }
}
