using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour 
{
    public GameObject point_of_destruction;

	// Use this for initialization
	void Start () 
    {
        point_of_destruction = GameObject.Find("destroyer");
	}
	
	// Update is called once per frame
	void Update () 
    {
        if(transform.position.x < point_of_destruction.transform.position.x)
        {
            Destroy(gameObject);
        }
	}
}
