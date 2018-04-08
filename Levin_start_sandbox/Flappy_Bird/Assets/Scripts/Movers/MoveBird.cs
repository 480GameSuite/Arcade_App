using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MoveBird : MonoBehaviour
{
    public bool paused = false;
    public bool started = false;

    public GameObject score;
    Vector3 score_position = new Vector3(64.40174f, 492.68f, -11.10653f);

    Vector3 options_position = new Vector3(7.773216f, 377.2434f, 4.754386f);

    [SerializeField]
    private GameObject option_menu; 

    public void start_game()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(speed, 0, 0);
        move = true;
        Destroy(GameObject.Find("StartMenu(Clone)"));
        Destroy(GameObject.Find("StartEventSystem"));

        Instantiate(score, score_position, Quaternion.identity);
        started = true;


    }

    public void options()
    {
        paused = true;
        Destroy(GameObject.Find("StartMenu(Clone)"));
        Instantiate(option_menu, options_position, Quaternion.identity);
        GameObject.Find("Options(Clone)").GetComponent<Options>().active = true;
    }

    // Use this for initialization
    void Start()
    {

        speed = PlayerPrefs.GetFloat("speed", .75f);
        GetComponent<Rigidbody>().useGravity = false;
        // move = false;
    }

    bool goingup;
    int count;
    public float ymin, ymax;
    public float speed;
    public bool move;
    private int is_first = 0;

    // Update is called once per frame
    void Update()
    {
        if (!paused)
        {
            if ((Input.anyKeyDown) && (started==false))
            {
                GameObject.Find("BeginButton").GetComponent<Button>().onClick.AddListener(start_game);
                GameObject.Find("OptButton").GetComponent<Button>().onClick.AddListener(options);
            }

            if (is_first == 0 && move == true)
            {
                GetComponent<Rigidbody>().velocity = new Vector3(speed, 0, 0);

            }

            if (move)
            {
                GetComponent<Rigidbody>().useGravity = true;
                count++;
                is_first++;
                if (Input.anyKeyDown)
                {
                    GetComponent<Rigidbody>().velocity = new Vector3(speed, 3.85f, 0);
                    goingup = true;
                }
                if ((count <= 5) && (goingup == true))
                {
                    GetComponent<Rigidbody>().velocity = new Vector3(speed, 0, 0);
                    goingup = false;
                }

                GetComponent<Rigidbody>().position = new Vector3(
                    GetComponent<Rigidbody>().position.x,
                    Mathf.Clamp(GetComponent<Rigidbody>().position.y, ymin, ymax),
                    GetComponent<Rigidbody>().position.z
                    );
                if (GetComponent<Rigidbody>().position.y <= -2.4)
                {
                    GetComponent<Rigidbody>().velocity = new Vector3(speed, 2, 0);
                }
                if (GetComponent<Rigidbody>().position.y >= 2.4)
                {
                    GetComponent<Rigidbody>().velocity = new Vector3(speed, 0, 0);
                }
            }
        }
        else
        {

        }

    }
}
