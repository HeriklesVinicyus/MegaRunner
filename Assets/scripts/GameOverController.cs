using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverController : MonoBehaviour {

	public UnityEngine.UI.Text pontuacao;
	public UnityEngine.UI.Text recorde;

	// Use this for initialization
	void Start () {
		pontuacao.text = (PlayerPrefs.GetInt ("pontuacao"))+"";
		recorde.text = (PlayerPrefs.GetInt ("recorde"))+"";
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			UnityEngine.SceneManagement.SceneManager.LoadScene("Main", UnityEngine.SceneManagement.LoadSceneMode.Single) ;
		}else if (Input.GetMouseButtonDown (1)) {
			UnityEngine.SceneManagement.SceneManager.LoadScene("Menu", UnityEngine.SceneManagement.LoadSceneMode.Single) ;
		}
		
	}
}
