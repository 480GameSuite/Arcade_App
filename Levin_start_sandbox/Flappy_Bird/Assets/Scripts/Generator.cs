using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour {

    public int num_pipes;
    public float xmin = .2f;
    public float xmax = 2.5f;
    public float down_y_min = 1.7f;
    public float down_y_max = 4.45f;

    private int count = 0;

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


	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        downPosition = new Vector3();
        upPosition = new Vector3();
        groundPosition = new Vector3();
        max_x = 0;
        create_pipes();
        Instantiate(ground, new Vector3(0, .35f, 0), Quaternion.identity);

	}
	
	// Update is called once per frame
	void Update () {
        if(player.position.x >= (max_x - 6f))
        {
            create_pipes();
        }
	}

    private void create_pipes()
    {
        for (int i = 0; i <= num_pipes; i++)
        {
            downPosition.y = Random.Range(down_y_min, down_y_max);
            upPosition.y = downPosition.y - 5.75f;

            downPosition.x += 1.5f;
            upPosition.x += 1.5f;

            if(count == 1)
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



            if(downPosition.x > max_x)
            {
                max_x = downPosition.x;
            }
        }
    }
}
