using UnityEngine;
using System.Collections;


/// <summary>
/// DJ_Weapon. A basic setup for a weapon that
/// is useable.
/// 
/// @author Donnell Lu
/// </summary>
public class DJ_Weapon: IUseable
{
	public DJ_Weapon ()
	{
	}
	
	public void Useable() {
	}

	// Registers the type of item this entity is. 
	public DJ_UseableType type;
	public DJ_Loc location;
	public int damage;

	// Depends on the item that uses Iuseable
	//public bool isTriggered;
	//public float currTime;
	//public float triggerTime;
	//public bool isAlive;
}


