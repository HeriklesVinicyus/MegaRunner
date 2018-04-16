using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour {

	public GameObject barreiraPrefab;
	public float retaSpawn;
	private float currentTime;
	public float y;
	public float posA;
	public float posB;


	// Use this for initialization
	void Start () {
		currentTime = 0;
		retaSpawn = 1;
	}
	
	// Update is called once per frame
	void Update () {




		currentTime += Time.deltaTime;
		if (currentTime >= retaSpawn) {
			currentTime = 0;
			retaSpawn = Random.Range (1250, 2000) / 1000f;
			if (Random.Range (0, 101) <= 50) {
				y = posA;
			} else {
				y = posB;
			}
			GameObject tempPrefab = Instantiate (barreiraPrefab) as GameObject;
			tempPrefab.transform.position = new Vector3 (transform.position.x, y, tempPrefab.transform.position.z);
				
		}
	}
}
