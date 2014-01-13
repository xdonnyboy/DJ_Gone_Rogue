using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DJ_SpriteManagerScript : DJ_ManagerScript {

	// Use this for initialization
	public override void Start () {
	
	}
	
	// Update is called once per frame
	public override void Update () {
	
	}

	public override void FromFile (string path)
	{
		base.FromFile (path);
	}

	public override void Dispose ()
	{
		base.Dispose ();
	}

	private Dictionary<string, Sprite> m_spriteDictionary;
}
