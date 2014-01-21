using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class DJ_EnemyManager : DJ_ManagerScript
{
	public DJ_EnemyManager ()
	{
		base.Start ();
		enemyPool = new ArrayList ();
		enemyMap = new Dictionary<DJ_Point, GameObject> ();
		closestEnemies = new Dictionary<DJ_Point, GameObject> ();
		FromFile ("");
	}

	public override void Start(){
	}

	public override void Update(){
	}

	public override void FromFile(string path){
		makeEnemies ();
	}

	public override void Dispose() {
	}

	void makeEnemies() {
	}

	/// <summary>
	/// The enemy prefab.
	/// </summary>
	public GameObject m_enemyPrefab;
	
	private Texture[] m_enemyTextures;
	
	/// <summary>
	/// The list of pooled enemies.
	/// </summary>
	public static ArrayList enemyPool;
	
	/// <summary>
	/// The enemy map. A dictionary of all the enemies in the level.
	/// </summary>
	public static Dictionary<DJ_Point, GameObject> enemyMap;
	
	/// <summary>
	/// The closest enemies. A dictionary of the closest enemies to the player on the level.
	/// </summary>
	private Dictionary<DJ_Point, GameObject> closestEnemies;
}

