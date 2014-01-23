using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// DJ_LevelManager.cs: This script is responsible for calling the parser
/// to parse a certain level. IMPORTANT: This has to be called before the
/// TileManager is instantiated or else you will have an empty game world.
/// 
/// @author - Fernando Carrillo 1/23/2014
/// </summary>
public class DJ_LevelManager : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
		//we will have to change this later on to not be hardcoded

		//loads level one
		Debug.Log ("Calling Load Level");
		LoadLevel(1);
	}
	
	// Update is called once per frame
	void Update ()
	{
	}

	public static void LoadLevel(int levelNumber){
		DJ_LevelParser.LoadLevel(levelNumber);
	}
	
}
