using UnityEngine;
using System.Collections;

/// <summary>
/// DJ_UseableType. Enum used to signify item type in
/// the game world.
/// 
/// Pickup = Objects that activate right away; E.G: health pots;
/// Use = Objects that are useable by the character; E.G: weapons, keys
/// Duration = Objects that will power up the player and last a set time.
/// 
/// @author Donnell Lu 1/16/2014
/// </summary>


public enum DJ_UseableType
{
	PICKUP = 0,
	USE, 
	DURATION
}
