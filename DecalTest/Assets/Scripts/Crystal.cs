using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour {

    public Transform modelNull;
    public Transform outerGlass;
    public Transform innerGlass;
    public Light lightSource;
    public ParticleSystem partSystem;
    public MeshRenderer outerGlassMat;
    float currentHue;
    float updateColorTimer;

    private void Update() {
        outerGlass.Rotate(0, Time.deltaTime * 30, 0, Space.World);
        innerGlass.Rotate(0, -Time.deltaTime * 60, 0, Space.World);

        modelNull.transform.localPosition = new Vector3(0, Mathf.Sin(Time.time) * .2f, 0);

        lightSource.intensity = 3 + Mathf.Sin(Time.time) * 2;

        currentHue += Time.deltaTime * .05f;
        if (currentHue >= 1) currentHue = 0;

        if (updateColorTimer > 0) updateColorTimer -= Time.deltaTime;
        else {
            var col = new Color();
            col = Color.HSVToRGB(currentHue, .6f, 1f);
            var partSys = partSystem.main;
            partSys.startColor = col;
            lightSource.color = col;
            outerGlassMat.material.SetColor("_EmissionColor", col);
            updateColorTimer = .3f;
        }
    }

}
