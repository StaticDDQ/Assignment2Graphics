﻿using UnityEngine;

public class DissolveObject : MonoBehaviour {

    private Material mat;
    [SerializeField] private float max, currVal;
    [SerializeField] private float speed = 1;

    private float val;
    private bool isOn = false;
    private bool dissolving = true;

    private void Awake()
    {
        mat = GetComponent<Renderer>().material;
        val = currVal;
    }

    // Update is called once per frame, set the values for the object to dissolve. Completely dissolve object will have it's collider turned off
    void Update () {
        if (isOn)
        {
            if(!dissolving && val < max)
            {
                mat.SetFloat("_DissolveY", val);
                val += Time.deltaTime * speed;
            }
            else if(dissolving && val > max)
            {
                mat.SetFloat("_DissolveY", val);
                val -= Time.deltaTime * speed;
            }
            else
            {
                isOn = false;
                if(!dissolving)
                    GetComponent<Collider>().enabled = false;
            }
        }
	}

    // Call a dissolving effect on the object
    public void DissolveOn()
    {
        if (!isOn)
        {
            isOn = true;
            dissolving = !dissolving;

            float temp = currVal;
            currVal = max;
            max = temp;

            val = currVal;

            if (dissolving)
                GetComponent<Collider>().enabled = true;
        }
    }

    public bool GetIsOn()
    {
        return this.isOn;
    }
}
