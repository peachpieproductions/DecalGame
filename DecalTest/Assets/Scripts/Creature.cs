using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Creature : MonoBehaviour {

    public Transform[] waypoints;
    public Light redLight;
    bool canSeePlayer;
    bool triggered;
    int currentWaypoint;
    NavMeshAgent agent;

    private void Start() {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(waypoints[currentWaypoint].position);
        StartCoroutine(CheckPlayerVisibility());
    }

    private void Update() {

        if (triggered) {
            if (!canSeePlayer) {
                ToggleTriggeredState(false);
            } else {
                if (Vector3.Distance(transform.position,Game.inst.player.position) < 3) {
                    Game.inst.player.GetComponent<Player>().Die();
                }
            }
        } else {
            
            if (waypoints.Length > 0) {
                if (Vector3.Distance(transform.position, waypoints[currentWaypoint].position) < 1) {
                    currentWaypoint++;
                    if (currentWaypoint == waypoints.Length) currentWaypoint = 0;
                    agent.SetDestination(waypoints[currentWaypoint].position);
                }
            }
            if (canSeePlayer) {
                ToggleTriggeredState(true);
            }
        }

    }

    public void ToggleTriggeredState(bool isTriggered) {
        triggered = isTriggered;
        if (isTriggered) {
            redLight.intensity = 2f;
            agent.speed = 5f;
        } else {
            redLight.intensity = .5f;
            agent.speed = 2f;
            agent.SetDestination(waypoints[currentWaypoint].position);
            
        }
    }

    IEnumerator CheckPlayerVisibility() {

        while (true) {
            //Debug.DrawRay(transform.position + transform.forward, (Game.inst.player.position - (transform.position + transform.forward)).normalized * 12f, Color.red, .25f);
            RaycastHit hit;
            if (Physics.Raycast(transform.position + transform.forward, Game.inst.player.position - (transform.position + transform.forward), out hit, 12f)) {
                if (hit.transform.CompareTag("Player") && Vector3.Angle(transform.forward, Game.inst.player.position - (transform.position + transform.forward)) < 75) {
                    canSeePlayer = true;
                    agent.SetDestination(Game.inst.player.position);
                } else canSeePlayer = false;
            } else canSeePlayer = false;

            yield return new WaitForSeconds(.25f);
        }

    }





}
