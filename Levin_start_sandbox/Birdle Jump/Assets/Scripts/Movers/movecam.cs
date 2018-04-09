using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movecam : MonoBehaviour {
    
    public GameObject bird;
	
    // Use this for initialization
	void Start () 
    { 
        bird = GameObject.Find("birdy");
	}
	
	// Update is called once per frame
	void Update ()
    {
        GetComponent<Transform>().position = new Vector3(bird.transform.position.x, 0, -10);
	}
}
