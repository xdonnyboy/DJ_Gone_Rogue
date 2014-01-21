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

	public void Start() 
	{
		//DJ_Input.inputDir = DJ_Dir.NONE;
		canMove = true;
		//currentTilePos.X = 1;
		//currentTilePos.Y = 1;
		//targetTilePos.X = 1;
		//targetTilePos.Y = 1;

	}

	private DJ_Dir prevDir = DJ_Dir.NONE;

	public void Update()
	{
		currentPosition = transform.position;
		mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

		if (canMove && DJ_Input.inputDir != prevDir)
		{

			//DJ_Input.checkScreen(mousePosition, DJ_Input.inputDir);
			DJ_Util.GetNeighboringTilePos(currentTilePos, targetTilePos, DJ_Input.inputDir);
			canMove = DJ_Util.SLerpTrajectory(ref currentPosition, targetTilePos, 1, 50);
			//DJ_Input.inputDir = DJ_Dir.LEFT;

			print ("Input:" + DJ_Input.inputDir);

			prevDir = DJ_Input.inputDir;

			/*if (DJ_Input.inputDir == DJ_Dir.LEFT)
			{
				moveLeft();
			}
			if (DJ_Input.inputDir == DJ_Dir.RIGHT)
			{
				moveRight();
			}
			if (DJ_Input.inputDir == DJ_Dir.UP)
			{
				moveUp();
			}	
			if (DJ_Input.inputDir == DJ_Dir.DOWN)
			{
				moveDown();
			}
*/
		}
		else
		{
			DJ_Util.SLerpTrajectory(ref currentPosition, targetTilePos, 1, 50);
		}

		transform.position = currentPosition;
	}


	public void moveUp()
	{
		canMove = false;
		DJ_Input.inputDir = DJ_Dir.NONE;
		nextPosition.x = currentPosition.x;
		nextPosition.y = currentPosition.y;
		nextPosition.z = currentPosition.z - 1; 
	}
	public void moveDown()
	{
		canMove = false;
		DJ_Input.inputDir = DJ_Dir.NONE;
		nextPosition.x = currentPosition.x;
		nextPosition.y = currentPosition.y;
		nextPosition.z = currentPosition.z + 1;
	}
	public void moveRight()
	{
		canMove = false;
		DJ_Input.inputDir = DJ_Dir.NONE;
		nextPosition.x = currentPosition.x - 1;
		nextPosition.y = currentPosition.y;
		nextPosition.z = currentPosition.z;
		//rotate if necessary
		/*if (left == false)
		{
			targetRotation = transform.eulerAngles + 180f * Vector3.up;
			transform.eulerAngles = Vector3.Slerp (transform.eulerAngles, targetRotation, 1);
			left = true;
		}*/
	}
	public void moveLeft()
	{
		canMove = false;
		DJ_Input.inputDir = DJ_Dir.NONE;
		nextPosition.x = currentPosition.x + 1;
		nextPosition.y = currentPosition.y;
		nextPosition.z = currentPosition.z;
		//rotate if necessary
		/*if (left == true)
		{
			targetRotation = transform.eulerAngles + 180f * Vector3.up;
			transform.eulerAngles = Vector3.Slerp (transform.eulerAngles, targetRotation, 1);
			left = false;
		}*/
	}
	
	//perform the movement logic
	public void actualMove()
	{
		transform.position = Vector3.Slerp(currentPosition, nextPosition, Time.deltaTime * 17.0f);
		currentPosition = transform.position;
	}
	
	//check if the player should move again
	public bool moveCheck()
	{
		if(currentPosition == nextPosition)
		{
			canMove = true;
			return canMove;
		}
		else
		{
			canMove = false;
			return canMove;
		}
	}


	/// <summary>
	/// Component variables used for all movement
	/// </summary>

	// Triggers boolean that allows for movement. 
	public bool canMove;
	
	// Position of the tile that the entity is currently on
	public DJ_Point currentTilePos = new DJ_Point(0, 0);

	// Position of the tile that the entity will move to 
	public DJ_Point targetTilePos = new DJ_Point(0,0);

	// Max distance that the entity can move
	public float maxMoveDistance;

	// Height of the hop between tiles, adjusted via beat
	public float heightOfHop;

	// Speed of the movement between tiles, adjusted via beat
	public float speedOfMovement;

	public DJ_Input currentInput;

	public Vector2 mousePosition;

	public Vector3 currentPosition;
	public Vector3 nextPosition;

}