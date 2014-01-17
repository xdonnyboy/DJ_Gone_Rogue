using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DJ_LevelManager : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
		tileMap = new Dictionary<DJ_Point, int>();

		player = GameObject.Instantiate(playerPrefab) as GameObject;

		makeGrid(10);
	}
	
	// Update is called once per frame
	void Update ()
	{

	}

	/// <summary>
	/// Makes an n x n grid of tiles.
	/// </summary>
	/// <param name="_num">_num.</param>
	void makeGrid (int n)
	{
		Vector3 _p = Vector3.zero;
		
		for (int x = 0; x < n; x++)
		{
			_p.z = 0;
			for (int z = 0; z < n; z++)
			{
				//Create the tile object and tag it as a GameObject
				GameObject _t = (GameObject.Instantiate (tilePrefab)) as GameObject;
				
				_t.transform.parent = transform;
				
				//set the position of the tile
				_t.transform.position = _p;

				//Add the tile to our list of active tiles
				tileMap.Add (new DJ_Point((int)(_p.x + .5f), (int)(_p.y + .5f)), _t.GetInstanceID());

				//increment the z portion of the position
				_p.z += (tilePrefab.transform.GetChild (0).GetComponent (typeof(MeshRenderer)) as MeshRenderer).bounds.size.z;
			}
			//increment the x portion of the position
			_p.x += (tilePrefab.transform.GetChild (0).GetComponent (typeof(MeshRenderer)) as MeshRenderer).bounds.size.x;
		}
	}

	public static int playerID;

	public static Dictionary<DJ_Point, int> tileMap;

	public GameObject player;

	public GameObject playerPrefab, tilePrefab;
}
