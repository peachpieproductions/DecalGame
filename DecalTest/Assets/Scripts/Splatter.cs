using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LlockhamIndustries.Decals;

public class Splatter : MonoBehaviour {

    public float size = .5f;
    public float fullSize;
    public Texture2D[] splatTextures;

    private void Start() {
        fullSize = transform.localScale.x;
        fullSize += Random.Range(0, .3f);
        ProjectionRenderer ren = GetComponent<ProjectionRenderer>();
        var splatIndex = Random.Range(0, 4);
        ren.Offset = new Vector2(.25f * splatIndex, 0);
        ren.UpdateProperties();
    }

    private void Update() {
        if (size < 1) {
            size = Mathf.Min(1, size + Time.deltaTime * 13f);
            transform.localScale = Vector3.one * size * fullSize;
        } else {
            Destroy(this);
        }
    }



}
