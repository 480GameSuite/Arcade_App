using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movecam : MonoBehaviour {

    public GameObject ball;

    private Vector3 offset;

	// Use this for initialization
	void Start () {

        offset = transform.position - ball.transform.position;
        
        //GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 2);



	}
	
	// Update is called once per frame
	void LateUpdate () {

        transform.position = new Vector3(0, 2.54f, ball.transform.position.z + offset.z);
		
	}
}
