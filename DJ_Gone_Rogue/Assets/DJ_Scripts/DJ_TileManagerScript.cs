using UnityEngine;
using System.Collections;
using System.Collections.Generic;


/// <summary>
/// D j_ tile manager script. This script is responsible for managing
/// all the active and inactive tiles currently in the level and is
/// responsible for interfacing with other managers.
/// 
/// @author - Wyatt Sanders 1/9/2014
/// </summary>
public class DJ_TileManagerScript : DJ_ManagerScript
{

	// Use this for initialization
	public override void Start ()
	{
		base.Start ();
		
		//this is only going tobe attached to an empty object but center
		//it at the origin anyway
		gameObject.transform.position = Vector3.zero;

		tilePool = new ArrayList();
		tileMap = new Dictionary<DJ_Point, GameObject>();
		closestTiles = new Dictionary<DJ_Point, GameObject>();
		
		FromFile("");

		// The closestTiles should only be the tiles nearby to the player
		// But right now, it is all the tiles in the level a.k.a the TileMap
		closestTiles = tileMap;
	}
	
	// Update is called once per frame
	public override void Update ()
	{
		if (!inEditorMode) {
			// TODO: need a beat manager for time and beatTime;
			time += Time.deltaTime;		
			//get a ref to the player's tile position
			DJ_Point playerTilePos = (DJ_PlayerManager.player.GetComponent (typeof(DJ_PlayerScript)) as DJ_PlayerScript).tilePos;
			//print (playerTilePos);			
			//now update the nearby tiles if we need to
			getTilesNearLocation (playerTilePos);
		}
	}

	public static void ReceiveBroadcast(ref DJ_Broadcast broadcast)
	{

	}

	public static void SendBroadcast()
	{
	}

	public override void FromFile (string path)
	{
		base.FromFile (path);

		int _num = 10;

		makeGrid (_num);
	}

	public override void Dispose ()
	{
		base.Dispose ();
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
				GameObject _t = (GameObject.Instantiate (m_tilePrefab)) as GameObject;
				
				_t.transform.parent = transform;
				
				//set the position of the tile
				_t.transform.position = _p;
				
				//Add the tile to our list of active tiles
				DJ_Point newPoint = new DJ_Point((int)(_p.x + .5f), (int)(_p.z + .5f));
				
				//print ("adding tile at " + newPoint);
				
				tileMap.Add (newPoint, _t);
				
				//increment the z portion of the position
				_p.z += (m_tilePrefab.transform.GetChild (0).GetComponent (typeof(MeshRenderer)) as MeshRenderer).bounds.size.z;
			}
			//increment the x portion of the position
			_p.x += (m_tilePrefab.transform.GetChild (0).GetComponent (typeof(MeshRenderer)) as MeshRenderer).bounds.size.x;
		}
	}

	void getTilesNearLocation (DJ_Point playerTilePos)
	{
		//if the player has moved tiles, we need to update the closest ones
		if (!DJ_PlayerManager.prevPlayerTilePos.Equals (playerTilePos))
		{
			//reset the  time
			time = 0.0f;
			
			//reset the tile broke flag
			//tileBroke = false;
			
			DJ_PlayerManager.prevPlayerTilePos.X = playerTilePos.X;
			DJ_PlayerManager.prevPlayerTilePos.Y = playerTilePos.Y;

			//now get a ref to  the tiles around the  player
			//getNearbyTiles (playerTilePos, nearbyTiles, 1.0f);
			getNearbyTiles(playerTilePos, 1.0f);

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
	
	//void getNearbyTiles(DJ_Point tilePos, ref List<DJ_Point> nearbyTiles, float depth)
	void getNearbyTiles(DJ_Point tilePos, float depth)
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

	float time = 0.0f;
	float beatTime = 2.0f;
	bool inEditorMode = false;

	private List<DJ_Point> nearbyTiles = new List<DJ_Point>();

	/// <summary>
	/// The tile prefab.
	/// </summary>
	public GameObject m_tilePrefab;

	private Texture[] m_tileTextures;

	/// <summary>
	/// The list of pooled tiles.
	/// </summary>
	public static ArrayList tilePool;

	/// <summary>
	/// The tile map. A dictionary of all the tiles in the level.
	/// </summary>
	public static Dictionary<DJ_Point, GameObject> tileMap;

	/// <summary>
	/// The closest tiles. A dictionary of the closest tiles to the player on the level.
	/// </summary>
	private Dictionary<DJ_Point, GameObject> closestTiles;
}
