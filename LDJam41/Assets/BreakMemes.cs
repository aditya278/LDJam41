using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakMemes : MonoBehaviour {

	AudioSource ass;
	bool onn;
	// Use this for initialization
	void Start () {
		ass = gameObject.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (!ass.isPlaying && !onn) {
		
			StartCoroutine (waitForit ());

		}
	}

	IEnumerator waitForit(){
		onn = true;
		yield return new WaitForSeconds (3f);
		ass.Play ();
		onn = false;
	}
}
