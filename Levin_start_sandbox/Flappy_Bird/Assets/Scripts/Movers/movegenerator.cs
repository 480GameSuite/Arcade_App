using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movegenerator : MonoBehaviour
{

    public GameObject bird;
    // Use this for initialization
    void Start()
    {
        bird = GameObject.Find("birdy");
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Transform>().position = bird.transform.position;
    }
}