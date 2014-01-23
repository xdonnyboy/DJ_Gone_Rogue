using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

/// <summary>
/// DJ_LevelParser.cs: This script is responsible for parsing and XML file
/// corresponding to a level and extracting all the data and serializing it 
/// into lists.The other managers i.e Player, Tile, Enemy, Item then access 
/// this information to form the game world.
/// 
/// @author - Fernando Carrillo 1/23/2014
/// </summary>

public class DJ_LevelParser : MonoBehaviour {

	public static List<Player> playerList = new List<Player>();
	public static List<Tile> tileList = new List<Tile>();
	public static List<Enemy> enemyList = new List<Enemy>();
	public static List<Wall> wallList = new List<Wall>();
	public static List<Item> itemList = new List<Item>();
	public static List<Door> doorList = new List<Door>();
	public static bool debug = true;

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
	public static void LoadLevel(int levelnumber){
		LoadLevel("Level"+ levelnumber);
	}
	
	//Opens the XML level File and fills a list of tiles and a list of enemies
	public static void LoadLevel(string path)
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

		//parses all the player objects
		XmlNodeList playerNodes = xmlDoc.SelectNodes("level/player");
		Player player;
		if(debug) Debug.Log("Trying to iterate through player nodes");
		foreach(XmlNode node in playerNodes){
			player = new Player();
			player.id = XmlConvert.ToInt16(node.SelectSingleNode("id").InnerText);
			player.x = XmlConvert.ToInt16(node.SelectSingleNode("x").InnerText);
			player.z = XmlConvert.ToInt16(node.SelectSingleNode("z").InnerText);
			playerList.Add(player);
			
			if(debug){ 
				Debug.Log("player health = " + player.health);
				Debug.Log("player id = " + player.id);
				Debug.Log("player x position" + player.x);
				Debug.Log("player z position" + player.z);
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

		//parses all the door objects
		if(debug) Debug.Log("Trying to iterate through door nodes");
		XmlNodeList doorNodes = xmlDoc.SelectNodes ("level/door");
		Door door;
		foreach(XmlNode node in doorNodes){
			door = new Door();
			door.id = XmlConvert.ToInt16(node.SelectSingleNode("id").InnerText);
			door.x = XmlConvert.ToInt16(node.SelectSingleNode("x").InnerText);
			door.z = XmlConvert.ToInt16(node.SelectSingleNode("z").InnerText);
			doorList.Add(door);

			if(debug){
				Debug.Log("door id = " + door.id);
				Debug.Log("door x position" + door.x);
				Debug.Log("door z position" + door.z);
			}
		}

		//parses all the wall objects
		if(debug) Debug.Log("Trying to iterate through wall nodes");
		XmlNodeList wallNodes = xmlDoc.SelectNodes ("level/wall");
		Wall wall;
		foreach(XmlNode node in wallNodes){
			wall = new Wall();
			wall.id = XmlConvert.ToInt16(node.SelectSingleNode("id").InnerText);
			wall.x = XmlConvert.ToInt16(node.SelectSingleNode("x").InnerText);
			wall.z = XmlConvert.ToInt16(node.SelectSingleNode("z").InnerText);
			wallList.Add(wall);
			
			if(debug){
				Debug.Log("wall id = " + wall.id);
				Debug.Log("wall x position" + wall.x);
				Debug.Log("wall z position" + wall.z);
			}
		}

		//parses all the item objects
		if(debug) Debug.Log("Trying to iterate through item nodes");
		XmlNodeList itemNodes = xmlDoc.SelectNodes ("level/item");
		Item item;
		foreach(XmlNode node in itemNodes){
			item = new Item();
			item.id = XmlConvert.ToInt16(node.SelectSingleNode("id").InnerText);
			item.x = XmlConvert.ToInt16(node.SelectSingleNode("x").InnerText);
			item.z = XmlConvert.ToInt16(node.SelectSingleNode("z").InnerText);
			itemList.Add(item);
			
			if(debug){
				Debug.Log("item id = " + item.id);
				Debug.Log("item x position" + item.x);
				Debug.Log("item z position" + item.z);
			}
		}

		//prints out final sizes of all the Lists after parsing a single file
		if(debug){
			Debug.Log("Amount of players = " + playerList.Count);
			Debug.Log("Amount of enemies = " + enemyList.Count);
			Debug.Log("Amount of tiles = " + tileList.Count);
			Debug.Log("Amount of walls = " + wallList.Count);
			Debug.Log("Amount of items = " + itemList.Count);
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
	public static string GetTextWithoutBOM(TextAsset textAsset)
	{
		MemoryStream memoryStream = new MemoryStream(textAsset.bytes);
		StreamReader streamReader = new StreamReader(memoryStream, true);	
		string result = streamReader.ReadToEnd();
		streamReader.Close();
		memoryStream.Close();
		return result;
	}

	//clears the Lists that contain the Tiles Player and enemies
	public static void ResetLevel(){
		playerList.Clear();
		enemyList.Clear();
		tileList.Clear();
		doorList.Clear();
		itemList.Clear();
		wallList.Clear();
	}
}

//Simple player class
public class Player{
	public int id;
	public int x, z;
	public int health;
	public Player(){
		health = -1;
		id = -1;
		x = z = -1;
	}
}
//Simple tile class
public class Tile{
	public int id;
	public int x, z;
	public int health;
	public Tile(){
		health = -1;
		id = -1;
		x = z = -1;
	}
}

//Simple enemy class
public class Enemy{
	public int id;
	public int x, z;
	public int health;
	public Enemy(){
		health = -1;
		id = -1;
		x = z = -1;
	}
}

//Simple enemy class
public class Item{
	public int id;
	public int x, z;
	public Item(){
		id = -1;
		x = z = -1;
	}
}

//Simple wall class
public class Wall{
	public int id;
	public int x, z;
	public Wall(){
		id = -1;
		x = z = -1;
	}
}

//simple door class
public class Door{
	public int id;
	public int x, z;
	public Door(){
		id = -1;
		x = z = -1;
	}
}