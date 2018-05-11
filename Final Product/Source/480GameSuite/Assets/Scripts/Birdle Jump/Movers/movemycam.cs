using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class movemycam : MonoBehaviour {

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

        if (Input.GetKeyDown("escape"))
        {
            SceneManager.LoadScene("MainScreen");
        }
	}
}
