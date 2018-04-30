using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private char cur_direction = 'u';
    private char last_direction;
    private float tail_len = 2.5f;
    private float _restartTimer;
    private bool _gameOver;
    private bool _start;
    private Vector3 _direction;
    private Vector3 _touchOrigin = new Vector3(-40, 0 ,0);
    private Food _food;
    private UIManager _ui;
    [SerializeField]
    private GameObject _tail;
    //private Vector3 _body;
    private Vector3 head_pos;
    private List<GameObject> tail_list = new List<GameObject>();


    // Use this for initialization
    void Start()
    {
        _start = true;
        _gameOver = false;
        _direction = new Vector3(0, tail_len, 0);
        _food = GameObject.Find("Food").GetComponent<Food>();
        _ui = GameObject.Find("EndGameCanvas").GetComponent<UIManager>();
        _ui.hideGameOver();
        transform.position = new Vector3(0, 0);
        InvokeRepeating("Move", 0.09f, 0.09f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            SceneManager.LoadScene("MainScreen");
        }

        if (_gameOver)
        {
            //// .. increment a timer to count up to restarting.
            //_restartTimer += Time.deltaTime;


            if (Input.GetMouseButtonDown(0))
            {
                _ui.hideGameOver();
                //reload the currently loaded level.
                SceneManager.LoadScene("Snake");
                _gameOver = false;
            }
        }

        //#if UNITY_ANDROID
        if (_start)
        {

            if (Input.GetMouseButtonDown(0))
            {
                _ui.hideStart();
                _start = false;
            }
        }
        if(Input.touchCount > 0 )
        {
            Touch myTouch = Input.touches[0];

            if(myTouch.phase == TouchPhase.Began)
            {
                _touchOrigin = myTouch.position;
            }

            else if(myTouch.phase == TouchPhase.Ended && _touchOrigin.x > -40)
            {
                Vector3 touchEnd = myTouch.position;

                float x = touchEnd.x - _touchOrigin.x;
                float y = touchEnd.y - _touchOrigin.y;
                _touchOrigin.x = -40;

                if (Mathf.Abs(x) > Mathf.Abs(y))
                {
                    cur_direction = x > 0 ? 'r' : 'l';
                }

                else
                {
                    cur_direction = y > 0 ? 'u' : 'd';
                }
            }
        }

        //Keyboard controls used for easy debuging on computer
        if (Input.GetKey(KeyCode.UpArrow))
        {
            cur_direction = 'u';
        }

        else if (Input.GetKey(KeyCode.DownArrow))
        {
            cur_direction = 'd';
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            cur_direction = 'r';
        }

        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            cur_direction = 'l';
        }


        //Change the direction
        if (cur_direction == 'u' && last_direction != 'd')
        {
            _direction = new Vector3(0, tail_len, 0);
            last_direction = 'u';
        }

        else if (cur_direction == 'd' && last_direction != 'u')
        {
            _direction = new Vector3(0, -tail_len, 0);
            last_direction = 'd';
        }

        else if (cur_direction == 'r' && last_direction != 'l')
        {
            _direction = new Vector3(tail_len, 0, 0);
            last_direction = 'r';
        }

        else if (cur_direction == 'l' && last_direction != 'r')
        {
            _direction = new Vector3(-tail_len, 0, 0);
            last_direction = 'l';
        }

    }

    private void Move()
    {
        if (!_gameOver && !_start)
        {
            head_pos = transform.position;
            transform.Translate(_direction);

            if (tail_list.Count > 0)
            {
                tail_list.Last().transform.position = head_pos;
                tail_list.Insert(0, tail_list.Last());
                tail_list.RemoveAt(tail_list.Count - 1);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Food")
        {
            _food.SpawnFood();
            _ui.updateScore();
            Grow();
        }

        if (other.tag == "Tail" || other.tag == "Border")
        {
            _ui.showGameOver();
            _gameOver = true;
        }
    }

    public void Grow()
    {
        GameObject new_tail = (GameObject)Instantiate(_tail, head_pos, Quaternion.identity);
        tail_list.Insert(0, new_tail);
    }
}
