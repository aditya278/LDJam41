using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TypeWriterEffect : MonoBehaviour {

	public float delay = 0.1f;
	public string fullText;
	private string currentText = "";
    public GameObject mainMenuCanvas;
    public GameObject button2;
	// Use this for initialization
	void Start () {

        mainMenuCanvas.SetActive(false);
        StartCoroutine(ShowText());
    }

    public void Click_num_one()
    {
        gameObject.SetActive(false);
        mainMenuCanvas.SetActive(true);
        button2.SetActive(false);
       
    }
	
	IEnumerator ShowText(){
		for(int i = 0; i < fullText.Length; i++){
			currentText = fullText.Substring(0,i);
			this.GetComponent<Text>().text = currentText;
			yield return new WaitForSeconds(delay);
		}
	}
}
