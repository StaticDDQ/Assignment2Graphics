﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGenerator : MonoBehaviour {

    public GameObject cubePrefab;
    public bool large;
    GameObject cube;

    // Use this for initialization
    void Start() {
        cube = InstantiateCube(large);
    }

	// Update is called once per frame
	void Update () {
		if (cube.transform.position.y < -10)
        {
            Destroy(cube);
            cube = InstantiateCube(large);
        }
	}

    GameObject InstantiateCube(bool large) {
        GameObject cube = Instantiate(cubePrefab, this.transform.position, this.transform.rotation);
        if (large)
        {
            cube.transform.localScale = new Vector3(4.0f, 4.0f, 4.0f);
            cube.GetComponent<Rigidbody>().mass = 16;
            cube.GetComponent<Rigidbody>().drag = 2;
            cube.GetComponent<Rigidbody>().angularDrag = 1;
        }
        return cube;
    }
}
