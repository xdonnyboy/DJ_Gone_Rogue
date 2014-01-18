using UnityEngine;
using System.Collections;

public static class DJ_Util
{
	/// <summary>
	/// Gets the tile position based on the actual position.
	/// </summary>
	/// <param name="position">Position.</param>
	/// <param name="tilePos">Tile position.</param>
	public static void GetTilePos(Vector3 position, ref DJ_Point tilePos)
	{
		tilePos.X = (int)(position.x + .5f);
		tilePos.Y = (int)(position.z + .5f);
	}
}
