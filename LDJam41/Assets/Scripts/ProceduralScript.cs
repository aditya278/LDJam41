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

    int objectDistance = 10;

    public Sprite[] rockSprites;
    public Sprite[] treeSprites;


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
                Vector3 pos = new Vector3(playerTransform.transform.position.x * objectDistance * 10, 0, playerTransform.transform.position.y * objectDistance * 10);

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
            }
        }
    }
	
	// Update is called once per frame
	void Update () {

        //int w = Random.Range((int)(playerTransform.transform.position.x - 5f), (int)(playerTransform.transform.position.x + 5f));
       // int h = Random.Range((int)(playerTransform.transform.position.y - 5f), (int)(playerTransform.transform.position.y + 5f));

        

    }
}
