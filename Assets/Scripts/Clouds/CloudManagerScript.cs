using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class CloudManagerScript : MonoBehaviour
{
    public GameObject cloudPrefab;
    public GameObject cloudHandler;
    public Sprite[] clouds;

    public Initialise_UI initialise;

    public bool spawnClouds;

    public int timer;
    
    void Start()
    {
        timer = 0;
        spawnClouds = true;
        SpawnClouds();
    }

    void Update()
    {
        if (initialise.gamePaused)
        {
            return;
        }

        if (!initialise.gamePaused)
        {
            timer += 1;
            if (spawnClouds && timer > 500)
            {
                SpawnClouds();
                timer = 0;
            }
        }
    }

    void SpawnClouds()
    {
        int arrayIdx = Random.Range(0, clouds.Length);
        Sprite cloudSprite = clouds[arrayIdx];

        GameObject newCloud = Instantiate(cloudPrefab);

        newCloud.transform.SetParent(cloudHandler.transform);

        newCloud.GetComponent<SpriteRenderer>().sprite = cloudSprite;
    }
}