using UnityEngine;
using System.Collections;

/// <summary>
/// DJ_Damageable. A component that contains the variables
/// necessary for an entity to take damage.
/// 
/// @author Donnell Lu 1/16/2014
/// </summary>

public class DJ_Damageable: MonoBehaviour
{
	
	public virtual void Start() {
		hp = maxHp;
	}
	
	public virtual void Update(){
		if(hp <= 0.0f)
			isAlive = false;
	}

	/// <summary>
	/// Component variables for dealing damage
	/// to other entities
	/// </summary>

	// Is the entity alive
	public bool isAlive;

	// hp of the entity
	public float hp;

	// max hp of the entity
	public float maxHp;

	// amount of last damage taken 
	public int damageOfLastHit;
}

