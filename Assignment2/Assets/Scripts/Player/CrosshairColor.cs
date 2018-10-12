using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrosshairColor : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Image>().color = Color.white;
        
	}
	
	// Update is called once per frame
	void Update () {
        Color eyedrop = Camera.main.GetComponent<ColorPickerRayCasting>().colorPreview;
        GetComponent<Image>().color = eyedrop;
	}
}
