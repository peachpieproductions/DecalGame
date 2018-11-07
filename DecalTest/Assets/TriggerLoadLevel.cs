using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerLoadLevel : MonoBehaviour {

    public GameObject levelParent;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            foreach (Level lev in Game.inst.levels) if (lev.gameObject.activeSelf) lev.gameObject.SetActive(false);
            levelParent.SetActive(true);
        }
    }


}
