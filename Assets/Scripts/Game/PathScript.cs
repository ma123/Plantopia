using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PathScript : MonoBehaviour {
	private bool[,] levelArray;
	private int actualLevel;

	public void Start() {
		actualLevel = PlayerPrefs.GetInt ("currentLevel");
		print (actualLevel);
		switch(actualLevel) {
			case 1: 
			levelArray = new bool[,]{{false,true,false},{true,false,true},{false,true,false}}; // level1
			break;
			case 2:
			levelArray = new bool[,]{{false,true,true,false},{true,false,false,true},{true,false,false,true},{false,true,true,false}}; // level2
			break;
			// todo levels
		}
	}
	
	public List<bool> GetPath(int id) {
		List<bool> pathList = new List<bool>();
		for(int j = 0; j< levelArray.GetLength(1); j++) {
			pathList.Add(levelArray[id,j]);
		}
		
		return pathList;
	}
}
