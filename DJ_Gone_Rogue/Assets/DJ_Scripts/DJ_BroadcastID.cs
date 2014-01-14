/// <summary>
/// D j_ broadcast IDs. Used to identify who is sending/receiving the broadcast.
/// </summary>

public enum DJ_BroadcastID : int
{
	NONE = 0,
	ALL,
	TILE,
	PLAYER,
	ENEMY,
	ITEM,
	LEVEL,
	//anything else we may need
}
