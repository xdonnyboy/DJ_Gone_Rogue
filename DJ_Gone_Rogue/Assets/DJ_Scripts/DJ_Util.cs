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
		case DJ_Dir.NONE:
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
	public static bool SLerpTrajectory(ref Vector3 currPos, DJ_Point targetTilePos, float targetHeight, float animationTime)
	{
		float diffX = Mathf.Abs(targetTilePos.X - currPos.x);
		float diffY = Mathf.Abs(targetTilePos.Y - currPos.z);

		float tarHeight = targetHeight;
		
		float yDir = 1.0f;

		if(diffX < .5f || diffY < .5f)
		{
			yDir = -1.0f;
			tarHeight = 0.0f;
		}

		if(diffX == 0.5f || diffY == 0.5f)
		{
			yDir = 0.0f;
			tarHeight= 0.0f;
		}

		if(diffX < .001f || diffY < .001f)
		{
			currPos.y = 0.0f;
			currPos.x = (float)targetTilePos.X;
			currPos.z = (float)targetTilePos.Y;
			return true;
		}

		float currHeight = currPos.y;

		currPos.x += (targetTilePos.X - currPos.x) / animationTime;
		currPos.z += (targetTilePos.Y - currPos.z) / animationTime;

		currPos.y += ( (tarHeight - currHeight) / (animationTime * 2) ) * yDir;

		return false;
	}
}
