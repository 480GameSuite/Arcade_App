using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatDestoryer : MonoBehaviour {

    public GameObject platDestroyerPoint;

	// Use this for initialization
	void Start ()
    {
        platDestroyerPoint = GameObject.Find("PlatDestroyerPoint");
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (transform.position.y < platDestroyerPoint.transform.position.y)
        {
            Destroy(gameObject);
        }
		
	}
}
