using UnityEngine;
using System.Collections;

public class DJ_Input : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		inputDir = DJ_Dir.NONE;
		currentMouse = new Vector2(0, 0);
	}

	void Update ()
	{
		checkScreen ();
		checkKeys ();
	}


	// Checks what quarter of the screen has been touched or clicked
	public void checkScreen()
	{
		if(Input.GetMouseButtonDown(0))
		{
			//currentMouse.x = Input.mousePosition.x;
			currentMouse = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
			if (currentMouse.x < Screen.width/4) //left side
			{
				inputDir = DJ_Dir.LEFT;
				print ("left");
			}
			if (currentMouse.x > (Screen.width * (.75))) //right side
			{
				inputDir = DJ_Dir.RIGHT;
				print ("right");
			}
			if(currentMouse.y > (Screen.height * (.75))) //Top
			{
				inputDir = DJ_Dir.UP;
				print ("up");
			}
			if(currentMouse.y < Screen.height/4) //Bottom
			{
				inputDir = DJ_Dir.DOWN;
				print ("down");
			}
		}
	}

	//Checks the WASD keys for which direction to move
	public void checkKeys()
	{
		if(Input.GetKeyDown("a")) //left
		{
			inputDir = DJ_Dir.LEFT;
		}
		if(Input.GetKeyDown("d")) //right
		{
			inputDir = DJ_Dir.RIGHT;
		}
		if(Input.GetKeyDown("w")) //up
		{
			inputDir = DJ_Dir.UP;
		}
		if(Input.GetKeyDown("s")) //down
		{
			inputDir = DJ_Dir.DOWN;
		}
	}




	public Vector2 currentMouse; //Checks the current mouse or touch location
	public static DJ_Dir inputDir; //Check which direction has been swiped
}
