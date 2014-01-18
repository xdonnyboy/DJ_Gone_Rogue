using UnityEngine;
using System.Collections;

// <summary>
// DJ_Metronome script. Parameters are the music track, 
// its BPM, and its Time Signature. Used along with a 
// DJ_LevelMusic Prefab to instantiate a metronome that 
// pairs with the music file. 
// 
// @author Peter Kong 1/14/2014
// </summary>
public class DJ_Metronome : MonoBehaviour {

	// For music file
	public AudioClip musictrack;

	// bpm info
	public int bpm;
	// time signature (in four)
	public int timesig;

	// Use this for initialization
	void Start () 
	{
		// Plays the music track, yay.

		// How do I bring an AudioClip object into musictrack?!
		AudioSource source = gameObject.AddComponent<AudioSource> ();
		source.clip = musictrack;
		// full blast and loop!
		source.volume = 1F; 
		source.loop = true;
		source.Play();

		// Start Timer or w/e the metronome is kept by
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}


	// In the case FixedUpdate is used instead
	void FixedUpdate ()
	{

	}
}
