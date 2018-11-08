using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralLevel : MonoBehaviour {

    public bool levelGenerated;
    public GameObject[] levelChunkPrefabs;
    public Transform prevChunk;
    public Vector3 generateDirection;
    public bool generateInEditor;

    private void OnValidate() {
        if (generateInEditor) {
            GenerateLevel();
            generateInEditor = false;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            if (!levelGenerated) {
                GenerateLevel();
            }
        }
    }

    public void GenerateLevel() {

        prevChunk = transform;
        generateDirection = transform.forward;

        for (var i = 0; i < 25; i++) {

            var inst = Instantiate(levelChunkPrefabs[Random.Range(0, levelChunkPrefabs.Length)], transform);
            inst.transform.position = prevChunk.position + generateDirection * Random.Range(5f, 9f);
            inst.transform.localPosition += new Vector3(Random.Range(-2, 2), Random.Range(-2, 2));
            inst.transform.rotation = Quaternion.LookRotation(generateDirection);

            if (Random.value < .4f) generateDirection = Quaternion.Euler(0, Random.Range(-80, 80), 0) * generateDirection;

            prevChunk = inst.transform;
        }

        levelGenerated = true;
    }

    public void DestroyLevel() {

        foreach (Transform child in transform) {
            DestroyImmediate(child.gameObject);
        }
        levelGenerated = false;
    }




}
