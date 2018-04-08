using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Options : MonoBehaviour
{
    public bool exists = false;
    public bool active;

    [SerializeField]
    private GameObject start_menu;


    public void new_speed(float newspeed)
    {
        float multspeed = Mathf.Clamp(newspeed, .25f, 2); 
        GameObject.Find("birdy").GetComponent<MoveBird>().speed = .75f * multspeed;
        PlayerPrefs.SetFloat("sliderval", multspeed);
    }

    public void go_back()
    {
        active = false;
        Destroy(GameObject.Find("Options(Clone)"));
        if (exists == false)
        {
            Instantiate(start_menu, new Vector3(), Quaternion.identity);
            exists = true;
            GameObject.Find("birdy").GetComponent<MoveBird>().paused = false;
            GameObject.Find("birdy").GetComponent<MoveBird>().started = false;

        }
    }

    public void defaults()
    {
        GameObject.Find("birdy").GetComponent<MoveBird>().speed = .75f;
    }


    // Update is called once per frame
    void Update()
    {
        if (active == true)
        {
            GameObject.Find("SpeedSlider").GetComponent<Slider>().value =
                          GameObject.Find("birdy").GetComponent<MoveBird>().speed / .75f;
            exists = false;
            GameObject.Find("SpeedSlider").GetComponent<Slider>().onValueChanged.AddListener(new_speed);
            GameObject.Find("ReturnButton").GetComponent<Button>().onClick.AddListener(go_back);
            GameObject.Find("DefualtsButton").GetComponent<Button>().onClick.AddListener(defaults);

        }
    }
}
