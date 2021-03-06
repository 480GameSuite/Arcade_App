﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;


public class Generator : MonoBehaviour
{
    public bool wait_to_start_over;

    public void start_over()
    {
        PlayerPrefs.SetFloat("speed", GameObject.Find("birdy").GetComponent<MoveBird>().speed);
        SceneManager.LoadScene("BirdleJump");
        GameObject.Find("birdy").GetComponent<MoveBird>().invertgravity = PlayerPrefs.GetInt("invertgravity",0);
        GameObject.Find("birdy").GetComponent<MoveBird>().paused = false;
        System.Threading.Thread.Sleep(250);
    }

    public int num_pipes;
    public float xmin = .2f;
    public float xmax = 2.5f;
    public float down_y_min = 1.7f;
    public float down_y_max = 4.45f;

    private int count = 0;
    public bool gravityinvertdeath = false;

    public float pipe_distance = 5.75f;

    private Vector3 downPosition;
    private float max_x;
    private Vector3 upPosition;
    private Vector3 groundPosition;

    [SerializeField]
    private GameObject downpipe_prefab;

    [SerializeField]
    private GameObject uppipe_prefab;

    [SerializeField]
    private GameObject ground;

    [SerializeField]
    private Transform player;

    [SerializeField]
    private GameObject end_menu;

    [SerializeField]
    private GameObject startmenu;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        downPosition = new Vector3();
        upPosition = new Vector3();
        groundPosition = new Vector3();
        max_x = 0;
        create_pipes();
        Instantiate(startmenu, new Vector3(0,0,0), Quaternion.identity);
        Instantiate(ground, new Vector3(0, .35f, 0), Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.x >= (max_x - 6f) && (GameObject.Find("birdy").GetComponent<Rigidbody>().velocity.x > 0))
        {
            create_pipes();
        }
        GameObject birdy = GameObject.Find("birdy");
        float curr_score = (int)Mathf.Floor(birdy.transform.position.x);
        curr_score = .66666667f * curr_score;
        int my_score = (int)curr_score;


        if (GameObject.Find("CurrScore"))
        {
            GameObject score_area = GameObject.Find("CurrScore");
            score_area.GetComponentInChildren<Text>().text = my_score.ToString();
        }

        if(GameObject.Find("birdy").GetComponent<collider_>().collided == true || gravityinvertdeath == true)
        {
            Destroy(GameObject.Find("r_ScoreObject"));

            if(my_score > PlayerPrefs.GetInt("BirdleHighScore", 0) && (my_score > 0))
            {
                PlayerPrefs.SetInt("BirdleHighScore", my_score);
            }
            GameObject.Find("birdy").GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            Instantiate(end_menu, new Vector3(), Quaternion.identity);
            GameObject.Find("HighScore").GetComponent<Text>().text += my_score.ToString();
            GameObject.Find("HighScore").GetComponent<Text>().text += "\nHIGH SCORE:\n" + PlayerPrefs.GetInt("BirdleHighScore", 0).ToString();

            GameObject.Find("birdy").GetComponent<collider_>().collided = false;
            GameObject.Find("birdy").GetComponent<collider_>().already = true;
            Destroy(GameObject.Find("r_ScoreObject(Clone)"));
            wait_to_start_over = true;
            gravityinvertdeath = false;
            float time_elapsed = GameObject.Find("birdy").GetComponent<MoveBird>().time_elapsed;
            if(time_elapsed > PlayerPrefs.GetInt("bidle_time_elapsed", 0))
            {
                PlayerPrefs.SetInt("birdle_time_elapsed", (int)time_elapsed);
            }
            PlayerPrefs.SetInt("bjNumFlaps", PlayerPrefs.GetInt("bjNumFlaps", 0) + GameObject.Find("birdy").GetComponent<MoveBird>().num_flaps);
            PlayerPrefs.SetInt("bjTimePlayed",(int)(PlayerPrefs.GetInt("bjTimePlayed", 0) + time_elapsed));
        }
        if(wait_to_start_over)
        {
            GameObject.Find("birdy").GetComponent<MoveBird>().paused = true;
        }
        if(wait_to_start_over == true && Input.anyKeyDown)
        {
            start_over();
        }

    }

    private void create_pipes()
    {
        for (int i = 0; i <= num_pipes; i++)
        {
            downPosition.y = Random.Range(down_y_min, down_y_max);
            upPosition.y = downPosition.y - pipe_distance;

            downPosition.x += 1.5f;
            upPosition.x += 1.5f;

            downPosition.x = Mathf.Clamp(downPosition.x, 2, 99999999999);
            upPosition.x = Mathf.Clamp(upPosition.x, 2, 99999999999);


            if (count == 1)
            {
                groundPosition.x += 3.36f;
                groundPosition.y = .35f;
                Instantiate(ground, groundPosition, Quaternion.identity);
                count = 0;

            }
            else
            {
                count++;
            }

            Instantiate(downpipe_prefab, downPosition, Quaternion.identity);
            Instantiate(uppipe_prefab, upPosition, Quaternion.identity);

            if (downPosition.x > max_x)
            {
                max_x = downPosition.x;
            }
        }
    }
}
