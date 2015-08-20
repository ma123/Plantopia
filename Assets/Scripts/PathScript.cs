using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PathScript : MonoBehaviour {
	private bool[,] array = new bool[,]{{false, true, true, false},{true, false, false, true},{true, false, false, true},{false, true, true, false}};

	public List<bool> GetPath(int id) {
		List<bool> pathList = new List<bool>();
		for(int j = 0; j< array.GetLength(1); j++) {
			pathList.Add(array[id,j]);
		}

		return pathList;
	}
}
