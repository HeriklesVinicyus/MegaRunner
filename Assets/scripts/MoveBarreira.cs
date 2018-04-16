using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBarreira : MonoBehaviour {

	public float speed;
	public float x;
	public GameObject player;
	public bool pontuado;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Megaman") as GameObject;
		pontuado = false;
	}
	
	// Update is called once per frame
	void Update () {
		
		x = transform.position.x;
		x += speed * Time.deltaTime;

		transform.position = new Vector3 (x, transform.position.y, transform.position.z);

		if (x <= -7) {
			Destroy (transform.gameObject);
		}
		if (x < player.transform.position.x && !pontuado) {
			pontuado = true;
			PlayerController.pontucao++;
		}
	}
}
