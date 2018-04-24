using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour {

	public Vector3 direction;
	public float h;
	public float v;
	public float angle;
	public footTrail ft;
    public PlayMove pmm;

    public Transform spawnPoint;

    public GameManager gameManager;

	public Sprite[] sprite; 

	public Image image;

    
	// Use this for initialization
	void Start () {

        
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        gameObject.transform.position = spawnPoint.transform.position;
		direction = Vector3.zero;
	}


	void OnTriggerEnter2D(Collider2D col)
	{

		ft.toPlay = ft.dirt;

        if (pmm.dumdum)
        {
            if (col.gameObject.CompareTag("Meme"))
            {
                //AudioSource audioSource = col.gameObject.GetComponent<AudioSource>();
                //audioSource.Stop();


                AudioSource[] sources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
                for (int index = 0; index < sources.Length; ++index)
                {
                    sources[index].mute = true;
                }



				if (col.name.Contains ("Catch me outside")){
					//Debug.Log ("0 encountered");
					image.sprite = sprite [0];
				} else if (col.name.Contains ("Just Do it")) {
					//Debug.Log ("1 encountered");
					image.sprite = sprite [1];
				} else if (col.name.Contains ("Why are you running")) {
					//Debug.Log ("2 encountered");
					image.sprite = sprite [2];
				} else if (col.name.Contains ("Spaghetti")) {
					//Debug.Log ("3 encountered");
					image.sprite = sprite [3];
				} else if (col.name.Contains ("Yodeling kid")) {
					//Debug.Log ("4 encountered");
					image.sprite = sprite [4];
				} else if (col.name.Contains ("DO you know the")) {
					image.sprite = sprite [5];
					//Debug.Log ("5 encountered");
				}
				image.gameObject.SetActive (true);


                Debug.Log("Game Over!!");
                gameManager.GameOver();
            }

            if(col.gameObject.CompareTag("Target"))
            {
                //AudioSource audioSource = col.gameObject.GetComponent<AudioSource>();
                //audioSource.Stop();

                AudioSource[] sources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
                for (int index = 0; index < sources.Length; ++index)
                {
                    sources[index].mute = true;
                }


                Debug.Log("Winner!");
                gameManager.GameWon();
            }

        }

	}

	void OnTriggerExit2D(Collider2D col)
	{
	
		ft.toPlay = ft.normal;
	}
	// Update is called once per frame
	void FixedUpdate () {

        if (pmm.dumdum)
        {
            h = CrossPlatformInputManager.GetAxis("Horizontal");
            v = CrossPlatformInputManager.GetAxis("Vertical");

        }



        direction = new Vector3 (h, v);

		gameObject.transform.position += direction * 0.05f;

        if(gameObject.transform.position.x <= 8f || gameObject.transform.position.x >= 260f)
        {
            gameObject.transform.position = new Vector3(268f - gameObject.transform.position.x, gameObject.transform.position.y);
        }

        if (gameObject.transform.position.y <= 8f || gameObject.transform.position.y >= 260f)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, 268f - gameObject.transform.position.y);
        }


        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
		//transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}
}
