using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {



    public AudioClip scream;
    public AudioSource asource;
    public AudioSource targetAudio;
    public AudioClip evilMorty;

    public bool gameover;

	// Use this for initialization
	void Start () {

        gameover = false;
        targetAudio = GameObject.FindGameObjectWithTag("Target").GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GameOver()
    {
        gameover = true;
        StartCoroutine(Waiting(5f));

    }

    public void GameWon()
    {
        gameover = false;        

        StartCoroutine(Waiting(10f));

    }

    IEnumerator Waiting(float t)
    {

        //targetAudio.mute = false;
        asource.mute = false;

        if(gameover)
            asource.PlayOneShot(scream);
        else
            asource.PlayOneShot(evilMorty);
        Time.timeScale = 0;

        yield return new WaitForSecondsRealtime(t);

        Time.timeScale = 1;
        SceneManager.LoadScene(0);

    }

}
