using UnityEngine;
using System.Collections;

/// <summary>
/// DJ_Damager. A component that contains the variables
/// necessary for an entity to deal damage. 
/// 
/// @author Donnell Lu 1/16/2014
/// </summary>

public class DJ_Damager : MonoBehaviour
{
	
	public virtual void Start() {
	}
	
	public virtual void Update(){
	}
	
	/// <summary>
	/// Component variables for dealing damage
	/// to other entities
	/// </summary>
	
	// Is the entity alive
	public bool isAlive;
	
	// hp of the entity
	public int hp;
	
	// max hp of the entity
	public int maxHp;

	// amount of damage being done.
	public int damageDone;

	// a multiplier that effects damage based on the beat multiplier
	public int multiplier;
}

