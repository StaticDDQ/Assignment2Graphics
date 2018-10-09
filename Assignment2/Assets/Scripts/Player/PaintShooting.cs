using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintShooting : MonoBehaviour {

    public GameObject paintballPrefab;
    public float paintballSpeed = 10.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Transform paintballSpawn = Camera.main.transform;
        Debug.Log(paintballSpawn.forward);
        //paintballSpawn.localPosition += new Vector3(0.0f, -0.5f, 0.5f);

		if (Input.GetMouseButtonDown(0))
        {
            var paintball = (GameObject)Instantiate(paintballPrefab,
                paintballSpawn.position + paintballSpawn.forward,
                paintballSpawn.rotation);
            paintball.GetComponent<Rigidbody>().velocity = paintballSpawn.forward * paintballSpeed;
            paintball.GetComponent<Renderer>().material.SetColor("_Color", Color.red);

            Destroy(paintball, 2.0f);
        }
	}
}
