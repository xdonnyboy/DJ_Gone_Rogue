using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

/* DJ_LevelManager contains two public lists a tile list and an enemy list
 * it then parses an xml file to fill up these lists opn start
 */
public class DJ_LevelParser : MonoBehaviour {

	public static List<Player> playerList = new List<Player>();
	public static List<Tile> tileList = new List<Tile>();
	public static List<Enemy> enemyList = new List<Enemy>();
	public bool debug = false;

	// Use this for initialization
	public void Start () {
		if(debug) Debug.Log("Opening XML Path");
		LoadLevel(1);
		if(debug) Debug.Log("Closing XML Path");
	}
	
	// Update is called once per frame
	public void Update () {
	}

	//pass in a number to load a level instead of a path
	public void LoadLevel(int levelnumber){
		LoadLevel("Level"+ levelnumber);
	}
	
	//Opens the XML level File and fills a list of tiles and a list of enemies
	public void LoadLevel(string path)
	{
		ResetLevel();

		//instantiate a new xml doc then opens a file without the initial BOM character
		XmlDocument xmlDoc = new XmlDocument();
		TextAsset rawdata = Resources.Load(path) as TextAsset;
		xmlDoc.LoadXml(GetTextWithoutBOM(rawdata));

		//parses all the tile objects
		XmlNodeList tileNodes = xmlDoc.SelectNodes("level/tile");
		Tile tile;
		if(debug) Debug.Log("Trying to iterate through tile nodes");
		foreach(XmlNode node in tileNodes){
			tile = new Tile();
			tile.id = XmlConvert.ToInt16(node.SelectSingleNode("id").InnerText);
			tile.health = XmlConvert.ToInt16(node.SelectSingleNode("health").InnerText);
			tile.x = XmlConvert.ToInt16(node.SelectSingleNode("x").InnerText);
			tile.z = XmlConvert.ToInt16(node.SelectSingleNode("z").InnerText);
			tileList.Add(tile);

			if(debug){ 
				Debug.Log("Tile health = " + tile.health);
				Debug.Log("Tile id = " + tile.id);
				Debug.Log("Tile x position" + tile.x);
				Debug.Log("Tile z position" + tile.z);
			}
		}


		//parses all the enemy objects
		if(debug) Debug.Log("Trying to iterate through enemy nodes");
		XmlNodeList enemyNodes = xmlDoc.SelectNodes ("level/enemy");
		Enemy enemy;
		foreach(XmlNode node in enemyNodes){
			enemy = new Enemy();
			enemy.id = XmlConvert.ToInt16(node.SelectSingleNode("id").InnerText);
			enemy.x = XmlConvert.ToInt16(node.SelectSingleNode("x").InnerText);
			enemy.z = XmlConvert.ToInt16(node.SelectSingleNode("z").InnerText);
			enemyList.Add (enemy);

			if(debug){
				Debug.Log("Enemy id = " + enemy.id);
				Debug.Log("Enemy x position" + enemy.x);
				Debug.Log("Enemy z position" + enemy.z);
			}
		}

		//parses all the enemy objects
		if(debug) Debug.Log("Trying to iterate through enemy nodes");
		XmlNodeList playerNodes = xmlDoc.SelectNodes ("level/player");
		Player player;
		foreach(XmlNode node in playerNodes){
			player = new Player();
			player.id = XmlConvert.ToInt16(node.SelectSingleNode("id").InnerText);
			player.x = XmlConvert.ToInt16(node.SelectSingleNode("x").InnerText);
			player.z = XmlConvert.ToInt16(node.SelectSingleNode("z").InnerText);
			playerList.Add(player);

			if(debug){
				Debug.Log("player id = " + player.id);
				Debug.Log("player x position" + player.x);
				Debug.Log("player z position" + player.z);
			}
		}
		if(debug){
			Debug.Log("Amount of players = " + playerList.Count);
			Debug.Log("Amount of enemies = " + enemyList.Count);
			Debug.Log("Amount of tiles = " + tileList.Count);
		}
	}

	/**
     * Returns safe text from TextAsset.
     * 
     * Text files can contain byte order mark (BOM) to specify encoding details.
     * Generally, BOM is consumed when loading text from a file (for example with TextReader or XmlReader).
     * TextAsset provides "text" field that contains "raw" file text where BOM is preserved.
     * This can cause errors. 
     * For example, when trying to read xml with XmlReader.
     *     (XmlException: Text node cannot appear in this state.  Line 1, position 1.
     *      Mono.Xml2.XmlTextReader.ReadText (Boolean notWhitespace)... )
     * 
     * */
	public string GetTextWithoutBOM(TextAsset textAsset)
	{
		MemoryStream memoryStream = new MemoryStream(textAsset.bytes);
		StreamReader streamReader = new StreamReader(memoryStream, true);	
		string result = streamReader.ReadToEnd();
		streamReader.Close();
		memoryStream.Close();
		return result;
	}

	//clears the Lists that contain the Tiles Player and enemies
	public void ResetLevel(){
		playerList.Clear();
		enemyList.Clear();
		tileList.Clear();
	}
}

//Simple player class
public class Player{
	public int health;
	public int id;
	public int x, z;
	public Player(){
		health = 0;
		id = 0;
		x = z = 0;
	}
}
//Simple tile class
public class Tile{
	public int health;
	public int id;
	public int x, z;
	public Tile(){
		health = 0;
		id = 0;
		x = z = 0;
	}
}

//Simple enemy class
public class Enemy{
	public int health;
	public int id;
	public int x, z;
	public Enemy(){
		health = 0;
		id = 0;
		x = z = 0;
	}
}