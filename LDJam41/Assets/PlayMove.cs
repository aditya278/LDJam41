using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMove : MonoBehaviour {

	public GameObject gob1,gob2,gob3;
	public bool dumdum=false;
	public footTrail ft;
	 public PlayerMovement pm;

	float l,p;
	// Use this for initialization
	void Start () {

		StartCoroutine (setFootstep ());
	}

	IEnumerator setFootstep()
	{
		l = Random.Range (0f, 1.0f);
		p = Random.Range (0f, 1.0f);
		ft.l = l;
		ft.p = p;
		pm.h = l;
		pm.v = p;
		yield return new WaitUntil(()=>dumdum);

	}

	// Update is called once per frame
	void Update () {


	}

	public void clicked()
	{
		dumdum = true;
		gob1.SetActive (false);
		gob2.SetActive (false);
		gob3.SetActive (false);

	}
}
