using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveball : MonoBehaviour {

    public float speed;
    public float xmin, xmax;

    private void FixedUpdate()
    {
        float moveHorizontal = Input.acceleration.x * 4;
        Vector3 movement = new Vector3(moveHorizontal, 0, 1.5f);
        GetComponent<Rigidbody>().velocity = movement;

        GetComponent<Rigidbody>().position = new Vector3(Mathf.Clamp(GetComponent<Rigidbody>().position.x, xmin, xmax), GetComponent<Rigidbody>().position.y ,GetComponent<Rigidbody>().position.z);
    }

}
