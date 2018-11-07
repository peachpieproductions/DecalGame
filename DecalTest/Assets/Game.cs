using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

    public static Game inst;
    public Transform player;
    public GameObject hub;
    public Level[] levels;

    private void Awake() {
        inst = this;
    }





}
