using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MoveBird : MonoBehaviour
{
    // Local variables
    public bool paused = false;
    public bool started = false;
    public bool move;
    public int invertgravity;
    public bool alreadydidthis = false;
    private bool negated;
    public float time_elapsed;
    public int num_flaps = 0;


    private int is_first = 0;
    public float ymin, ymax, speed;
    bool goingup;
    int count;

    [SerializeField]
    public GameObject score;
    Vector3 score_position = new Vector3(64.40174f, 492.68f, -11.10653f);

    [SerializeField]
    private GameObject option_menu; 
    Vector3 options_position = new Vector3(7.773216f, 377.2434f, 4.754386f);


    // added functions
    public void start_game()
    {

            GetComponent<Rigidbody>().velocity = new Vector3(speed, 0, 0);
            move = true;
            Destroy(GameObject.Find("StartMenu(Clone)"));
            Destroy(GameObject.Find("StartEventSystem"));
            Instantiate(score, score_position, Quaternion.identity);
            started = true;
            time_elapsed += Time.deltaTime;


        alreadydidthis = false;
    }

    public void options()
    {
        if (alreadydidthis == false)
        {
            invertgravity = PlayerPrefs.GetInt("invertgravity", 0);
            paused = true;
            Destroy(GameObject.Find("StartMenu(Clone)"));
            Instantiate(option_menu, options_position, Quaternion.identity);
            GameObject.Find("Options(Clone)").GetComponent<Options>().active = true;
            alreadydidthis = true;
        }
    }


    // Start/Update
    // Use this for initialization
    void Start()
    {
         
        speed = PlayerPrefs.GetFloat("speed", .75f);
        GetComponent<Rigidbody>().useGravity = false;
        invertgravity = PlayerPrefs.GetInt("invertgravity", 0);
        alreadydidthis = false;
    }


    // Update is called once per frame
    void Update()
    {

        if(invertgravity==1 && started == false)
        {
            GameObject.Find("birdy").GetComponent<Rigidbody>().transform.position = new Vector3(
                GameObject.Find("birdy").GetComponent<Rigidbody>().transform.position.x,
                -1.8f,
                GameObject.Find("birdy").GetComponent<Rigidbody>().transform.position.z);
            Physics.gravity = new Vector3(Mathf.Abs(Physics.gravity.x), Mathf.Abs(Physics.gravity.y), Mathf.Abs(Physics.gravity.z));

        }
        if (!paused)
        {
            if ((Input.anyKeyDown) && (started==false))
            {
                GameObject.Find("BeginButton").GetComponent<Button>().onClick.AddListener(start_game);
                GameObject.Find("OptButton").GetComponent<Button>().onClick.AddListener(options);
            }

            if (is_first == 0 && move == true && invertgravity==0)
            {
                GetComponent<Rigidbody>().velocity = new Vector3(speed, 0, 0);
            }

            if (move && (invertgravity==0))
            {
                GetComponent<Rigidbody>().useGravity = true;
                count++;
                is_first++;
                time_elapsed += Time.deltaTime;
                if (Input.anyKeyDown)
                {
                    GetComponent<Rigidbody>().velocity = new Vector3(speed, 3.85f, 0);
                    goingup = true;
                    num_flaps++;
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
            if(move && (invertgravity==1))
            {
                GetComponent<Rigidbody>().useGravity = true;
                if(GetComponent<Rigidbody>().transform.position.y >= 2.39)
                {
                    GameObject.Find("Generator").GetComponent<Generator>().gravityinvertdeath = true;
                }

                count++;
                is_first++;
                time_elapsed += Time.deltaTime;
                if (Input.anyKeyDown)
                {
                    GetComponent<Rigidbody>().velocity = new Vector3(speed, -3.85f, 0);
                    goingup = true;
                    num_flaps++;
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
    }
}
