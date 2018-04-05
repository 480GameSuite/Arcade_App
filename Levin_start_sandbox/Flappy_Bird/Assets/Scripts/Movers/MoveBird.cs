using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBird : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody>().velocity = new Vector3(.5f, 0, 0);
	}

    bool goingup;
    int count;
    public float ymin, ymax;
    public float speed;

	// Update is called once per frame
	void Update () {
        count++;
        if(Input.anyKeyDown)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(speed, 3.85f, 0);
            goingup = true;
        }
        if((count <= 5) && (goingup == true)) 
        {
            GetComponent<Rigidbody>().velocity = new Vector3(speed, 0, 0);
            goingup = false;
        }

        GetComponent<Rigidbody>().position = new Vector3(
            GetComponent<Rigidbody>().position.x,
            Mathf.Clamp(GetComponent<Rigidbody>().position.y, ymin, ymax),
            GetComponent<Rigidbody>().position.z
            );
        if(GetComponent<Rigidbody>().position.y <= -2.4)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(speed, 2, 0);
        }
        if (GetComponent<Rigidbody>().position.y >= 2.4)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(speed, 0, 0);
        }
        
	}
}
