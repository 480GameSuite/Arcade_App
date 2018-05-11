using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collision : MonoBehaviour {

    private bool collided = false;
    public bool won = false;


    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        collided = true;
    }

    void Update()
    {
        if(collided == true)
        {
            int game_time = (int)GameObject.Find("Sphere").GetComponent<moveball>().game_time;
            if((game_time < PlayerPrefs.GetInt("brQuickestGame",99999999)) && (won))
            {
                PlayerPrefs.SetInt("brQuickestGame", game_time);
                won = false;
            }
            PlayerPrefs.SetInt("brTimePlayed", game_time + PlayerPrefs.GetInt("brTimePlayed", 0));
            SceneManager.LoadScene("BallRoller");
            int times_played = PlayerPrefs.GetInt("brTimesPlayed", 0);
            times_played++;
            PlayerPrefs.SetInt("brTimesPlayed", times_played);

            collided = false;
        }
        collided = false;
    }

}
