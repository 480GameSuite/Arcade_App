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
            GameObject.Find("birdy").GetComponent<MoveBird>().alreadydidthis = false;

        }
    }

    public void defaults()
    {
        GameObject.Find("birdy").GetComponent<MoveBird>().speed = .75f;
    }

    public void invert(bool ison)
    {
        if(ison)
        {
            GameObject.Find("birdy").GetComponent<MoveBird>().invertgravity = 1;
            PlayerPrefs.SetInt("invertgravity", 1);
            Physics.gravity = new Vector3(Mathf.Abs(Physics.gravity.x), Mathf.Abs(Physics.gravity.y), Mathf.Abs(Physics.gravity.z));


        }
        else
        {
            GameObject.Find("birdy").GetComponent<MoveBird>().invertgravity = 0;
            GameObject.Find("birdy").GetComponent<Rigidbody>().transform.position = new Vector3(
   GameObject.Find("birdy").GetComponent<Rigidbody>().transform.position.x,
   2.39f,
   GameObject.Find("birdy").GetComponent<Rigidbody>().transform.position.z);
            PlayerPrefs.SetInt("invertgravity", 0);
            Physics.gravity = new Vector3(-Mathf.Abs(Physics.gravity.x), -Mathf.Abs(Physics.gravity.y), -Mathf.Abs(Physics.gravity.z));

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("invertgravity", 0) == 0)
        {
            Physics.gravity = new Vector3(-Mathf.Abs(Physics.gravity.x), -Mathf.Abs(Physics.gravity.y), -Mathf.Abs(Physics.gravity.z));
        }
        if (PlayerPrefs.GetInt("invertgravity", 0) == 1)
        {
            Physics.gravity = new Vector3(Mathf.Abs(Physics.gravity.x), Mathf.Abs(Physics.gravity.y), Mathf.Abs(Physics.gravity.z));
        }
        if (active == true)
        {
            if(PlayerPrefs.GetInt("invertgravity",0) == 0)
            {
                GameObject.Find("Toggle").GetComponent<Toggle>().isOn = false;

            }
            if (PlayerPrefs.GetInt("invertgravity", 0) == 1)
            {
                GameObject.Find("Toggle").GetComponent<Toggle>().isOn = true;
            }

            GameObject.Find("SpeedSlider").GetComponent<Slider>().value =
                          GameObject.Find("birdy").GetComponent<MoveBird>().speed / .75f;
            exists = false;
            GameObject.Find("SpeedSlider").GetComponent<Slider>().onValueChanged.AddListener(new_speed);
            GameObject.Find("ReturnButton").GetComponent<Button>().onClick.AddListener(go_back);
            GameObject.Find("DefualtsButton").GetComponent<Button>().onClick.AddListener(defaults);
            GameObject.Find("Toggle").GetComponent<Toggle>().onValueChanged.AddListener(invert);

        }
    }
}
