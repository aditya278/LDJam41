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

	public GameObject player;

    public GameObject finalCanvas;

    public TypeWriterEffect typeWriterEffect;

    // Use this for initialization
    void Start () {

        finalCanvas.SetActive(false);
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

        finalCanvas.SetActive(true);
        typeWriterEffect.StartShowingText();
        asource.mute = false;
        asource.PlayOneShot(evilMorty);
        //StartCoroutine(Waiting(10f));
    }

    public void GameWonBtn()
    {

        SceneManager.LoadScene(0);
    }

    IEnumerator Waiting(float t)
    {

        //targetAudio.mute = false;
        asource.mute = false;

       
        asource.PlayOneShot(scream);
        
		player.SetActive (false);
		//Time.timeScale = 0;

        yield return new WaitForSecondsRealtime(t);

        //Time.timeScale = 1;
        SceneManager.LoadScene(0);

    }

}
