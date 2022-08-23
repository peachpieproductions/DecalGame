using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

    public static Game inst;
    public Player player;
    public GameObject hub;
    public bool hubActive;
    public Level[] levels;
    public int levelsCompleted;
    public Transform[] doorLocks;

    private void Awake() {
        inst = this;
    }

    private void Update() {
        for(var i = 0; i < doorLocks.Length; i++) {
            doorLocks[i].transform.localPosition = new Vector3(0, -1.75f + Mathf.Sin(Time.time * 1f + i * 300) * .5f, 0);
        }
    }





}
