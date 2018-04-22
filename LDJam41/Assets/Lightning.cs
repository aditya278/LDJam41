using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour {

	float minTime=0.5f;
	float threshold=0.5f;
	public Light light;
	float lasttime=0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (Random.Range (1, 30) % 5 == 0) {
		
			flash ();
		}
		
	}

	void flash()
	{
		if ((Time.time - lasttime) > minTime) {

			if (Random.value > threshold) {

				light.enabled = true;
			} else {

				light.enabled = false;
				lasttime = Time.time;
			}
		}

	}
}
