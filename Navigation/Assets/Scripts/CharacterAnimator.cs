using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterAnimator : MonoBehaviour {

    [SerializeField]
    float smooth = .1f;

    NavMeshAgent agent;
    Animator animator;

	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        float speed = agent.velocity.magnitude / agent.speed;
        animator.SetFloat("speed", speed,smooth,Time.deltaTime);
		
	}
}
