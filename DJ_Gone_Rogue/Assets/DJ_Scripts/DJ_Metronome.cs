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
	public string trackname;
	public int num_of_idletracks;
	public int num_of_battletracks;

	// bpm info
	public int bpm;
	// time signature (in four)
	public int timesig;

	// Two AudioComponents, BABYYYY
	private AudioSource source1;
	private AudioSource source2;

	//private Queue<AudioSource> audioQ;

	// Arrays for music snippets
	private AudioClip[] idle;
	private AudioClip[] battle;

	private int tracknum;

	// Use this for initialization
	void Start () 
	{
		idle = new AudioClip[num_of_idletracks];
		battle = new AudioClip[num_of_battletracks];
		// Plays the music track, yay.

		// How do I bring an AudioClip object into musictrack?!
		/*
		AudioSource source = gameObject.AddComponent<AudioSource> ();
		source.clip = musictrack;
		// full blast and loop!
		source.volume = 1F; 
		source.loop = true;
		source.Play();
		*/

		// Load music looping from Resources
		int maxtracks;
		if (num_of_idletracks < num_of_battletracks)
			maxtracks = num_of_battletracks;
		else
			maxtracks = num_of_idletracks;
		
		for(int i=0; i< maxtracks; i++) 
		{
			// We're gonna stick with "0" as the first number in an array.
			string idlename = trackname + "_idle"+(i+1);
			string battlename = trackname + "_battle"+(i+1);

			if(i < num_of_idletracks)
			{
				Debug.Log (idlename + " " + i+ " " + idle.Length);
				idle[i] = Resources.Load (idlename) as AudioClip;
	
				//idle[i] = Resources.Load (idlename) as AudioClip;
			}
			if (i < num_of_battletracks)
			{
				AudioClip temp = new AudioClip();
				Debug.Log (battlename + " " + i + " " + battle.Length);
				temp = Resources.Load (battlename) as AudioClip;
				battle[i] = temp;
			}
		}
		source1 = gameObject.AddComponent<AudioSource> ();
		tracknum = 1;
		source1.clip = idle [tracknum-1];
		source1.Play ();

		//tracknum++;
		source2 = gameObject.AddComponent<AudioSource> ();
		source2.clip = idle [tracknum-1];

		flag1 = false;
		flag2 = true;
		// Start Timer or w/e the metronome is kept by
	}

	private bool flag1;
	private bool flag2;
	// Update is called once per frame
	void Update () 
	{
		if (!source1.isPlaying && flag2 == true)
		{
				source2.Play();

				if (tracknum < num_of_idletracks)
					tracknum++;
				else 
					tracknum = 1;
				Debug.Log (tracknum);
				source1.clip = idle[tracknum-1];
				flag2 = false;
		}



		if (Input.GetKeyDown(KeyCode.Alpha1)) 
		{
			source1.clip = idle[0];
			source1.Play ();		
		}

		if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			source2.clip = idle[1];
			source2.Play ();
		}

		if (Input.GetKeyDown (KeyCode.Alpha3)) 
		{
			source1.clip = battle[0];
			source1.Play();
		}

	}


	// In the case FixedUpdate is used instead
	void FixedUpdate ()
	{

	}
}
