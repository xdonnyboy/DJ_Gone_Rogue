using UnityEngine;
using System.Collections;
/// <summary>
/// Iuseable. A interface for all items that
/// determine whether or not an item is useable
/// and what the event's for each specific item.
/// 
/// Items are keys, health potions and weapons
/// 
/// @author Donnell Lu 1/16/2014
/// </summary>

public class IUseable : MonoBehaviour
{
	public void Start() {
	}

	public void Update() {
	}

	public virtual void Useable(){
	}
}
