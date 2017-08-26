using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMovement : MonoBehaviour {

    Transform currentTarget;
    NavMeshAgent agent;

	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();	
	}
	
	// Update is called once per frame
	void Update () {
        StartCoroutine("MoveToTarget");
	}

    public void MoveToPoint(Vector3 point)
    {
        agent.SetDestination(point);
    }

    public void FollowTarget(Interactable target)
    {
        agent.stoppingDistance = target.radius * .8f;
        agent.updateRotation = false;
        currentTarget = target.transform;
    }

    public void UnFollowTarget()
    {
        agent.stoppingDistance = 0f;
        agent.updateRotation = true;
        currentTarget = null;
    }

    IEnumerator MoveToTarget()
    {
        if (currentTarget != null)
        {
            agent.SetDestination(currentTarget.position);
            FaceToTarget();
        }
        yield return new WaitForSeconds(1f);

    }

    private void FaceToTarget()
    {
        Vector3 direction = (currentTarget.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
}
