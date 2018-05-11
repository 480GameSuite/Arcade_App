using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class moveball : MonoBehaviour {

    public float speed;
    public float xmin, xmax;
    public float game_time;

    private void Start()
    {
        game_time = 0;
    }

    private void FixedUpdate()
    {
        game_time += Time.deltaTime;
        float moveHorizontal = Input.acceleration.x * 4;
        Vector3 movement = new Vector3(moveHorizontal, 0, 1.5f);
        GetComponent<Rigidbody>().velocity = movement;

        GetComponent<Rigidbody>().position = new Vector3(Mathf.Clamp(GetComponent<Rigidbody>().position.x, xmin, xmax), GetComponent<Rigidbody>().position.y ,GetComponent<Rigidbody>().position.z);
    }

}
