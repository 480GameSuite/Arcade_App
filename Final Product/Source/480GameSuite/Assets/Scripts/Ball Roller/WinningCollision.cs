using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinningCollision : MonoBehaviour {

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        GameObject.Find("CeilingR(1)").GetComponent<Collision>().won = true;
        Debug.Log("winner!");
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
