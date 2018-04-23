using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour {

	float minTime = 0.5f;
    float maxTime = 0.8f;
	float threshold=0.5f;
	public Light light;
	float lasttime=0f;

    public bool flashNow;
	public AudioSource ass;
	public AudioClip[] ac;  
	public float waitForSec = 0.5f;

	// Use this for initialization
	void Start () {

       // StartCoroutine(WaitForFlashing(5f));
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        /*if (Random.Range (1, 30) % 5 == 0) {
		
			flash ();
		}*/

        waitForSec -= Time.deltaTime;
        if(waitForSec < 0f)
        {
            StartCoroutine(Flashing(Random.Range(minTime, maxTime)));
            waitForSec = Random.Range(2f, 8f);
        }

    }

	void flash()
	{
		if ((Time.time - lasttime) > minTime) {

			if (Random.value > threshold) {
				if (!ass.isPlaying) {
				
					//ass.clip = ac [Random.Range (0, 1)];
					ass.PlayOneShot (ac[Random.Range(0,ac.Length)], 1f);
					light.enabled = true;
				}
					

			} else {

				light.enabled = false;
				lasttime = Time.time;
			}
		}

	}

    IEnumerator Flashing(float time)
    {

        light.enabled = true;

        yield return new WaitForSeconds(time);

        light.enabled = false;
        
    }
}
