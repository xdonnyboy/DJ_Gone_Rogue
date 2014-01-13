using UnityEngine;
using System.Collections;

public class DJ_PlayerScript : DJ_3DSpriteScript
{

	public DJ_PlayerScript()
	{

	}

	// Use this for initialization
	public override void Start ()
	{
		base.Start();

		transform.position = new Vector3( (int)transform.position.x, 0.0f, (int)transform.position.z );
	}
	
	// Update is called once per frame
	public override void Update ()
	{
		base.Update();
	}
}
