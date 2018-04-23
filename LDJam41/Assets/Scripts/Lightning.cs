using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour {

	float minTime = 0.1f;
    float maxTime = 0.3f;
	float threshold=0.5f;
	public Light light;
	float lasttime=0f;

    public bool flashNow;
	public AudioSource ass;
	public AudioClip[] ac;  
	public float waitForSec = 3f;

    public GameObject[] trees;
    public GameObject[] rocks;
    public GameObject[] lakes;

	// Use this for initialization
	void Start () {

        trees = GameObject.FindGameObjectsWithTag("Tree");
        rocks = GameObject.FindGameObjectsWithTag("Rock");
        lakes = GameObject.FindGameObjectsWithTag("Lake");
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
            waitForSec = Random.Range(5f, 8f);
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

    IEnumerator Flashing(float time)
    {

        light.enabled = true;
        for (int i = 0; i < lakes.Length; i++)
            lakes[i].gameObject.GetComponent<SpriteRenderer>().enabled = true;
        for (int i = 0; i < rocks.Length; i++)
            rocks[i].gameObject.GetComponent<SpriteRenderer>().enabled = true;
        for (int i = 0; i < trees.Length; i++)
            trees[i].gameObject.GetComponent<SpriteRenderer>().enabled = true;


        if (!ass.isPlaying)
        {
            
            ass.PlayOneShot(ac[Random.Range(0, ac.Length)], 1f);
        }
        yield return new WaitForSeconds(time);

        for (int i = 0; i < lakes.Length; i++)
            lakes[i].gameObject.GetComponent<SpriteRenderer>().enabled = false;
        for (int i = 0; i < rocks.Length; i++)
            rocks[i].gameObject.GetComponent<SpriteRenderer>().enabled = false;
        for (int i = 0; i < trees.Length; i++)
            trees[i].gameObject.GetComponent<SpriteRenderer>().enabled = false;


        light.enabled = false;
        
    }
}
