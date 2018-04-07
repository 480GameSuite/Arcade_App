using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class collider_ : MonoBehaviour {

    public bool collided = false;
    public bool already = false;

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (!already)
        {
            collided = true;
        }
    }

    void Update()
    {
        if (collided == true)
        {
            GameObject.Find("birdy").GetComponent<MoveBird>().paused = true;
            //This line of code will restart the game
            //SceneManager.LoadScene("Scene1");
        }
    }

}