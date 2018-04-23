using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        
       
        StartCoroutine(Waiting(5f));
    }

    IEnumerator Waiting(float t)
    {
        targetAudio.Stop();
        asource.PlayOneShot(scream);
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(t);

        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

}
