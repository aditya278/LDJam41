﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class footTrail : MonoBehaviour {

	public GameObject leftFoot, rightFoot;
	int i=0;
	public bool calledFootsteps=false,horizontal;
	public float hrz;
	public GameObject Player;
	// Use this for initialization
	public float h,v;
	PlayerMovement pm;
	public AudioSource ass;
	public AudioClip normal,dirt,toPlay;
    public PlayMove pmm;

    public float l, p;
	void Start () {

		toPlay = normal;
		//Player = gameObject;
		pm=Player.GetComponent<PlayerMovement>();
	}



	// Update is called once per frame
	void FixedUpdate () {

        if (pmm.dumdum)
        {
            l = CrossPlatformInputManager.GetAxis("Horizontal");
            p = CrossPlatformInputManager.GetAxis("Vertical");
        }
       
        if ( l== 0 &&  p== 0) {
		


		} else{


			h = pm.h;
			v = pm.v;

			if (h != 0 ) {
			
				horizontal = true;

			} else {
			
				horizontal = false;
			}

			if (!calledFootsteps) {

				StartCoroutine (createFootsteps());
			}
		}
	}

	IEnumerator createFootsteps()
	{
		calledFootsteps = true;
		yield return new WaitForSeconds(0.5f);

		float angle = Mathf.Atan2 (v, h) * Mathf.Rad2Deg;
		if (horizontal) {
			if (i % 2 == 0) {
				if (h < 0) {
				
					GameObject go = (GameObject)Instantiate (leftFoot, new Vector2 (Player.transform.position.x, Player.transform.position.y - 0.3f), Quaternion.Euler (0f, 0f, -90f + angle ));
					StartCoroutine (destroyFootsteps (go));
			
				} else {
					
					GameObject go = (GameObject)Instantiate (rightFoot, new Vector2 (Player.transform.position.x, Player.transform.position.y - 0.3f), Quaternion.Euler (0f, 0f, -90f + angle));
					StartCoroutine (destroyFootsteps (go));
				}
			} else {
				if (h < 0) {
					GameObject go = (GameObject)Instantiate (rightFoot, new Vector2 (Player.transform.position.x, Player.transform.position.y + 0.3f), Quaternion.Euler (0f, 0f, -90f + angle));
					StartCoroutine (destroyFootsteps (go));
				} else {
					
					GameObject go = (GameObject)Instantiate (leftFoot, new Vector2 (Player.transform.position.x, Player.transform.position.y + 0.3f), Quaternion.Euler (0f, 0f, -90f + angle));
					StartCoroutine (destroyFootsteps (go));
				}
			}
		} else {
			if (i % 2 == 0) {
				if (v <= 0) {

					GameObject go = (GameObject)Instantiate (leftFoot, new Vector2 (Player.transform.position.x+0.3f, Player.transform.position.y), Quaternion.Euler (0f, 0f, -90f + angle));
					StartCoroutine (destroyFootsteps (go));

				} else {

					GameObject go = (GameObject)Instantiate (rightFoot, new Vector2 (Player.transform.position.x + 0.3f, Player.transform.position.y), Quaternion.Euler (0f, 0f, -90f + angle));
					StartCoroutine (destroyFootsteps (go));
				}
			} else {
				if (v <= 0) {
					GameObject go = (GameObject)Instantiate (rightFoot, new Vector2 (Player.transform.position.x - 0.3f, Player.transform.position.y), Quaternion.Euler (0f, 0f, -90f + angle));
					StartCoroutine (destroyFootsteps (go));
				} else {

					GameObject go = (GameObject)Instantiate (leftFoot, new Vector2 (Player.transform.position.x - 0.3f, Player.transform.position.y), Quaternion.Euler (0f, 0f, -90f + angle));
					StartCoroutine (destroyFootsteps (go));
				}
			}
		}

		ass.clip = toPlay;
		ass.Play ();
		i++;
		calledFootsteps = false;
	}

	IEnumerator destroyFootsteps(GameObject gam)
	{
		yield return new WaitForSeconds(1.5f);
		Destroy (gam);
	}



}
