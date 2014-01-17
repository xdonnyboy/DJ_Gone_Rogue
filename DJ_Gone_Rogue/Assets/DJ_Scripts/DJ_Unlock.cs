using UnityEngine;
using System.Collections;

public class DJ_Unlock: IUseEvent
{
	public DJ_Unlock ()
	{
		isTriggered = false;
	}

	public void Trigger() {
		
	}
	
	public bool isTriggered;
}

