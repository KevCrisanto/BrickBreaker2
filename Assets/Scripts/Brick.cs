using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {
	
	public AudioClip brickHit;
	public static int breakableCount = 0;
	public Sprite[] hitSprites;
	public GameObject smoke;
	
	private int timesHit;
	private LevelManager levelManager;
	private bool isBreakable; 
	
	Color yellow = new Color(0.801f,0.514f,0.083f, 1.000f);
	Color pink = new Color(204f,0f,204f);
	Color green = new Color(0F,255F,0F);
	
	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Breakable");
		if (isBreakable){
			breakableCount++;
		}
		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnCollisionEnter2D (Collision2D col){
		AudioSource.PlayClipAtPoint (brickHit, transform.position, 0.15f);
		if(isBreakable){
			HandleHits();
		}
	}
	
	void HandleHits(){
		
		timesHit++;
		int maxHits = hitSprites.Length + 1;
		if (timesHit >= maxHits){
			breakableCount--;
			levelManager.BrickDestroyed();
			PuffSmooke(maxHits);
			Destroy (gameObject);
		} else{
			LoadSprites();
		}
	}
	
	void PuffSmooke(int maxHits){
		GameObject smokePuff = Instantiate(smoke, gameObject.transform.position, Quaternion.Euler(0f, 180f, 0f)) as GameObject;
		if(maxHits == 3)
			//smokePuff.particleSystem.startColor = gameObject.GetComponent<SpriteRenderer>().color;
			//print (gameObject.GetComponent<SpriteRenderer>().color);
			smokePuff.particleSystem.startColor = pink;
		else if (maxHits == 2)
			smokePuff.particleSystem.startColor = green;
		else if (maxHits == 1)
			smokePuff.particleSystem.startColor = yellow;
		Destroy(smokePuff, smokePuff.particleSystem.duration + 2f); 
	}
	
	void LoadSprites(){
		int spriteIndex = timesHit - 1;
		
		if(hitSprites[spriteIndex] != null){
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		} else{
			Debug.LogError("Brick sprite missing");
		}
	}
}
