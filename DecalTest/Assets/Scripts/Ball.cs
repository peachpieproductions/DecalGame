using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LlockhamIndustries.Decals;

public class Ball : MonoBehaviour {

    Rigidbody rb;
    public GameObject spawn;
    public bool rainbow;
    public bool grey;
    Vector3 flyingVel;
    bool spawned;
    float hue;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    private void Start() {
        hue = FindObjectOfType<Player>().currentHue;
    }

    private void FixedUpdate() {
        flyingVel = rb.velocity;
        flyingVel.x *= .7f;
        flyingVel.z *= .7f;
        if (transform.position.y < -60) Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision) {
        if (!spawned && !collision.transform.CompareTag("Player")) {
            spawned = true;
            var inst = Instantiate(spawn, collision.contacts[0].point, Quaternion.LookRotation(flyingVel, Vector3.up));
            inst.transform.localScale *= Random.Range(1, 1.5f);
            inst.transform.Rotate(0, 0, Random.Range(0, 359));
            if (rainbow) {
                Game.inst.player.CycleColor();
                var col = new Color();
                col = Color.HSVToRGB(hue, .6f, 1f);
                inst.GetComponent<ProjectionRenderer>().SetColor(0, col);
                inst.GetComponent<ProjectionRenderer>().UpdateProperties();
            }
            if (grey) {
                var col = new Color();
                col = Color.HSVToRGB(0f, 0f, Random.Range(.4f,1f));
                inst.GetComponent<ProjectionRenderer>().SetColor(0, col);
                inst.GetComponent<ProjectionRenderer>().UpdateProperties();
            }

            Destroy(gameObject);
        }
    }



}
