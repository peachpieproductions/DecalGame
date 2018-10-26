using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LlockhamIndustries.Decals;

public class Splatter : MonoBehaviour {

    public float size = .5f;
    public float fullSize;

    private void Start() {
        fullSize = transform.localScale.x;
        fullSize += Random.Range(0, .5f);
    }

    private void Update() {
        if (size < 1) {
            size = Mathf.Min(1, size + .12f);
            transform.localScale = Vector3.one * size * fullSize;
        } else {
            Destroy(this);
        }
    }



}
