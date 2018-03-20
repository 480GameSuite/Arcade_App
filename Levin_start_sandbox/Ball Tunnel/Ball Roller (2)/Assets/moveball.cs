using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveball : MonoBehaviour {

    public float speed;
    public float xmin, xmax;

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(moveHorizontal, 0, 1);
        GetComponent<Rigidbody>().velocity = movement;

        GetComponent<Rigidbody>().position = new Vector3(Mathf.Clamp(GetComponent<Rigidbody>().position.x, xmin, xmax), GetComponent<Rigidbody>().position.y ,GetComponent<Rigidbody>().position.z);
    }

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {

    }
}
