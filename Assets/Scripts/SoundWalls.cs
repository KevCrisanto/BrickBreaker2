using UnityEngine;
using System.Collections;

public class SoundWalls : MonoBehaviour {
	
	private bool hasStarted = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)){
			hasStarted = true;
		}
	}
	
	void OnCollisionEnter2D (Collision2D collision){
		if (hasStarted){
			audio.Play();
		}
	}
}
