using UnityEngine;
using System.Collections;

/// <summary>
/// DJ_Heal. A UseEvent that heals some
/// entity for a certain amount.
/// 
/// @author Donnell Lu 1/16/2014
/// </summary>
public class DJ_Heal: IUseEvent
{
	public DJ_Heal ()
	{
		isTriggered = false;
		healAmount = 0;
	}
	
	public override void Trigger() {
		
	}

	/// <summary>
	/// The variables used to heal an entity
	/// </summary>

	// Heal use was triggered
	public bool isTriggered;
	// healAmount
	public int healAmount;

}

