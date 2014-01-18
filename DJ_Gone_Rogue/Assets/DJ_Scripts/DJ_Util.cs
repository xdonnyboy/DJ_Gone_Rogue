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

	public static void GetNeighboringTilePos(DJ_Point currTilePos, DJ_Point targetTilePos, DJ_Dir direction)
	{
		GetNeighboringTilePos(currTilePos, targetTilePos, direction,  1);
	}

	public static void GetNeighboringTilePos(DJ_Point currTilePos, DJ_Point targetTilePos, DJ_Dir direction, int dist)
	{
		targetTilePos.X = currTilePos.X;
		targetTilePos.Y = currTilePos.Y;

		switch(direction)
		{
		case DJ_Dir.DOWN:
			targetTilePos.Y += dist;
			break;
		case DJ_Dir.UP:
			targetTilePos.Y += -dist;
			break;
		case DJ_Dir.LEFT:
			targetTilePos.X += -dist;
			break;
		case DJ_Dir.RIGHT:
			targetTilePos.X += dist;
			break;
		default:
			break;
		}
	}

	/// <summary>
	/// Smooth lerp along trajectory. Used primarily for hopping between tiles.
	/// </summary>
	/// <param name="currPos">Curr position.</param>
	/// <param name="targetTilePos">Target tile position.</param>
	/// <param name="targetHeight">Target height.</param>
	/// <param name="animationTime">Animation time.</param>
	public static void SLerpTrajectory(ref Vector3 currPos, DJ_Point targetTilePos, float targetHeight, float animationTime)
	{
		float yDir = 1.0f;

		if(Mathf.Abs(targetTilePos.X - currPos.x) < .5f || Mathf.Abs(targetTilePos.Y - currPos.z) < .5f)
			yDir = -1.0f;

		if(Mathf.Abs(targetTilePos.X - currPos.x) == 0.0f || Mathf.Abs(targetTilePos.Y - currPos.z) == 0.0f)
			yDir = 0.0f;

		float currHeight = currPos.y;

		currPos.x += (targetTilePos.X - currPos.x) / animationTime;
		currPos.z += (targetTilePos.Y - currPos.z) / animationTime;

		currPos.y += ( (targetHeight - currHeight) / animationTime ) * yDir;
	}
}
