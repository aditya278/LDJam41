using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public Vector3 direction;
	public float h;
	public float v;
	public float angle;
	public footTrail ft;
    public PlayMove pmm;

    public GameManager gameManager;

	// Use this for initialization
	void Start () {

        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

		direction = Vector3.zero;
	}


	void OnTriggerEnter2D(Collider2D col)
	{

		ft.toPlay = ft.dirt;

        if (pmm.dumdum)
        {
            if (col.gameObject.CompareTag("Meme"))
            {
                AudioSource audioSource = col.gameObject.GetComponent<AudioSource>();
                audioSource.Stop();
                Debug.Log("Game Over!!");
                gameManager.GameOver();
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
            h = Input.GetAxis("Horizontal");
            v = Input.GetAxis("Vertical");

        }



        direction = new Vector3 (h, v);

		gameObject.transform.position += direction * 0.05f;

        if(gameObject.transform.position.x <= 20f || gameObject.transform.position.x >= 280f)
        {
            gameObject.transform.position = new Vector3(300f - gameObject.transform.position.x, gameObject.transform.position.y);
        }

        if (gameObject.transform.position.y <= 20f || gameObject.transform.position.y >= 280f)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, 300f - gameObject.transform.position.y);
        }


        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}
}
