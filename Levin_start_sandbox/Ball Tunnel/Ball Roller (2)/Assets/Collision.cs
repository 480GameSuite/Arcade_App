using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collision : MonoBehaviour {

    private bool collided = false;

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        collided = true;
    }

    void Update()
    {
        if(collided == true)
        {
            SceneManager.LoadScene("Scene1");
            collided = false;
        }
        collided = false;
    }

}
