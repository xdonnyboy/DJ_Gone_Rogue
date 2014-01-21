using UnityEngine;
using System.Collections;

public class DJ_Damage: IUseEvent
{
	public DJ_Damage ()
	{
		isTriggered = false;
	}
	
	public override void Trigger() {
	}
	
	public bool isTriggered;
	public int damageDone;
}

