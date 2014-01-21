using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DJ_PlayerManager : DJ_ManagerScript {
	
	// Use this for initialization
	public override void Start ()
	{
		base.Start ();
		player = new GameObject ();
		prevPlayerTilePos = new DJ_Point(int.MaxValue, int.MaxValue);
		FromFile ("");
	}

	public override void Update ()
	{

		if(!inEditorMode)
		{
			// TODO: need a beat manager for time and beatTime;
			time += Time.deltaTime;		
			//get a ref to the player's tile position
			DJ_Point playerTilePos = (player.GetComponent(typeof(DJ_PlayerScript)) as DJ_PlayerScript).tilePos;
			//print (playerTilePos);			
			//now update the nearby tiles if we need to
			//GetTilesNearLocation (playerTilePos);
			ResolvePlayerTileCollision (playerTilePos);
		}

	}

	public override void FromFile (string path)
	{
		base.FromFile (path);
		player = (GameObject.Instantiate(m_playerPrefab) as GameObject);
		playerID = player.GetInstanceID ();
	}

	public override void Dispose ()
	{
		base.Dispose ();
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
				if (DJ_TileManagerScript.tileMap.ContainsKey (playerTilePos))
				{
					GameObject tileUnderPlayer = DJ_TileManagerScript.tileMap [playerTilePos];
					(tileUnderPlayer.GetComponent (typeof(DJ_Damageable)) as DJ_Damageable).hp -= 1.0f;
					print("Tile hp: " + (tileUnderPlayer.GetComponent (typeof(DJ_Damageable)) as DJ_Damageable).hp);
					
					if (!(tileUnderPlayer.GetComponent (typeof(DJ_Damageable)) as DJ_Damageable).isAlive)
					{
						DJ_TileManagerScript.tileMap.Remove (playerTilePos);
						//de activate the tile
						tileUnderPlayer.SetActive (false);
						//put the tile in the pool
						DJ_TileManagerScript.tilePool.Add (tileUnderPlayer);
						tileBroke = true;
						
						//TODO - tile break event
						print ("Tile broke.");
					}
				}

				else {
					print ("Player is falling b/c they moved there.");
				}

			}
			
			if(tileBroke)
			{
				//TODO - player falling event
				print ("Player is falling b/c a tile broke.");
				tileBroke = false;
			}
		}
	}
	
	public static DJ_Point prevPlayerTilePos;
	//List<DJ_Point> nearbyTiles = new List<DJ_Point>();
	
	//TODO - change this time value so it is based off of beat.
	//as of now, the beat is a hard coded value
	float time = 0.0f;
	float beatTime = 2.0f;
	
	//bool to keep track of whether or not the  tile under the player broke
	bool tileBroke = false;
	
	//TODO - will be used later for level editor
	bool inEditorMode = false;
	
	public static int playerID;
	public static GameObject player;
	public GameObject m_playerPrefab;
}
