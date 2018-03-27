using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public bool autoPlay = false;	
	
	private bool hasStarted = false;
	private Ball ball;
	
	// Use this for initialization
	void Start () {
		ball = GameObject.FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () {
		if(!autoPlay){
			MoveWithMouse();
		} else {
			AutoPlay();
		}
	}
	
	void AutoPlay(){
		Vector3 paddlePos = new Vector3 (0.5f, this.transform.position.y, 0f);
		Vector3 ballPos = ball.transform.position;
		//float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
		
		//paddlePos.x = Mathf.Clamp(mousePosInBlocks, 0.5f, 15.5f);
		paddlePos.x = Mathf.Clamp(ballPos.x, 0.5f, 15.5f);
		this.transform.position = paddlePos;
	}
	
	void MoveWithMouse(){
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
