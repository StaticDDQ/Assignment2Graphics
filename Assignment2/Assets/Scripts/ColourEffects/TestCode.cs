﻿using UnityEngine;

// Test if the code works
public class TestCode : MonoBehaviour {
    public GameObject target2;
    public GameObject target1;
    public GameObject target;

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.E))
        {
            target1.GetComponent<DissolveObject>().DissolveOn();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            target.GetComponent<ColourDecider>().SetEffect(Color.magenta);
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            target2.GetComponent<ButtonDetect>().ButtonPressed();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            GravityControl.ChangeGravity(1);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            GravityControl.ChangeGravity(-1);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            GravityControl.ChangeGravity(2);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            GravityControl.ChangeGravity(-2 );
        }
    }
}
