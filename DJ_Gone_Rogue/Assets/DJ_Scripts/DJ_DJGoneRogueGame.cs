using UnityEngine;
using System.Collections;

/// <summary>
/// DJ_DJGoneRogueGame.cs: This script is responsible for instantiating
/// all of the managers correctly and in order. 
/// 
/// @author - Fernando Carrillo 1/23/2014
/// </summary>
public class DJ_DJGoneRogueGame : MonoBehaviour {
	//make sure the right scripts are added to these names in the editor
	public GameObject m_DJ_LevelManager, m_DJ_TileManager, m_DJ_PlayerManager;

	// Use this for initialization
	void Start () {

		//Makes and Calls the DJ_Level Manager
		GameObject _LM = (GameObject.Instantiate(m_DJ_LevelManager)) as GameObject;
		_LM.transform.parent = transform;
		_LM.transform.position = Vector3.zero;

		//Makes and Calls the DJ_Tile Manager
		GameObject _TM = (GameObject.Instantiate(m_DJ_TileManager)) as GameObject;
		_TM.transform.parent = transform;
		_TM.transform.position = Vector3.zero;

		//Makes and Calls the DJ_Player Manager
		GameObject _PS = (GameObject.Instantiate(m_DJ_PlayerManager)) as GameObject;
		_PS.transform.parent = transform;
		_PS.transform.position = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
