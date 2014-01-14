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
		//process all the broacasts
		while(m_broadcastQueue.Count > 0)
		{
			DJ_Broadcast _b = m_broadcastQueue.Dequeue();

			switch(_b.receiver)
			{
			case DJ_BroadcastID.ALL:
				break;
			case DJ_BroadcastID.TILE:
				break;
			case DJ_BroadcastID.PLAYER:
				break;
			default:
				break;
			}
		}
	}
	
	public void SendBroadcast(DJ_BroadcastID _sender, DJ_BroadcastID _receiver, DJ_GameData _data)
	{
		//declare the broadcast to be processed
		DJ_Broadcast _b;

		//if we have broadcasts pooled
		if(m_broadcastPool.Count > 0)
		{
			//we grab one from the pool
			_b = m_broadcastPool.Pop();

			//and assign its fields
			_b.sender = _sender;
			_b.receiver = _receiver;
			_b.data = _data;
		}
		//other wise
		else
		{
			Debug.Log ("Not enough pooled broadcasts. Making new.");

			//we make a new broadcast
			_b = new DJ_Broadcast(_sender, _receiver, _data);
		}

		//add the broadcast to the queue to be processed
		m_broadcastQueue.Enqueue(_b);
	}

	public void SendBroadcast(DJ_Broadcast broadcast)
	{
		
	}

	private Queue<DJ_Broadcast> m_broadcastQueue;
	private Stack<DJ_Broadcast> m_broadcastPool;
}
