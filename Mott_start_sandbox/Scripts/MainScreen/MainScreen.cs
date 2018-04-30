using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainScreen : MonoBehaviour
{

    AsyncOperation ao;

    public GameObject loadingScrenBG;
    public GameObject optionsScreenBG;
    public Slider progBar;
    public Text loadingText;
    public GameObject Stats;
    public GameObject ResetButton;
    private bool home;
    private bool loading;
    private bool options;

    private bool _started_birdle;
    private bool _started_jumpy;
    private bool _started_snake;
    private bool _started_roller;



    [SerializeField]
    public GameObject optionsButton;

    [SerializeField]
    public GameObject scoresButton;

    [SerializeField]
    public GameObject BirdleJumpButton;

    [SerializeField]
    public GameObject JumpyJumpButton;

    [SerializeField]
    public GameObject SnakeButton;

    [SerializeField]
    public GameObject BallRollerButton;


    // Use this for initialization
    void Start()
    {
        home = true;
        loading = false;
        options = false;
        if (SceneManager.GetActiveScene().name != "MainScreen")
        {
            SceneManager.LoadScene("MainScreen");
            _started_birdle = false;
            _started_jumpy = false;
            _started_snake = false;
            _started_roller = false;
        }
    }

    void start_birdle_jump()
    {
        home = false;
        loading = true;
        loadingScrenBG.SetActive(true);
        progBar.gameObject.SetActive(true);
        loadingText.gameObject.gameObject.SetActive(true);

        loadingText.text = "Loading...";
        if (!_started_birdle)
        {
            StartCoroutine(LoadBirdleJump());
            _started_birdle = true;
        }

    }

    IEnumerator LoadBirdleJump()
    {
        yield return new WaitForSeconds(1);

        ao = SceneManager.LoadSceneAsync("BirdleJump");
        ao.allowSceneActivation = false;

        while (!ao.isDone)
        {
            progBar.value = ao.progress;
            yield return null;
            if (ao.progress >= .89f && ao.progress <= .91f)
            {
                loadingText.text = "Tap to continue";
                if (Input.anyKeyDown)
                {
                    _started_birdle = false;
                    ao.allowSceneActivation = true;
                }
            }
        }

    }

    void start_jumpy_jump()
    {
        home = false;
        loading = true;
        loadingScrenBG.SetActive(true);
        progBar.gameObject.SetActive(true);
        loadingText.gameObject.gameObject.SetActive(true);

        loadingText.text = "Loading...";
        if (!_started_birdle)
        {
            StartCoroutine(LoadJumpyJump());
            _started_birdle = true;
        }
    }

    IEnumerator LoadJumpyJump()
    {
        yield return new WaitForSeconds(1);

        ao = SceneManager.LoadSceneAsync("JumpyJumpy");
        ao.allowSceneActivation = false;

        while (!ao.isDone)
        {
            progBar.value = ao.progress;
            yield return null;
            if (ao.progress >= .89f && ao.progress <= .91f)
            {
                loadingText.text = "Tap to continue";
                if (Input.anyKeyDown)
                {
                    _started_jumpy = false;
                    ao.allowSceneActivation = true;
                }
            }
        }
    }


    void start_snake()
    {
        home = false;
        loading = true;
        loadingScrenBG.SetActive(true);
        progBar.gameObject.SetActive(true);
        loadingText.gameObject.gameObject.SetActive(true);

        loadingText.text = "Loading...";
        if (!_started_snake)
        {
            StartCoroutine(LoadSnake());
            _started_snake = true;
        }
    }

    IEnumerator LoadSnake()
    {
        yield return new WaitForSeconds(1);

        ao = SceneManager.LoadSceneAsync("Snake");
        ao.allowSceneActivation = false;

        while (!ao.isDone)
        {
            progBar.value = ao.progress;
            yield return null;
            if (ao.progress >= .89f && ao.progress <= .91f)
            {
                loadingText.text = "Tap to continue";
                if (Input.anyKeyDown)
                {
                    _started_snake = false;
                    ao.allowSceneActivation = true;
                }
            }
        }
    }


    void start_ball_roller()
    {
        home = false;
        loading = true;
        loadingScrenBG.SetActive(true);
        progBar.gameObject.SetActive(true);
        loadingText.gameObject.gameObject.SetActive(true);

        loadingText.text = "Loading...";
        if (!_started_roller)
        {
            StartCoroutine(LoadBallRoller());
            _started_roller = true;
        }
    }

    IEnumerator LoadBallRoller()
    {
        yield return new WaitForSeconds(1);

        ao = SceneManager.LoadSceneAsync("BallRoller");
        ao.allowSceneActivation = false;

        while (!ao.isDone)
        {
            progBar.value = ao.progress;
            yield return null;
            if (ao.progress >= .89f && ao.progress <= .91f)
            {
                loadingText.text = "Tap to continue";
                if (Input.anyKeyDown)
                {
                    _started_roller = false;
                    ao.allowSceneActivation = true;
                }
            }
        }
    }

    private void open_stats()
    {
        home = false;
        Stats.SetActive(true);

        GameObject.Find("StatsGameObject").GetComponent<LoadScores>().viewingScores = true;

    }

    private void open_options()
    {
        home = false;
        options = true;
        optionsScreenBG.SetActive(true);
        ResetButton.SetActive(true);
    }

    private void reset_stats()
    {
        PlayerPrefs.DeleteAll();
    }

    // Update is called once per frame
    void Update()
    {
        BirdleJumpButton.GetComponent<Button>().onClick.AddListener(start_birdle_jump);
        JumpyJumpButton.GetComponent<Button>().onClick.AddListener(start_jumpy_jump);
        SnakeButton.GetComponent<Button>().onClick.AddListener(start_snake);
        BallRollerButton.GetComponent<Button>().onClick.AddListener(start_ball_roller);
        optionsButton.GetComponent<Button>().onClick.AddListener(open_options);

        ResetButton.GetComponentInChildren<Button>().onClick.AddListener(reset_stats);

        scoresButton.GetComponentInChildren<Button>().onClick.AddListener(open_stats);

        if (Input.GetKeyDown("escape") && home == false && loading == false)
        {
            Stats.SetActive(false);
            loadingScrenBG.SetActive(false);
            optionsScreenBG.SetActive(false);
            ResetButton.SetActive(false);
            home = true;
            options = false;
        }
        else if (Input.GetKeyDown("escape") && home == true && loading == false)
        {
            Application.Quit();   
        }
        else if (Input.GetKeyDown("escape") && home == false && loading == true)
        {
            SceneManager.LoadScene("MainScreen");
        }
    }
}
