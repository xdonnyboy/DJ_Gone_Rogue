using UnityEngine;
using System.Collections;

/// <summary>
/// DJ_Movement. A component that contains the variables
/// necessary for an entity to move. 
/// 
/// @author Donnell Lu 1/16/2014
/// </summary>

public class DJ_Movement: MonoBehaviour
{

	public void Start() {
	}

	public void Update(){
	}
	
	/// <summary>
	/// Component variables used for all movement
	/// </summary>

	// Triggers boolean that allows for movement. 
	public bool canMove;

	// Position of the tile that the entity will move to 
	public DJ_Point targetTilePos;

	// Max distance that the entity can move
	public float maxMoveDistance;

	// Height of the hop between tiles, adjusted via beat
	public float heightOfHop;

	// Speed of the movement between tiles, adjusted via beat
	public float speedOfMovement;
}