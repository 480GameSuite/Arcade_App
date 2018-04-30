using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


[RequireComponent(typeof(Rigidbody2D))]
public class Jumpy : MonoBehaviour
{
    public Transform cameraPos;
    public GameManager gameManager;
    public float movementSpeed = 2.5f;
    public Rigidbody2D rb;
    public bool started;
    public float timer;

    private float left_x = -3.65f;
    private float right_x = 3.65f;
    private float move = 0f;
    private GameManager _gameManager;
    private GameObject _deathObject;
    private GameObject[] _platforms;

    // Use this for initialization
    void Start()
    {
        started = false;
        _deathObject = GameObject.Find("DeathObject");
        _gameManager = GameObject.Find("MainCanvas").GetComponent<GameManager>();
        cameraPos = GameObject.FindGameObjectWithTag("MainCamera").transform;
        rb = GetComponent<Rigidbody2D>();
        transform.position = new Vector3(0, 3, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < _deathObject.transform.position.y)
        {
            _platforms = GameObject.FindGameObjectsWithTag("Platform");
            _gameManager.gameOver = true;
            rb.gravityScale = 0;

            for (var i = 0; i < _platforms.Length; i++)
            {
                Destroy(_platforms[i]);
            }
        }

        if(_gameManager.gameOver == false)
        {
            timer += Time.deltaTime;
            rb.gravityScale = 1;
            started = true;
            movement(); 
        }
    }

    private void FixedUpdate()
    {
        Vector2 velocity = rb.velocity;
        velocity.x = move;
        rb.velocity = velocity;
    }

    private void movement()
    {
        float horizontalTouch = CrossPlatformInputManager.GetAxis("Horizontal") * movementSpeed;
        transform.Translate(Vector3.right * movementSpeed * horizontalTouch * Time.deltaTime);

        //transform.Translate(new Vector3(Input.acceleration.x, Input.acceleration.y, 0) * 3.5f * Time.deltaTime);

        move = Input.GetAxis("Horizontal") * movementSpeed;

        if (transform.position.x < left_x)
        {
            transform.position = new Vector3(right_x, transform.position.y, transform.position.z);
        }

        if (transform.position.x > right_x)
        {
            transform.position = new Vector3(left_x, transform.position.y, transform.position.z);
        }
    }
}

