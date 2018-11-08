using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public GameObject ball;
    public Transform cam;
    Rigidbody rb;
    bool crouched;
    CapsuleCollider capsuleCollider;
    [HideInInspector] public float currentHue;
    public float shootInterval = .5f;
    float shootTimer;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
        capsuleCollider = GetComponent<CapsuleCollider>();
    }

    private void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
    }

    public void CycleColor() {
        currentHue += .0075f;
        if (currentHue >= 1) currentHue = 0;
    }

    private void Update() {

        if (Input.GetKeyDown(KeyCode.Escape)) UnityEditor.EditorApplication.isPlaying = false;

        //Kill Y
        if (transform.position.y < -60) {
            rb.velocity = Vector3.zero;
            transform.position = new Vector3(0, 50, 0);
        }

        if (Input.GetMouseButtonDown(0)) {
            shootTimer = 0;
        }
        if (Input.GetMouseButton(0)) {
            if (shootTimer > 0) shootTimer -= Time.deltaTime;
            else {
                var inst = Instantiate(ball, transform.position + cam.forward * .5f, Quaternion.identity);
                inst.GetComponent<Rigidbody>().velocity = cam.forward * 15;
                shootTimer = shootInterval;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            rb.velocity += Vector3.up * 7f;
        }

        if (Input.GetKey(KeyCode.LeftControl)) {
            if (!crouched) {
                crouched = true;
                capsuleCollider.height *= .5f;
                capsuleCollider.center *= .5f;
            }
        } else {
            if (crouched) {
                crouched = false;
                capsuleCollider.height *= 2;
                capsuleCollider.center *= 2;
            }
        }

        cam.Rotate(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0);
        cam.eulerAngles = new Vector3 (cam.eulerAngles.x, cam.eulerAngles.y, 0);

        var forward = cam.forward; forward.y = 0;
        rb.velocity += forward * Input.GetAxisRaw("Vertical") * 2;
        rb.velocity += cam.right * Input.GetAxisRaw("Horizontal") * 2;
        var vel = rb.velocity;
        vel.y = 0;
        vel *= .95f;
        if (vel.magnitude > 4f) vel = vel.normalized * 4;
        rb.velocity = new Vector3(vel.x, rb.velocity.y, vel.z);
    }


}
