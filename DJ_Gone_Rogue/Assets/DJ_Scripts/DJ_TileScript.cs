using UnityEngine;
using System.Collections;

/// <summary>
/// D j_ tile script. Characterizes the tile entity. Extends DJ_EntityScript.
/// 
/// @author Wyatt Sanders 1/9/2014
/// </summary>
public class DJ_TileScript : DJ_EntityScript
{

	public DJ_TileScript()
		: base()
	{

	}

	// Use this for initialization
	public override void Start ()
	{
		base.Start();

		m_tileMeshTransform = transform.GetChild(0);

		//rotate the tile so that it faces up. This is the only
		//entity that does not use the cameras forward to determine
		//its orientation.
		transform.rotation = Quaternion.FromToRotation(transform.up, new Vector3(0.0f, 1.0f, 0.0f));

		//change the position of the attached cube mesh so that the origin/position of the tile
		//object is at the center of the surface of the mesh
		m_tileMeshTransform.position =
			new Vector3(m_tileMeshTransform.position.x,
			            m_tileMeshTransform.position.y - (m_tileMeshTransform.GetComponent(typeof(MeshRenderer)) as MeshRenderer).bounds.size.y / 2f,
			            m_tileMeshTransform.position.z);
	}

	// Update is called once per frame
	public override void Update ()
	{
		base.Update();
	}

	public override void Reset ()
	{
		base.Reset ();
	}

	private int m_LifeRemaining;

	//this is the mesh that represents the visual aspect of the tile
	//this should only be used to reflect the visual state of the tile
	private Transform m_tileMeshTransform;
}
