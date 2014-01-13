using UnityEngine;
using System.Collections;


/// <summary>
/// D j_ tile manager script. This script is responsible for managing
/// all the active and inactive tiles currently in the level and is
/// responsible for interfacing with other managers.
/// 
/// @author Wyatt Sanders 1/9/2014
/// </summary>
public class DJ_TileManagerScript : DJ_ManagerScript
{

	// Use this for initialization
	public override void Start ()
	{
		base.Start ();
		
		//this is only going tobe attached to an empty object but center
		//it at the origin anyway
		gameObject.transform.position = Vector3.zero;

		m_pooledTiles = new ArrayList();
		m_activeTiles = new ArrayList();
		
		FromFile("");
	}
	
	// Update is called once per frame
	public override void Update ()
	{
		base.Update  ();
	}

	public override void FromFile (string path)
	{
		base.FromFile (path);

		int _num = 10;

		Vector3 _p = Vector3.zero;

		for(int x = 0; x < _num; x++)
		{
			_p.z = 0;

			for(int z = 0; z < _num; z++)
			{
				//Create the tile object and tag it as a GameObject
				GameObject _t = (GameObject.Instantiate(m_tilePrefab) as GameObject);

				//set the position of the tile
				_t.transform.position = _p;

				//Assign the sprite of the tile
				(_t.transform.GetChild(0).GetComponent(typeof(MeshRenderer)) as MeshRenderer).material.mainTexture = m_tileTextures[0];

				//Add the tile to our list of active tiles
				m_activeTiles.Add(_t);

				//increment the z portion of the position
				_p.z += (m_tilePrefab.transform.GetChild(0).GetComponent(typeof(MeshRenderer)) as MeshRenderer).bounds.size.z;
			}

			//increment the x portion of the position
			_p.x += (m_tilePrefab.transform.GetChild(0).GetComponent(typeof(MeshRenderer)) as MeshRenderer).bounds.size.x;
		}
	}

	public override void Dispose ()
	{
		base.Dispose ();
	}

	/// <summary>
	/// The tile prefab.
	/// </summary>
	public GameObject m_tilePrefab;

	public Texture[] m_tileTextures;

	/// <summary>
	/// The list of pooled tiles.
	/// </summary>
	private ArrayList m_pooledTiles;

	/// <summary>
	/// The list of active tiles.
	/// </summary>
	private ArrayList m_activeTiles;
}
