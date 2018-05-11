using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Camera : MonoBehaviour {

    public Transform player;
    public float camSpeed = 13f;
	
	// Update is called once per frame
	void LateUpdate () 
    {
        if (player.transform.position.y > transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
        }

        if(Input.GetKeyDown("escape"))
        {
            SceneManager.LoadScene("MainScreen");
        }
	}
}
