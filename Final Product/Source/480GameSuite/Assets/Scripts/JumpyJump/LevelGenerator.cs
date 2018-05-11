using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public int numPlatforms = 10;
    public float max_y = 2.5f;
    public float min_y = .2f;
    public float width = 3f;
    public float topPlat;
    public Vector3 platformPosition;

    [SerializeField]
    private GameObject _platformPreFab;
    [SerializeField]
    private Transform _Player;

    // Use this for initialization
    public void Start()
    {
        _Player = GameObject.FindGameObjectWithTag("Player").transform;
        Instantiate(_platformPreFab, new Vector3(0,-2.5f,0), Quaternion.identity);
        platformPosition = new Vector3();
        topPlat = 15f;
    }

    private void Update()
    {
        if (_Player.position.y >= (topPlat - 6f))
        {
            CreatePlatforms();
        }
    }

    public void CreatePlatforms()
    {
        for (int i = 0; i <= numPlatforms; i++)
        {
            platformPosition.y += Random.Range(min_y, max_y);
            platformPosition.x = Random.Range(-width, width);
            Instantiate(_platformPreFab, platformPosition, Quaternion.identity);

            if (i == numPlatforms)
            {
                topPlat = platformPosition.y;
            }
        }
    }
}