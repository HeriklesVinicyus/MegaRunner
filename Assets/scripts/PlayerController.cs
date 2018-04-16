using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	public Rigidbody2D playerRigidbody;
	public Animator playerAnimator;
	public int forceJump;

	public bool isGrounded;
	public bool isSliding;

	public Transform GroundCheck;
	public LayerMask whatIsGround;

	public float slideTemp;
	private float time;

	public GameObject colisor;
	private float subtracaoPositionY = 0.2f;
	private float subtracaoPositionX = 0.24f;


	public AudioSource audio;
	public AudioClip[] sounds;

	public UnityEngine.UI.Text texto;
	public static int pontucao;


	//private Vector3 positionColisorOriginal;


	// Use this for initialization
	void Start () {
		//playerRigidbody = GetComponents<Rigidbody2D> ();
		audio = GetComponent<AudioSource>();
		pontucao = 0;
		PlayerPrefs.SetInt ("pontuacao", pontucao);
	}
	
	// Update is called once per frame
	void Update () {

		texto.text = pontucao+"";

		isGrounded = Physics2D.OverlapCircle (GroundCheck.position, 0.2f, whatIsGround);
		//positionColisorOriginal = colisor.transform.position;

		if(Input.GetButtonDown("Jump") && isGrounded){

			playerRigidbody.AddForce (new Vector2(0,forceJump));

			audio.PlayOneShot(sounds[0]);
			audio.volume = 1f;
			if (isSliding) {
				colisor.transform.position = new Vector3 (colisor.transform.position.x + subtracaoPositionX, colisor.transform.position.y + subtracaoPositionY, colisor.transform.position.z);
			}
			isSliding = false;

		} else if(Input.GetButtonDown("Slide") && isGrounded && !isSliding){
			isSliding = true;
			time = 0;

			audio.PlayOneShot(sounds[1]);
			audio.volume = 0.5f;

			colisor.transform.position = new Vector3 (colisor.transform.position.x -subtracaoPositionX, colisor.transform.position.y - subtracaoPositionY, colisor.transform.position.z);
			
		}

		if (isSliding == true) {
			time += Time.deltaTime;
			if (time >= slideTemp) {
				isSliding = false;
				colisor.transform.position = new Vector3 (colisor.transform.position.x +subtracaoPositionX, colisor.transform.position.y + subtracaoPositionY, colisor.transform.position.z);
			}
		}

		playerAnimator.SetBool ("isJumping", !isGrounded);
		playerAnimator.SetBool ("isSliding", isSliding);
	}

	void OnTriggerEnter2D(){
		
		PlayerPrefs.SetInt ("pontuacao", pontucao);
		if (pontucao > PlayerPrefs.GetInt ("recorde")) {
			PlayerPrefs.SetInt ("recorde", pontucao);
		}

		// pode ser assim: UnityEngine.SceneManagement.SceneManager.LoadScene ("GameOver");
		SceneManager.LoadScene("GameOver", LoadSceneMode.Single) ;
		//Application.LoadLevel ("GameOver");
	}
}
