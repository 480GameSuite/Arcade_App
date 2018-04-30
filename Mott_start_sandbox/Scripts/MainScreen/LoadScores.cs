using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LoadScores : MonoBehaviour {

    public GameObject bjHighScore;
    public GameObject bjLongestGame;
    public GameObject bjNumFlaps;
    public GameObject bjTimePlayed;

    public GameObject brTimesPlayed;
    public GameObject brQuickestGame;
    public GameObject brTimePlayed;

    public GameObject jjHighScore;
    public GameObject jjTimePlayed;
    public GameObject jjLongestGame;
    public GameObject jNumJumps;

    public GameObject sHighScore;
    public GameObject sNumFruit;
    public GameObject sTimePlayed;
    public GameObject sLongestGame;

    public bool viewingScores;

    string sec_to_string(int seconds)
    {
        if(seconds < 0)
        {
            return "0 seconds";
        }
        else if (seconds < 60)
        {
            return seconds + "sec";
        }
        else if (seconds == 99999999)
        {
            return "N/A";
        }
        else
        {
            int minutes = (int)Mathf.Floor(seconds/60);
            int secs = seconds % 60;
            return minutes + "min " + secs + "sec";
        }
    }

	// Use this for initialization
	void Update () {
        if (GameObject.FindWithTag("stats").activeSelf && viewingScores)
        {
            bjHighScore.GetComponent<Text>().text = "High Score: " + PlayerPrefs.GetInt("BirdleHighScore", 0).ToString();
            bjLongestGame.GetComponent<Text>().text = "Longest Game: " + sec_to_string(PlayerPrefs.GetInt("birdle_time_elapsed", 0));
            bjNumFlaps.GetComponent<Text>().text = "Number Of Flaps: " + PlayerPrefs.GetInt("bjNumFlaps", 0);
            bjTimePlayed.GetComponent<Text>().text = "Time Played: " + sec_to_string(PlayerPrefs.GetInt("bjTimePlayed", 0));

            brTimesPlayed.GetComponent<Text>().text = "Times Played: " + PlayerPrefs.GetInt("brTimesPlayed", 0);
            brQuickestGame.GetComponent<Text>().text = "Quickest Game: " + sec_to_string(PlayerPrefs.GetInt("brQuickestGame", 99999999));
            brTimePlayed.GetComponent<Text>().text = "Total Time Played: " + sec_to_string(PlayerPrefs.GetInt("brTimePlayed", 0));

            jjHighScore.GetComponent<Text>().text = "High Score: " +  PlayerPrefs.GetInt("JumpyHighScore", 0);
            jjTimePlayed.GetComponent<Text>().text = "Total Time Played: " + sec_to_string(PlayerPrefs.GetInt("JumpyTimePlayed", 0));
            jjLongestGame.GetComponent<Text>().text = "Longest Game: " + sec_to_string(PlayerPrefs.GetInt("JumpyLongestGame", 0));
            jNumJumps.GetComponent<Text>().text = "Number Of Jumps: " + PlayerPrefs.GetInt("JumpyTotalPlatforms", 0);

            sHighScore.GetComponent<Text>().text = "High Score: " + PlayerPrefs.GetInt("SnakeHighScore", 0);
            sNumFruit.GetComponent<Text>().text = "Number Of Fruit Eaten: " + PlayerPrefs.GetInt("SnakeTotalApples", 0);
            sTimePlayed.GetComponent<Text>().text = "Total Time Played: " + sec_to_string(PlayerPrefs.GetInt("SnakeTimePlayed", 0));
            sLongestGame.GetComponent<Text>().text = "Longest Game: " + sec_to_string(PlayerPrefs.GetInt("SnakeLongestGame", 0));
            viewingScores = false;
        }	
	}
}
