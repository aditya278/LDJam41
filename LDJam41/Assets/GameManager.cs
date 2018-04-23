using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {



    public AudioClip scream;
    public AudioSource asource;
    public AudioSource targetAudio;

	// Use this for initialization
	void Start () {

        targetAudio = GameObject.FindGameObjectWithTag("Target").GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GameOver()
    {
        targetAudio.Stop();
        asource.PlayOneShot(scream);
        Time.timeScale = 0;
    }
}
