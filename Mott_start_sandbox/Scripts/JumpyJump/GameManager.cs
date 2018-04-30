using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score;
    public Text scoreText;
    public Text finalScoreText;
    public Text highscoreText;
    public GameObject mainMenu;
    public GameObject inGame;
    public GameObject gameOverMenu;
    public bool gameOver;
    public int totalPlatsHit;

    private bool _notInGame;
    private GameObject _jumpy;
    private Transform _camPos;
    //used to make sure the player doesn't keep gaining score
    [SerializeField]
    private bool _scoreCheck = true;
    [SerializeField]
    private GameObject _platformPreFab;
    private LevelGenerator _level;
    private Jumpy _jumpyScript;
    private string _finalTime;

	// Use this for initialization
	void Start ()
    {
        totalPlatsHit = 0;
        _jumpy = GameObject.FindGameObjectWithTag("Player");
        _level = GameObject.Find("Level").GetComponent<LevelGenerator>();
        _jumpyScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Jumpy>();
        _camPos = GameObject.FindGameObjectWithTag("MainCamera").transform;
        mainMenu.SetActive(true);
        gameOver = true;
        _notInGame = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (mainMenu.activeSelf == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                mainMenu.SetActive(false);
                inGame.SetActive(true);
                _level.topPlat = 0f;
                _level.CreatePlatforms();
                gameOver = false;
            }
        }

        if (Mathf.RoundToInt(_camPos.position.y) % 5 == 0 && _scoreCheck)
        {
            score += 5;
            updateScore();
            _scoreCheck = false;
        }

        else if (Mathf.RoundToInt(_camPos.position.y) % 5 > 0)
        {
            _scoreCheck = true;
        }

        if (gameOver == true && mainMenu.activeSelf == false)
        {
            if (!_notInGame)
            {
                gameOverMenu.SetActive(true);
                inGame.SetActive(false);

                handleHighscores();
                
                finalScoreText.text = "Score: " + score;
                _notInGame = true;
                totalPlatsHit = 0;
            }
            if (Input.GetMouseButtonDown(0))
            {
                score = 0;
                updateScore();
                _jumpy.transform.position = new Vector3(0, _camPos.position.y, 0);
                _level.platformPosition = new Vector3(0, _camPos.position.y - 3, 0);
                Instantiate(_platformPreFab, new Vector3(0, _camPos.position.y - 3, 0), Quaternion.identity);
                inGame.SetActive(true);
                gameOverMenu.SetActive(false);
                _level.topPlat = 0f;
                gameOver = false;
                _notInGame = false;

            }
        }
	}

    public void updateScore()
    {
        scoreText.text = "Score: " + score;
    }

    public void handleHighscores()
    {
        if (score > PlayerPrefs.GetInt("JumpyHighScore", 0) && (score > 0))
        {
            PlayerPrefs.SetInt("JumpyHighScore", score);
        }

        highscoreText.text = "Highscore: " +
            PlayerPrefs.GetInt("JumpyHighScore", 0).ToString();

        PlayerPrefs.SetInt("JumpyTotalPlatforms",
                           totalPlatsHit + PlayerPrefs.GetInt("JumpyTotalPlatforms", 0));

        if (_jumpyScript.timer > PlayerPrefs.GetInt("JumpyLongestGame", 0))
        {
            PlayerPrefs.SetInt("JumpyLongestGame", (int)_jumpyScript.timer);
        }
      
        _jumpyScript.timer += PlayerPrefs.GetInt("JumpyTimePlayed", 0);

        PlayerPrefs.SetInt("JumpyTimePlayed", (int)_jumpyScript.timer);
        _jumpyScript.timer = 0f;

    }
}
