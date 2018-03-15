using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerSearch : MonoBehaviour {


	private Transform MonsterTR;
	private Transform PlayerTR;
	private NavMeshAgent agent;

	void Start()
	{
		MonsterTR = gameObject.GetComponent<Transform>();
		PlayerTR = GameObject.FindWithTag("Player").GetComponent<Transform>();
	
		agent = gameObject.GetComponent<NavMeshAgent>();

	}
	void Update()
	{
		agent.destination = PlayerTR.position;
	}

}
