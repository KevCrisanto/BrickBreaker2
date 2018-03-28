using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	static int currentLevel = 1;
	
	public void LoadLevel(string name){
		if (name == "Start"){
			currentLevel = 1;
		}
		Brick.breakableCount = 0;
		Application.LoadLevel(name);
	}
	
	public void QuitRequest(){
		Application.Quit();
	}
	
	public void LoadNextLevel(){
		currentLevel = Application.loadedLevel + 1;
		print ("Current level = " + currentLevel);
		Brick.breakableCount = 0;
		Application.LoadLevel(Application.loadedLevel + 1);
	}
	
	public void BrickDestroyed(){
		if (Brick.breakableCount <= 0){
			LoadNextLevel();
		}
	}

	public void LoadLastLevel(){
		print ("Loading level " + currentLevel);
		Application.LoadLevel(currentLevel);
	}
}
