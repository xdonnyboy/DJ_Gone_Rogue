using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DJ_BroadcastManagerScript : MonoBehaviour
{
	// Use this for initialization
	void Start ()
	{
		m_broadcastQueue = new Queue<DJ_Broadcast>();
		m_broadcastPool = new Stack<DJ_Broadcast>();

		int _num = 15;

		for(int i = 0; i < _num; ++i)
		{
			m_broadcastPool.Push(new DJ_Broadcast());
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		ProcessBroadcasts();
	}

	private void ProcessBroadcasts()
	{
		//TODO
		//time = currentBeatTime;

		while(m_broadcastQueue.Count > 0)
		{
			DJ_Broadcast _b = m_broadcastQueue.Dequeue();

			//TODO
			//_b.time = time;

			switch(_b.sender)
			{
			case DJ_BroadcastID.PLAYER:
				DJ_TileManagerScript.ReceiveBroadcast(ref _b);
				//DJ_EnemyManagerScript.ReceiveBroadcast(_b);
				break;
			case DJ_BroadcastID.TILE:
				break;
			case DJ_BroadcastID.ENEMY:
				break;
			case DJ_BroadcastID.ITEM:
				break;
			}
		}
	}

	public void ReceiveBroadcast(DJ_BroadcastID sender, DJ_BroadcastID receiver, DJ_GameData data)
	{
		//declare the broadcast to be processed
		DJ_Broadcast _b;
		
		//if we have broadcasts pooled
		if(m_broadcastPool.Count > 0)
		{
			//we grab one from the pool
			_b = m_broadcastPool.Pop();
			
			//and assign its fields
			_b.sender = sender;
			_b.receiver = receiver;
			_b.data = data;
		}
		//other wise
		else
		{
			Debug.Log ("Not enough pooled broadcasts. Making new.");
			
			//we make a new broadcast
			_b = new DJ_Broadcast(sender, receiver, data);
		}
		
		//add the broadcast to the queue to be processed
		m_broadcastQueue.Enqueue(_b);
	}

	public void SendBroadcast()
	{

	}

	private Queue<DJ_Broadcast> m_broadcastQueue;
	private Stack<DJ_Broadcast> m_broadcastPool;
}
