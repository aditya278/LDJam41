using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralScript : MonoBehaviour {

    public Transform playerTransform;
    public int mapWidth;
    public int mapHeight;
    int[,] mapgrid;

    public GameObject rockGO;
    public GameObject treeGO;
    public GameObject lakeGo;

    int objectDistance = 10;

    public Sprite[] rockSprites;
    public Sprite[] treeSprites;

    public Transform[] spawnPoints;
    public GameObject[] memes;

    int randNumber;
    public GameObject mainAudioSource;


    public PlayMove pmm;
    public bool makeMemes = false;

    // Use this for initialization
    void Start()
    {
      
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        mapWidth = 30;
        mapHeight = 30;
        mapgrid = new int[mapWidth, mapHeight];

        for (int w = 0; w < mapWidth; w++)
        {
            for (int h = 0; h < mapHeight; h++)
            {
                float wCoord = (float)w / 10f;
                float hCoord = (float)h / 10f;
                mapgrid[w, h] = (int)(Mathf.PerlinNoise(wCoord, hCoord) * 5);
                Debug.Log("\t" + mapgrid[w, h]);
            }
            Debug.Log("\n");
        }

        for (int w = 0; w < mapWidth; w++)
        {
            for (int h = 0; h < mapHeight; h++)
            {
                objectDistance = (int)Random.Range(6f, 12f);
                Vector3 pos = new Vector3(w * objectDistance, h * objectDistance, 0);

                int result = mapgrid[w, h];
                if (result < 1)
                {
                    GameObject rock = Instantiate(rockGO, pos, Quaternion.identity);
                    rock.GetComponent<SpriteRenderer>().sprite = rockSprites[Random.Range(0, rockSprites.Length)];
                }
                else if (result < 2)
                {
                    GameObject tree = Instantiate(treeGO, pos, Quaternion.identity);
                    tree.GetComponent<SpriteRenderer>().sprite = treeSprites[Random.Range(0, treeSprites.Length)];
                }
                else
                {
                    int randInt = (int)Random.Range(1f, 10f);
                    if (randInt == 5)
                    {
                        GameObject lake = Instantiate(lakeGo, pos, Quaternion.identity);
                    }
                }
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
        
        if(pmm.dumdum && !makeMemes)
        {
            makeMemes = true;
            randNumber = Random.Range(0, spawnPoints.Length);
            mainAudioSource.transform.position = spawnPoints[randNumber].transform.position;

            for (int i = 0; i < memes.Length; i++)
            {
                int rand = Random.Range(1, 2);
                randNumber += rand;
                if (randNumber > spawnPoints.Length - 1)
                {
                    randNumber -= spawnPoints.Length;
                }
                Instantiate(memes[i], spawnPoints[randNumber].transform.position, Quaternion.identity);

            }
        }

    }
}
