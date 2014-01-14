using UnityEngine;
using System.Collections;

public class DJ_Broadcast
{
	public DJ_Broadcast()
		: this(DJ_BroadcastID.NONE, DJ_BroadcastID.NONE)
	{

	}

	public DJ_Broadcast(DJ_BroadcastID sender, DJ_BroadcastID receiver)
		: this(sender, receiver, null)
	{

	}

	public DJ_Broadcast(DJ_BroadcastID sender, DJ_BroadcastID receiver, DJ_GameData data)
	{
		this.sender = sender;
		this.receiver = receiver;
		this.data = data;
	}

	/// <summary>
	/// The sender of the broadcast.
	/// </summary>
	public DJ_BroadcastID sender;

	/// <summary>
	/// The receiver of the broadcast.
	/// </summary>
	public DJ_BroadcastID receiver;

	/// <summary>
	/// The data.
	/// </summary>
	public DJ_GameData data;

	/// <summary>
	/// The time at which the broadcast was sent.
	/// </summary>
	public float time;
}
