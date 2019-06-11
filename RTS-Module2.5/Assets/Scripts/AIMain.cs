using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMain : MonoBehaviour {

    public Transform goal;
    NavMeshAgent agent;
    public Transform SpawnPos;


    int health = 100;

    // Use this for initialization  
    void Start () {
        SpawnPos = this.transform;
         agent = GetComponent<NavMeshAgent>();
        //Real
        goal = GameObject.Find("Controller (right)").GetComponentInParent<Transform>();

        //Testing with no Vive
        //goal = GameObject.Find("Mace0.1").GetComponentInParent<Transform>();
        ;

    }
	
	// Update is called once per frame
	void Update () {
        goal = GameObject.Find("Controller (right)").GetComponentInParent<Transform>();
        agent.destination = goal.position;
		
	}


 
    








}
