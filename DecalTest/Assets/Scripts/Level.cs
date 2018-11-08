using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {

    public bool currentlyEditing;
    public Transform levelConnector;

    private void Awake() {
        
    }

    private void OnValidate() {
        if (currentlyEditing) {
            transform.position = new Vector3 (0,0,27);
            transform.rotation = Quaternion.identity;
        } else {
            transform.position = levelConnector.position;
            transform.rotation = levelConnector.rotation;
        }
    }




}
