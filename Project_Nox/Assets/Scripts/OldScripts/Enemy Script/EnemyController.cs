using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Transform player;
    public float maxRange = 20f;
    private NavMeshAgent navMeshAgent;
    private Vector3 origin;
    public Animator animator;
    private void Awake() { animator = GetComponent<Animator>(); }
/*
    void Start() {
        transform.parent.transform.parent.gameObject.GetComponent<RoomController>().complete = true;
        //player = GameObject.Find("PlayerController").transform;
        player = transform.parent.transform.parent.gameObject.GetComponent<RoomController>().templates.player;
        navMeshAgent = GetComponent<NavMeshAgent>();
        origin = transform.position;
    }
*/
    void Update() {
        if (isLineOfSight()) {
            Debug.DrawLine(transform.position, player.position, Color.blue);
            navMeshAgent.destination = player.position;
            animator.SetBool("Walking", true);
        }
        else {
            navMeshAgent.destination = origin;
            animator.SetBool("Walking", false);
        }
    }

    private bool isLineOfSight() {
        RaycastHit _hit;
        Vector3 directionOfPlayer = player.position - transform.position;
        if (Physics.Raycast(transform.position, directionOfPlayer, out _hit, maxRange)) {
            if (_hit.transform.name == "PlayerController") {
                //navMeshAgent.enabled = true;
                return true;
            }
        }
        return false;
    }
}
