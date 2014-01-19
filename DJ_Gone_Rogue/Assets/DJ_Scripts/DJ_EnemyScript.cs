using UnityEngine;
using System.Collections;

/// <summary>
/// Basic enemy script
///
/// @author Jason Wang 1/18/2014
/// </summary>



public class DJ_EnemyScript : DJ_3DSpriteScript
{
	// starting health for the enemy
	public int health = 100;
	private int low_health = 25;

	// determine how many enemies will be instantiated
	public int enemy_count = 0;

	public Transform _enemy;

	public DJ_EnemyScript()
	{
		
	}

	//  instantiate enemy
	void instantiateEnemy(int x, int y, int z)
	{
				Instantiate  (_enemy, new Vector3 (x, y, z), transform.rotation);
	}
	
	// Use this for initialization
	public override void Start ()
	{
		base.Start();
		
		transform.position = new Vector3( (int)transform.position.x, 0.0f, (int)transform.position.z );

		// Create number of enemies based on enemy_count value
		// for (int i = 0; i < enemy_count; i++)
		// {
		//	instantiateEnemy(1,2,3);
		// }

	}



	// Update is called once per frame
	public override void Update ()
	{

		// if health is 0 or less.
		if (this.health <= 0) 
		{
			// destroy game object in 2 seconds.
			Destroy (gameObject, 2f);
		}

		// if health is normal
		if (this.health > this.low_health) 
		{
						// play normal AI script
		}
		else // if health is low
		{
			// set color sprite color to red
			renderer.material.color = Color.red;

			//play low life enemy AI 
		}
	}
}

