using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{   
    public Text scoreText;
    public Text gameOverScoreText;
    public Text highscoreText;
    public int score;
    public GameObject gameOver;
    public GameObject gameOverScore;
    public GameObject inGameScore;
    public GameObject highscoreObject;
    public GameObject title;
    public GameObject tapStart;
    public GameObject startOver;
    public GameObject startMenu;

    private int _totalApples;
    private float _timer;
    private bool _gameOver = true;

	private void Update()
	{
        if (!_gameOver)
        {
            _timer += Time.deltaTime;
        }
	}

	public void hideStart()
    {
        title.SetActive(false);
        tapStart.SetActive(false);
        _gameOver = false;
    }

	public void updateScore()
    {
        score += 1;
        scoreText.text = "Score: " + score;
    }

    public void resetScore()
    {
        score = 0;
        scoreText.text = "Score: 0";
    }

    public void hideGameOver()
    {
        gameOver.SetActive(false);
        highscoreObject.SetActive(false);
        gameOverScore.SetActive(false);
        startOver.SetActive(false);
        inGameScore.SetActive(true);
    }

    public void showGameOver()
    {
        _gameOver = true;
        handleHighScores();
        highscoreText.text = "Highscore: " +
            PlayerPrefs.GetInt("SnakeHighScore", 0).ToString();

        gameOverScoreText.text += score;

        gameOver.SetActive(true);
        gameOverScore.SetActive(true);
        highscoreObject.SetActive(true);
        startOver.SetActive(true);
        inGameScore.SetActive(false);
    }

    private void handleHighScores()
    {
        if (score > PlayerPrefs.GetInt("SnakeHighScore", 0) && (score > 0))
        {
            PlayerPrefs.SetInt("SnakeHighScore", score);
        }

        _totalApples = PlayerPrefs.GetInt("SnakeTotalApples", 0);
        _totalApples += score;
        PlayerPrefs.SetInt("SnakeTotalApples", _totalApples);

        if (_timer > PlayerPrefs.GetInt("SnakeLongestGame", 0))
        {
            PlayerPrefs.SetInt("SnakeLongestGame", (int)_timer);
        }

        _timer += PlayerPrefs.GetInt("SnakeTimePlayed", 0);

        PlayerPrefs.SetInt("SnakeTimePlayed", (int)_timer);
        _timer = 0f;
    }
}
