using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour {

    private float _randx;
    private float _randy;

	// Use this for initialization
	void Start () 
    {
        transform.position = new Vector3(14f, 35f);
	}
	
	public void SpawnFood()
    {
        _randx = Random.Range(-20.5f, 20.5f);
        _randy = Random.Range(-41.7f, 41.7f);

        transform.position = new Vector3(_randx, _randy);
    }
}
