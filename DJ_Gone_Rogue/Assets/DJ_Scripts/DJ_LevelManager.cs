using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DJ_LevelManager : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
		tileMap = new Dictionary<DJ_Point, GameObject>();
		tilePool = new List<GameObject>();

		player = GameObject.Instantiate(playerPrefab) as GameObject;

		makeGrid(10);
	}

	DJ_Point prevPlayerTilePos = new DJ_Point(int.MaxValue, int.MaxValue);
	List<DJ_Point> nearbyTiles = new List<DJ_Point>();

	//TODO - change this time value so it is based off of beat.
	//as of now, the beat is a hard coded value
	float time = 0.0f;
	float beatTime = 2.0f;

	//bool to keep track of whether or not the  tile under the player broke
	bool tileBroke = false;

	//TODO - will be used later for level editor
	bool inEditorMode = false;

	// Update is called once per frame
	void Update ()
	{
		if(!inEditorMode)
		{
			time += Time.deltaTime;

			//get a ref to the player's tile position
			DJ_Point playerTilePos = (player.GetComponent(typeof(DJ_PlayerScript)) as DJ_PlayerScript).tilePos;

			//print (playerTilePos);

			//now update the nearby tiles if we need to
			UpdateNearbyTilesLocations (playerTilePos);

			ResolvePlayerTileCollision (playerTilePos);
		}
	}

	void ResolvePlayerTileCollision (DJ_Point playerTilePos)
	{
		//if the player is touching a tile on the beat,
		//then apply damage to the tile at the player's tile location
		//or if there is no tile, then set the player to falling
		if (player.transform.position.y < .001f)
		{

			//TODO - beat sync with tiles breaking
			if (time > beatTime)
			{
				time = 0.0f;
				if (tileMap.ContainsKey (playerTilePos))
				{
					GameObject tileUnderPlayer = tileMap [playerTilePos];
					//(tileUnderPlayer.GetComponent (typeof(DJ_Damageable)) as DJ_Damageable).hp -= 1.0f;

//					if (!(tileUnderPlayer.GetComponent (typeof(DJ_Damageable)) as DJ_Damageable).isAlive)
//					{
//						tileMap.Remove (playerTilePos);
//						//de activate the tile
//						tileUnderPlayer.SetActive (false);
//						//put the tile in the pool
//						tilePool.Add (tileUnderPlayer);
//
//						tileBroke = true;
//
//						//TODO - tile break event
//						print ("Tile broke");
//					}
				}
			}

			if(tileBroke)
			{
				//TODO - player falling event
				print ("Player is falling");
			}
		}
	}

	void UpdateNearbyTilesLocations (DJ_Point playerTilePos)
	{
		//if the player has moved tiles, we need to update the closest ones
		if (!prevPlayerTilePos.Equals (playerTilePos))
		{
			//reset the  time
			time = 0.0f;

			//reset the tile broke flag
			tileBroke = false;

			prevPlayerTilePos.X = playerTilePos.X;
			prevPlayerTilePos.Y = playerTilePos.Y;
			//now get a ref to  the tiles around the  player
			getNearbyTiles (playerTilePos, ref nearbyTiles, 1.0f);

			//Debugging view to see if tiles update correctly
//			for (int i = 0; i < nearbyTiles.Count; ++i) {
//				DJ_Point p = nearbyTiles [i];
//				if (tileMap.ContainsKey (p)) {
//					GameObject tile = tileMap [p];
//					//(tile.GetComponentInChildren(typeof(MeshRenderer)) as MeshRenderer).material.color = Color.green;
//				}
//			}
			//(tileMap[playerTilePos].GetComponentInChildren(typeof(MeshRenderer)) as MeshRenderer).material.color = Color.red;
		}
	}

	void getNearbyTiles(DJ_Point tilePos, ref List<DJ_Point> nearbyTiles, float depth)
	{
		nearbyTiles.Clear();

		int numTilesPerDim = (int)(1 + 2 * depth);

		if(depth > 1)
		{
			numTilesPerDim = 3 * (int)Mathf.Pow(2.0f, depth - 1.0f) - 1;
		}

		DJ_Point startPoint = new DJ_Point(tilePos.X - Mathf.FloorToInt(numTilesPerDim / 2.0f), tilePos.Y - Mathf.FloorToInt(numTilesPerDim / 2.0f));

		DJ_Point currPoint = startPoint;

		for(int x = 0; x < numTilesPerDim; ++x)
		{
			for(int z = 0; z < numTilesPerDim; ++z)
			{
				DJ_Point newPoint = new DJ_Point(currPoint.X + x, currPoint.Y + z);

				//print ("Next tile pos = " + newPoint);

				nearbyTiles.Add(newPoint);
			}
		}
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
				DJ_Point newPoint = new DJ_Point((int)(_p.x + .5f), (int)(_p.z + .5f));

				//print ("adding tile at " + newPoint);

				tileMap.Add (newPoint, _t);

				//increment the z portion of the position
				_p.z += (tilePrefab.transform.GetChild (0).GetComponent (typeof(MeshRenderer)) as MeshRenderer).bounds.size.z;
			}
			//increment the x portion of the position
			_p.x += (tilePrefab.transform.GetChild (0).GetComponent (typeof(MeshRenderer)) as MeshRenderer).bounds.size.x;
		}
	}

	public static int playerID;

	public static Dictionary<DJ_Point, GameObject> tileMap;
	public static List<GameObject> tilePool;

	public GameObject player;

	public GameObject playerPrefab, tilePrefab;
}
