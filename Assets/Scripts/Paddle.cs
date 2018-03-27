﻿using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	private bool hasStarted = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 paddlePos = new Vector3 (0.5f, this.transform.position.y, 0f);
		
		float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
		
		paddlePos.x = Mathf.Clamp(mousePosInBlocks, 0.5f, 15.5f);
		
		this.transform.position = paddlePos;
		
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
